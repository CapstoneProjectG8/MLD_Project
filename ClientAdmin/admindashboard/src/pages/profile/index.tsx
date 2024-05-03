import type { FC } from 'react';

import { Anchor, Avatar, Col, DatePicker, Form, Input, Row } from 'antd';
import axios from 'axios';
import React, { useEffect, useState } from 'react';

const { Link } = Anchor;
const { Item } = Form;

interface User {
  firstName: string;
  lastName: string;
  email: string;
  fullName: string;
  photo: string;
  address: string;
  gender: string;
  dateOfBirth: string;
  age: number;
}

const Profile: FC = () => {
  const [selectedSection, setSelectedSection] = useState<string | null>(null);
  const [userData, setUserData] = useState<User | null>(null);
  // Effect to set default selected section to "user-info" when component mounts

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = await axios.get<User>('https://localhost:7241/api/User');

        setUserData(response.data);
      } catch (error) {
        console.error('Error fetching user data:', error);
      }
    };

    setSelectedSection('user-info');
    fetchUserData();
  }, []);

  return (
    <Row gutter={[16, 16]}>
      <Col span={1} />
      {/* Add a small offset to the left of the left column */}
      <Col span={7} offset={1}>
        {userData && (
          <>
            <Avatar size={128} src="link_to_avatar_image" />
            <Anchor
              onClick={e => {
                setSelectedSection(e.target.href.split('#')[1]);
              }}
            >
              <Link href="#user-info" title="Thông tin user" />
              <Link href="#change-password" title="Đổi mật khẩu" />
            </Anchor>
          </>
        )}
      </Col>
      <Col span={12}>
        <div id="user-info" style={{ display: selectedSection === 'user-info' ? 'block' : 'none' }}>
          <h2>Thông tin user</h2>
          {userData && (
            <Form initialValues={userData}>
              <Item label="First Name" name="firstName">
                <Input />
              </Item>
              <Item label="Last Name" name="lastName">
                <Input />
              </Item>
              <Item label="Email" name="email">
                <Input />
              </Item>
              <Item label="Address" name="address">
                <Input />
              </Item>
              <Item label="Gender" name="gender">
                <Input />
              </Item>
              <Item label="Date of Birth" name="dateOfBirth">
                <DatePicker />
              </Item>
              {/* Add other fields as needed */}
            </Form>
          )}
        </div>
        <div id="change-password" style={{ display: selectedSection === 'change-password' ? 'block' : 'none' }}>
          <h2>Đổi mật khẩu</h2>
          {/* Your change password content goes here */}
        </div>
      </Col>
      <Col span={2} />
    </Row>
  );
};

export default Profile;
