import type { LoginParams } from '@/interface/user/login';
import { FC, useState } from 'react';

import './index.less';

import { Button, Checkbox, Form, Input, message } from 'antd';
import { useDispatch } from 'react-redux';
import { useLocation, useNavigate } from 'react-router-dom';

import { LocaleFormatter, useLocale } from '@/locales';
import { formatSearch } from '@/utils/formatSearch';

import { loginAsync, logoutAsync } from '../../stores/user.action';
import axios from 'axios';
import Cookies from 'js-cookie';

const LoginForm: FC = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const dispatch = useDispatch();
  const { formatMessage } = useLocale();
  const [error, setError] = useState('');
  // Function to check if the token cookie has expired
  const logoutIfTokenExpired = async () => {
    const token = Cookies.get('token');
    if (!token) {
      // Token does not exist, perform logout
      const res = Boolean(await dispatch(logoutAsync()));
      res && navigate('/login');
      return;
    }

    // Check if token is expired
    const expiration = new Date(Cookies.get('token_expiration'));
    const now = new Date();
    if (expiration <= now) {
      // Token is expired, perform logout
      const res = Boolean(await dispatch(logoutAsync()));
      res && navigate('/login');
    }
  };
  const onFinished = async (form: LoginParams) => {
    try {
      // Dispatch the login action
      const res = await dispatch(loginAsync(form));

      // Access username and password from the form
      const { username, password } = form;

      // Call the API for login
      const response = await axios.post('https://localhost:7241/api/Account/Login', {
        username,
        password,
      });

      // Check if login was successful and user has RoleId = 1
      if (response && response.data && response.data.roleId === 1) {
        // Save token to cookie and set expiration time to 2 hours from now
        const expirationDate = new Date();
        expirationDate.setTime(expirationDate.getTime() + (2 * 60 * 60 * 1000)); // 2 hours in milliseconds
        Cookies.set('token', response.data.token, { expires: expirationDate });

        // Set token expiration time
        Cookies.set('token_expiration', expirationDate.toISOString());

        // Redirect user after successful login
        const search = formatSearch(location.search);
        const from = search.from || { pathname: '/' };
        navigate(from);
        message.success('Login success!');
      } else {
        // Handle case where login was successful but user does not have RoleId = 1
        message.error('Unauthorized access');
      }
    } catch (error) {
      // Handle login error
      message.error('Invalid username or password');
    }
  };
  setInterval(logoutIfTokenExpired, 60000);


  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  return (
    <div className="login-page">
      <Form<LoginParams> onFinish={onFinished} className="login-page-form">
        <h2>LOGIN ADMIN</h2>
        <Form.Item
          name="username"
          rules={[
            {
              required: true,
              message: formatMessage({
                id: 'gloabal.tips.enterUsernameMessage',
              }),
            },
          ]}
        >
          <Input
            value={username}
            placeholder={formatMessage({
              id: 'gloabal.tips.username',
            })}
          />
        </Form.Item>
        <Form.Item
          name="password"
          rules={[
            {
              required: true,
              message: formatMessage({
                id: 'gloabal.tips.enterPasswordMessage',
              }),
            },
          ]}
        >
          <Input
            type="password"
            value={password}
            placeholder={formatMessage({
              id: 'gloabal.tips.password',
            })}
          />
        </Form.Item>
        <Form.Item name="remember" valuePropName="checked">
          <Checkbox>
            <LocaleFormatter id="gloabal.tips.rememberUser" />
          </Checkbox>
        </Form.Item>
        <Form.Item>
          <Button htmlType="submit" type="primary" className="login-page-form_button">
            <LocaleFormatter id="gloabal.tips.login" />
          </Button>
        </Form.Item>
      </Form>
    </div>
  );
};

export default LoginForm;
