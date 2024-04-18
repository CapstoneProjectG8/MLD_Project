import React, { FC, useEffect, useState } from 'react';
import axios from 'axios';
import { Button, Form, Input, message, Modal, Select, Table } from 'antd';

interface User {
  id: string;
  fullName: string;
  email: string;
  placeOfBirth: string;
  gender: string;
  active: boolean;
  createdDate: string;
  accountId: string;
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
  const [users, setUsers] = useState<User[]>([]);
  const [selectedUser, setSelectedUser] = useState<User | null>(null);
  const [detailModalVisible, setDetailModalVisible] = useState(false);
  const [confirmModalVisible, setConfirmModalVisible] = useState(false);
  const [actionToPerform, setActionToPerform] = useState('');
  const [accountDetail, setAccountDetail] = useState<AccountDetail | null>(null);
  const [updatedRole, setUpdatedRole] = useState<string>('');
  const [updatedActive, setUpdatedActive] = useState<boolean>(false);
  const [addAccountModalVisible, setAddAccountModalVisible] = useState(false);
  const [newAccountFormData, setNewAccountFormData] = useState<any>({});
  const [newUserData, setNewUserData] = useState<any>({});
  const [addUserModalVisible, setAddUserModalVisible] = useState(false);

  useEffect(() => {
    axios.get('https://localhost:7241/api/User')
      .then(response => {
        const formattedUsers = response.data.map((user: any, index: number) => ({
          key: index.toString(),
          id: user.id,
          fullName: user.fullName,
          email: user.email,
          active: user.active,
          gender: user.gender ? 'Male' : 'Female',
          createdDate: user.createdDate,
          placeOfBirth: user.placeOfBirth,
          accountId: user.accountId,
        }));
        setUsers(formattedUsers);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);

  const handleDetail = (user: User) => {
    setSelectedUser(user);
    setDetailModalVisible(true);
    fetchAccountDetail(user.accountId);
  };

  const fetchAccountDetail = async (accountId: string) => {
    try {
      const response = await axios.get(`https://localhost:7241/api/Account/${accountId}`);
      setAccountDetail(response.data);
    } catch (error) {
      console.error(error);
      message.error('Failed to fetch account detail.');
    }
  };

  const handleConfirmBanUnban = (user: User, action: string) => {
    setSelectedUser(user);
    setActionToPerform(action);
    setConfirmModalVisible(true);
  };

  const handleUpdate = async () => {
    try {
      const updatedDetail = { ...accountDetail, roleId: updatedRole, active: updatedActive };
      await axios.put(`https://localhost:7241/api/Account/${selectedUser?.accountId}`, updatedDetail);
      message.success(`User details updated successfully.`);
      setDetailModalVisible(false);
    } catch (error) {
      console.error(error);
      message.error('Failed to update user details.');
    }
  };

  const confirmBanUnban = async () => {
    try {
      const updatedUser = { ...selectedUser, active: !selectedUser.active };
      const requestBody = { id: selectedUser.id, active: updatedUser.active };
      await axios.put(`https://localhost:7241/api/User/${selectedUser.id}`, requestBody);
      const updatedUsers = users.map(u => (u.id === selectedUser.id ? updatedUser : u));
      setUsers(updatedUsers);
      message.success(`User ${updatedUser.active ? 'unbanned' : 'banned'} successfully.`);
    } catch (error) {
      console.error(error);
      message.error('Failed to update user.');
    } finally {
      setConfirmModalVisible(false);
    }
  };

  const handleAddAccount = () => {
    setAddAccountModalVisible(true);
  };

  const handleCreateAccount = async () => {
    try {
      const newAccountResponse = await axios.post('https://localhost:7241/api/Account', newAccountFormData);
      const accountId = newAccountResponse.data.accountId;

      console.log('Received accountId:', accountId); // Kiểm tra accountId từ phản hồi

      // Cập nhật state với accountId mới
      setNewAccountFormData({ ...newAccountFormData, accountId });

      // Đóng modal tạo account
      setAddAccountModalVisible(false);

      // Mở modal tạo user và truyền accountId vào
      setAddUserModalVisible(true);

      message.success('Account created successfully.');

    } catch (error) {
      console.error(error);
      message.error('Failed to create account.');
    }
  };


  const handleCreateUser = () => {
    // Trước khi gửi yêu cầu tạo user, kiểm tra xem accountId đã được gán hay chưa
    if (!newAccountFormData.accountId) {
      message.error('Please create an account first.');
      return;
    }

    const userDataWithAccountId = { ...newUserData, accountId: newAccountFormData.accountId };

    axios.post('https://localhost:7241/api/User', userDataWithAccountId)
      .then(() => {
        setAddUserModalVisible(false);
        setNewUserData({});
        message.success('User created successfully.');
      })
      .catch(error => {
        console.error(error);
        message.error('Failed to create user.');
      });
  };

  const handleNewAccountFormChange = (changedValues: any, allValues: any) => {
    setNewAccountFormData(allValues);
  };

  const handleNewUserFormChange = (changedValues: any, allValues: any) => {
    setNewUserData(allValues);
  };

  const columns = [
    {
      title: '#',
      dataIndex: 'index',
      key: 'index',
      render: (_: any, record: any, index: number) => index + 1,
    },
    {
      title: 'Full Name',
      dataIndex: 'fullName',
      key: 'fullName',
    },
    {
      title: 'Email',
      dataIndex: 'email',
      key: 'email',
    },
    {
      title: 'Place of Birth',
      dataIndex: 'placeOfBirth',
      key: 'placeOfBirth',
    },
    {
      title: 'Gender',
      dataIndex: 'gender',
      key: 'gender',
    },
    {
      title: 'Active',
      dataIndex: 'active',
      key: 'active',
      render: (active: boolean) => (active ? 'Active' : 'Inactive'),
    },
    {
      title: 'Created Date',
      dataIndex: 'createdDate',
      key: 'createdDate',
    },
    {
      title: 'Action',
      key: 'action',
      render: (text: string, record: User) => (
        <span>
          <Button onClick={() => handleDetail(record)}>Detail</Button>
          <Button onClick={() => handleConfirmBanUnban(record, record.active ? 'ban' : 'unban')}>
            {record.active ? 'Ban' : 'Unban'}
          </Button>
        </span>
      ),
    },
  ];

  const layout = {
    labelCol: { span: 6 },
    wrapperCol: { span: 18 },
  };

  return (
    <div style={{ padding: '20px' }}>
      <h2>Users</h2>
      <Button onClick={handleAddAccount}>Add Account</Button>
      {/* Add Account Modal */}
      <Modal
        title="Add Account"
        visible={addAccountModalVisible}
        onCancel={() => setAddAccountModalVisible(false)}
        footer={[
          <Button key="cancel" onClick={() => setAddAccountModalVisible(false)}>
            Cancel
          </Button>,
          <Button key="createUser" type="primary" onClick={handleCreateAccount}>
            Create Account and User
          </Button>
        ]}
      >
        <Form {...layout} onValuesChange={handleNewAccountFormChange}>
          <Form.Item label="Username" name="username">
            <Input />
          </Form.Item>
          <Form.Item label="Password" name="password">
            <Input.Password />
          </Form.Item>
          <Form.Item label="Confirm Password" name="confirmPassword">
            <Input.Password />
          </Form.Item>
          <Form.Item label="Role" name="roleId">
            <Select>
              <Option value="1">Admin</Option>
              <Option value="2">Teacher</Option>
              <Option value="3">Leader</Option>
              <Option value="5">Principal</Option>
            </Select>
          </Form.Item>
        </Form>
      </Modal>

      {/* Add User Modal */}
      <Modal
        title="Add User"
        visible={addUserModalVisible}
        onCancel={() => setAddUserModalVisible(false)}
        footer={[
          <Button key="cancel" onClick={() => setAddUserModalVisible(false)}>
            Cancel
          </Button>,
          <Button key="createUser" type="primary" onClick={() => handleCreateUser(newUserData.accountId)}>
            Create User
          </Button>
        ]}
      >
        <Form {...layout} onValuesChange={handleNewUserFormChange}>
          <Form.Item label="First Name" name="firstName">
            <Input />
          </Form.Item>
          <Form.Item label="Last Name" name="lastName">
            <Input />
          </Form.Item>
          <Form.Item label="Email" name="email">
            <Input />
          </Form.Item>
          <Form.Item label="Address" name="address">
            <Input />
          </Form.Item>
          <Form.Item label="Account ID" name="accountId" hidden>
            <Input value={newUserData.accountId} disabled />
          </Form.Item>
        </Form>
      </Modal>

      {/* User Table */}
      <Table columns={columns} dataSource={users} />

      {/* User Detail Modal */}
      <Modal
        title={`${selectedUser?.fullName}'s Detail`}
        visible={detailModalVisible}
        onCancel={() => setDetailModalVisible(false)}
        footer={[
          <Button key="cancel" onClick={() => setDetailModalVisible(false)}>
            Cancel
          </Button>,
          <Button key="update" type="primary" onClick={handleUpdate}>
            Update
          </Button>,
        ]}
      >
        {accountDetail && (
          <Form {...layout}>
            <Form.Item label="Username">
              <Input value={accountDetail.username} disabled />
            </Form.Item>
            <Form.Item label="Password">
              <Input value={accountDetail.password} disabled />
            </Form.Item>
            <Form.Item label="Active">
              <Select value={updatedActive} onChange={(value: boolean) => setUpdatedActive(value)}>
                <Option value={true}>Active</Option>
                <Option value={false}>Inactive</Option>
              </Select>
            </Form.Item>
            <Form.Item label="Created By">
              <Input value={accountDetail.createdBy} disabled />
            </Form.Item>
            <Form.Item label="Created Date">
              <Input value={accountDetail.createdDate} disabled />
            </Form.Item>
            <Form.Item label="Role">
              <Select value={updatedRole} onChange={(value: string) => setUpdatedRole(value)}>
                <Option value="1">Admin</Option>
                <Option value="2">Teacher</Option>
                <Option value="3">Leader</Option>
                <Option value="5">Principle</Option>
              </Select>
            </Form.Item>
            <Form.Item label="Login Attempt">
              <Input value={accountDetail.loginAttempt} disabled />
            </Form.Item>
            <Form.Item label="Login Last">
              <Input value={accountDetail.loginLast} disabled />
            </Form.Item>
          </Form>
        )}
      </Modal>

      {/* Confirm Ban/Unban Modal */}
      <Modal
        title={`Are you sure you want to ${actionToPerform} ${selectedUser?.fullName}?`}
        visible={confirmModalVisible}
        onCancel={() => setConfirmModalVisible(false)}
        footer={[
          <Button key="cancel" onClick={() => setConfirmModalVisible(false)}>
            Cancel
          </Button>,
          <Button key="confirm" type="primary" onClick={confirmBanUnban}>
            Confirm
          </Button>,
        ]}
      >
        {`This action will ${actionToPerform} ${selectedUser?.fullName}.`}
      </Modal>
    </div>
  );
};

export default Account;
