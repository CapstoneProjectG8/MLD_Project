import type { LoginParams } from '@/interface/user/login';
import type { FC } from 'react';

import './index.less';

import { Button, Checkbox, Form, Input, message, Modal } from 'antd';
import axios from 'axios';
import Cookies from 'js-cookie';
import { useState } from 'react';
import { useDispatch } from 'react-redux';
import { useLocation, useNavigate } from 'react-router-dom';

import { LocaleFormatter, useLocale } from '@/locales';
import { formatSearch } from '@/utils/formatSearch';

import { loginAsync, logoutAsync } from '../../stores/user.action';

const initialValues: LoginParams = {
  username: 'guest',
  password: 'guest',
  // remember: true
};

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

  const [loggedInAdminId, setLoggedInAdminId] = useState(null);

  const onFinished = async (form: LoginParams) => {
    try {
      // Dispatch the login action
      const res = await dispatch(loginAsync(form));

      // Access username and password from the form
      const { username, password } = form;

      // Call the API for login
      const response = await axios.post('https://localhost:7241/api/Account/Login2', {
        username,
        password,
      });

      // Extract token and account information from the response
      const { token, accountInfo } = response.data;
      const { active, roleId, id, loginAttempt } = accountInfo;

      // Check if the account is active and the role is admin
      if (!active) {
        message.error('Your account has been locked');

        return;
      }

      if (roleId !== 1) {
        message.error('You do not have permission to log in');

        return;
      }

      // Save token to cookie and set expiration time to 2 hours from now
      const expirationDate = new Date();

      expirationDate.setTime(expirationDate.getTime() + 2 * 60 * 60 * 1000); // 2 hours in milliseconds
      Cookies.set('token', token, { expires: expirationDate });

      // Set token expiration time
      Cookies.set('token_expiration', expirationDate.toISOString());
      // Store the logged-in admin's accountId
      setLoggedInAdminId(id);
      // Redirect user after successful login
      const search = formatSearch(location.search);
      const from = search.from || { pathname: '/' };

      navigate(from);
      message.success('Login success!');
    } catch (error) {
      // Handle login error
      message.error(error.response.data);
    }
  };

  setInterval(logoutIfTokenExpired, 60000);

  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [isModalVisible, setIsModalVisible] = useState(false);

  const showChangePasswordModal = () => {
    setIsModalVisible(true);
  };

  const handleCancel = () => {
    setIsModalVisible(false);
  };

  const handlePasswordChange = async (values: any) => {
    const { username, currentPassword, newPassword } = values;

    try {
      const response = await axios.post<{ message: string }>(
        `https://localhost:7241/api/Account/ChangePassword?username=${username}&currentPassword=${currentPassword}&newPassword=${newPassword}`,
      );

      // Handle success response
      message.success(response.data);

      // Close the modal upon successful password change
      handleCancel();
    } catch (error) {
      // Handle error
      message.error(error.response.data);
      // You can display an error message or handle the error as per your application logic
    }
  };

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
        <Form.Item>
          <a href="#" onClick={showChangePasswordModal}>
            Change password
          </a>
        </Form.Item>
      </Form>
      <Modal title="Change Password" visible={isModalVisible} onCancel={handleCancel} footer={null}>
        <Form onFinish={handlePasswordChange}>
          <Form.Item label="Username" name="username" rules={[{ required: true, message: 'Username is required' }]}>
            <Input />
          </Form.Item>
          <Form.Item
            label="Current Password"
            name="currentPassword"
            rules={[{ required: true, message: 'Current password is required' }]}
          >
            <Input.Password />
          </Form.Item>
          <Form.Item
            label="New Password"
            name="newPassword"
            rules={[{ required: true, message: 'New password is required' }]}
          >
            <Input.Password />
          </Form.Item>
          <Form.Item>
            <Button htmlType="submit" type="primary">
              Submit
            </Button>
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default LoginForm;
