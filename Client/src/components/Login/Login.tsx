import React, { useState } from 'react';
import axios from 'axios';
import { Button, Card, Col, Form, Input, message, Row } from 'antd';
import Cookies from 'js-cookie';

const LoginPage: React.FC = () => {
  const [formData, setFormData] = useState({ username: '', password: '' });
  const [error, setError] = useState<string | null>(null);

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7241/api/Account/Login', formData);
      if (response.status === 200) { // Assuming successful login
        const authToken = response.data; // Lấy `authToken` từ phản hồi đăng nhập
        Cookies.set('authToken', authToken, { expires: 1 }); // Lưu trữ `authToken` dưới dạng cookie với thời hạn 1 ngày
      }
    } catch (error) {
      if (error.response && error.response.status === 401) {
        setError('Incorrect username or password. Please try again.');
      } else {
        setError('An error occurred. Please try again later.');
      }
    }
  };
  return (
    <Row justify="center" align="middle" style={{ minHeight: '100vh' }}>
      <Col xs={24} sm={16} md={12} lg={8}>
        <Card title="Login" style={{ width: '100%', textAlign: 'center' }}>
          <Form
            style={{ maxWidth: 600 }}
            initialValues={{ remember: true }}
            onFinish={handleLogin}
            onFinishFailed={() => message.error('Login failed. Please check your email and password.')}
            autoComplete="off"
          >
            <Form.Item
              name="username"
              label="Username"
              rules={[{ required: true, message: 'Please enter your username' }]}
              hasFeedback
            >
              <Input name="username" onChange={handleInputChange} />
            </Form.Item>

            <Form.Item
              name="password"
              label="Password"
              rules={[
                { required: true },
                {
                  pattern: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$/,
                  message: 'Please enter a valid password',
                },
              ]}
              hasFeedback
            >
              <Input.Password name="password" onChange={handleInputChange} placeholder="Type your password" />
            </Form.Item>

            <Form.Item>
              <Button type="primary" htmlType="submit" block>
                Login
              </Button>
            </Form.Item>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            <Form.Item>
              <a href="/forgotpassword">Forgot password?</a>
            </Form.Item>
          </Form>
        </Card>
      </Col>
    </Row>
  );
};

export default LoginPage;