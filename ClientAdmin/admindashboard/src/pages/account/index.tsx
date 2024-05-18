import type { FC } from 'react';

import { CloseCircleOutlined, SearchOutlined } from '@ant-design/icons';
import { CheckCircleOutlined } from '@ant-design/icons/lib/icons';
import { Button, DatePicker, Form, Input, message, Modal, Radio, Select, Space, Table } from 'antd';
import axios from 'axios';
import React, { useEffect, useRef, useState } from 'react';
import Highlighter from 'react-highlight-words';

interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  dateOfBirth: string;
  gender: boolean;
  accountId: string;
  address: string;
  photo: string;
  levelOfTrainningId: string;
  departmentId: string;
  professionalStandardsId: string;
}

interface AccountDetail {
  username: string;
  password: string;
  active: boolean;
  createdBy: string;
  createdDate: string;
  roleId: string;
  loginAttempt: number;
  loginLast: string;
}

const { Option } = Select;

const Account: FC = () => {
  const [userData, setUserData] = useState<User[]>([]);
  const [accountData, setAccountData] = useState<AccountDetail[]>([]);
  const [selectedUser, setSelectedUser] = useState<User | null>(null);
  const [modalVisible, setModalVisible] = useState<boolean>(false);

  useEffect(() => {
    // Fetch user data
    axios
      .get<User[]>('https://localhost:7241/api/User/GetAllUsers')
      .then(response => {
        setUserData(response.data);
      })
      .catch(error => {
        console.error('Error fetching user data:', error);
      });

    // Fetch account data
    axios
      .get<AccountDetail[]>('https://localhost:7241/api/Account/GetAllAccounts')
      .then(response => {
        setAccountData(response.data);
      })
      .catch(error => {
        console.error('Error fetching account data:', error);
      });
  }, []);
  const columns = [
    {
      title: 'Index',
      dataIndex: 'index',
      key: 'index',
      render: (text: string, record: any, index: number) => index + 1,
    },
    {
      title: 'Photo',
      dataIndex: 'photo',
      key: 'photo',
      render: (photo: string) => <img src={photo} alt="User Photo" style={{ width: 50, height: 50 }} />,
    },
    {
      title: 'Full Name',
      dataIndex: 'fullName',
      key: 'fullName',
      render: (text: string, record: User) => `${record.firstName} ${record.lastName}`,
    },
    {
      title: 'Email',
      dataIndex: 'email',
      key: 'email',
    },
    {
      title: 'Gender',
      dataIndex: 'gender',
      key: 'gender',
      render: (gender: boolean) => (gender ? 'Male' : 'Female'),
    },
    {
      title: 'Active',
      dataIndex: 'active',
      key: 'active',
      render: (active: boolean) => (active ? 'Yes' : 'No'),
    },
    {
      title: 'Login Attempts',
      dataIndex: 'loginAttempt',
      key: 'loginAttempt',
    },
    {
      title: 'Last Login',
      dataIndex: 'loginLast',
      key: 'loginLast',
    },
    {
      title: 'Action',
      key: 'action',
      render: (text: string, record: any) => (
        <Space size="middle">
          <Button onClick={() => handleDetails(record)}>Details</Button>
          <Button onClick={() => handleBanUnban(record.active)}>{record.active ? 'Ban' : 'Unban'}</Button>
        </Space>
      ),
    },
  ];

  const handleDetails = (user: User) => {
    const selectedAccount = accountData.find(account => account.accountId === user.accountId);

    if (selectedAccount) {
      setSelectedUser(user);
      setModalVisible(true);
    }
  };

  // Function to handle closing modal
  const handleCloseModal = () => {
    setModalVisible(false);
    setSelectedUser(null);
  };

  // Function to handle ban/unban action
  const handleBanUnban = (active: boolean) => {
    // Implement ban/unban logic here
    console.log(active ? 'Banning user...' : 'Unbanning user...');
  };

  return (
    <>
      <Table dataSource={userData} columns={columns} />
      <Modal title="User Details" visible={modalVisible} onCancel={handleCloseModal} footer={null}>
        {selectedUser && (
          <div>
            <p>
              <strong>Full Name:</strong> {`${selectedUser.firstName} ${selectedUser.lastName}`}
            </p>
            <p>
              <strong>Email:</strong> {selectedUser.email}
            </p>
            <p>
              <strong>Gender:</strong> {selectedUser.gender ? 'Male' : 'Female'}
            </p>
            {/* Add more user details here if needed */}
          </div>
        )}
      </Modal>
    </>
  );
};

export default Account;
