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
  signature: string;
  address: string;
  photo: string;
  levelOfTrainningId: string;
  departmentId: string;
  professionalStandardsId: string;
}

interface AccountDetail {
  accountId: string;
  username: string;
  password: string;
  active: boolean;
  createdBy: string;
  createdDate: string;
  roleId: string;
  loginAttempt: number;
  loginLast: string;
}

interface UserAccount extends User, AccountDetail {}

const { Option } = Select;

const Account: FC = () => {
  const [form] = Form.useForm();
  const [users, setUsers] = useState<User[]>([]);
  const [userss, setUserss] = useState<UserAccount[]>([]);
  const [accounts, setAccounts] = useState<AccountDetail[]>([]);
  const [selectedAccount, setSelectedAccount] = useState<AccountDetail | null>(null);
  const [selectedUser, setSelectedUser] = useState<User | null>(null);
  const [detailModalVisible, setDetailModalVisible] = useState(false);
  const [confirmModalVisible, setConfirmModalVisible] = useState(false);
  const [actionType, setActionType] = useState<'ban' | 'unban'>('ban');
  const [accountDetail, setAccountDetail] = useState<AccountDetail | null>(null);
  const [updatedRole, setUpdatedRole] = useState<string>('');
  const [updatedActive, setUpdatedActive] = useState<boolean>(false);
  const [addAccountModalVisible, setAddAccountModalVisible] = useState(false);
  const [newAccountFormData, setNewAccountFormData] = useState<any>({});
  const [newUserData, setNewUserData] = useState<any>({});
  const [addUserModalVisible, setAddUserModalVisible] = useState(false);
  const [searchText, setSearchText] = useState('');
  const [searchedColumn, setSearchedColumn] = useState('');
  const searchInput = useRef(null);
  const [loading, setLoading] = useState(true);

  const fetchData = async () => {
    try {
      const [userResponse, accountResponse] = await Promise.all([
        axios.get<User[]>('https://localhost:7241/api/User/GetAllUsers'),
        axios.get<AccountDetail[]>('https://localhost:7241/api/Account/GetAllAccounts'),
      ]);

      const usersData = userResponse.data;
      const accountsData = accountResponse.data;

      // Kết hợp dữ liệu từ hai API
      const combinedData = usersData.map(user => {
        const accountDetail =
          accountsData.find(account => account.accountId === user.accountId) || ({} as AccountDetail);

        return { ...user, ...accountDetail };
      });

      setUsers(combinedData);
    } catch (error) {
      console.error('Error fetching data', error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);
  useEffect(() => {
    if (accountDetail) {
      // Cập nhật giá trị cho updatedRole khi accountDetail thay đổi
      setUpdatedRole(accountDetail.roleId);
      // Cập nhật giá trị cho updatedActive khi accountDetail thay đổi
      setUpdatedActive(accountDetail.active);
    }
  }, [accountDetail]);

  const handleDetail = (user: User) => {
    setSelectedUser(user);
    setDetailModalVisible(true);
    fetchAccountDetail(user.accountId);
  };

  const fetchAccountDetail = async (accountId: string) => {
    try {
      const response = await axios.get(`https://localhost:7241/api/Account/GetAccountById/${accountId}`);

      setAccountDetail(response.data);
    } catch (error) {
      console.error(error);
      message.error('Failed to fetch account detail.');
    }
  };

  const handleConfirmBanUnban = (record: AccountDetail, action: 'ban' | 'unban') => {
    setSelectedAccount(record);
    setActionType(action);
    setConfirmModalVisible(true);
  };

  const handleUpdate = async () => {
    if (!selectedAccount) return;
    const updatedAccount = { ...selectedAccount, accountId: selectedAccount.accountId, active: actionType === 'unban' };

    try {
      await axios.put(`https://localhost:7241/api/Account/UpdateAccount`, updatedAccount);
      message.success(`Account ${actionType === 'ban' ? 'banned' : 'unbanned'} successfully!`);
      setDetailModalVisible(false);
      fetchData();
    } catch (error) {
      console.error(`Error ${actionType === 'ban' ? 'banning' : 'unbanning'} account`, error);
      message.error(`Failed to ${actionType} account`);
    }
  };

  const confirmBanUnban = async () => {
    if (!selectedAccount) return;
    const updatedAccount = { ...selectedAccount, accountId: selectedAccount.accountId, active: actionType === 'unban' };

    try {
      await axios.put(`https://localhost:7241/api/Account/UpdateAccount`, updatedAccount);
      message.success(`Account ${actionType === 'ban' ? 'banned' : 'unbanned'} successfully!`);
      setConfirmModalVisible(false);
      fetchData();
    } catch (error) {
      console.error(`Error ${actionType === 'ban' ? 'banning' : 'unbanning'} account`, error);
      message.error(`Failed to ${actionType} account`);
    }
  };

  const handleAddAccount = () => {
    setAddAccountModalVisible(true);
  };

  const handleCreateAccount = async () => {
    try {
      const newAccountResponse = await axios.post('https://localhost:7241/api/Account/AddAccount', newAccountFormData);
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

    const userDataWithAccountId = {
      ...newUserData,
      accountId: newAccountFormData.accountId,
      id: newAccountFormData.accountId,
    };

    axios
      .put('https://localhost:7241/api/User/UpdateUser', userDataWithAccountId)
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

  const handleSearch = (selectedKeys, confirm, dataIndex) => {
    confirm();
    setSearchText(selectedKeys[0]);
    setSearchedColumn(dataIndex);
  };

  const handleReset = clearFilters => {
    clearFilters();
    setSearchText('');
  };

  const getColumnSearchProps = dataIndex => ({
    filterDropdown: ({ setSelectedKeys, selectedKeys, confirm, clearFilters }) => (
      <div style={{ padding: 8 }}>
        <Input
          ref={searchInput}
          placeholder={`Search ${dataIndex}`}
          value={selectedKeys[0]}
          onChange={e => setSelectedKeys(e.target.value ? [e.target.value] : [])}
          onPressEnter={() => handleSearch(selectedKeys, confirm, dataIndex)}
          style={{ width: 188, marginBottom: 8, display: 'block' }}
        />
        <Space>
          <Button
            type="primary"
            onClick={() => handleSearch(selectedKeys, confirm, dataIndex)}
            icon={<SearchOutlined />}
            size="small"
            style={{ width: 90 }}
          >
            Search
          </Button>
          <Button onClick={() => handleReset(clearFilters)} size="small" style={{ width: 90 }}>
            Reset
          </Button>
        </Space>
      </div>
    ),
    filterIcon: filtered => <SearchOutlined style={{ color: filtered ? '#1890ff' : undefined }} />,
    onFilter: (value, record) =>
      record[dataIndex] ? record[dataIndex].toString().toLowerCase().includes(value.toLowerCase()) : '',
    onFilterDropdownVisibleChange: visible => {
      if (visible) {
        setTimeout(() => searchInput.current.select(), 100);
      }
    },
    render: text =>
      searchedColumn === dataIndex ? (
        <Highlighter
          highlightStyle={{ backgroundColor: '#ffc069', padding: 0 }}
          searchWords={[searchText]}
          autoEscape
          textToHighlight={text ? text.toString() : ''}
        />
      ) : (
        text
      ),
  });

  const getColumnFilterGender = (dataIndex, filters) => ({
    filters: filters,
    onFilter: (value, record) => record[dataIndex] === value,
  });

  const getColumnFilterStatus = (dataIndex, filters) => ({
    filters: filters,
    onFilter: (value, record) => record[dataIndex] === value,
  });
  const columns = [
    {
      title: '#',
      dataIndex: 'index',
      key: 'index',
      render: (_: any, record: any, index: number) => index + 1,
    },
    {
      title: 'Họ',
      dataIndex: 'lastName',
      key: 'lastName',
      ...getColumnSearchProps('lastName'),
    },
    {
      title: 'Tên',
      dataIndex: 'firstName',
      key: 'firstName',
      ...getColumnSearchProps('firstName'),
    },
    {
      title: 'Email',
      dataIndex: 'email',
      key: 'email',
      ...getColumnSearchProps('email'),
    },
    {
      title: 'Giới tính',
      dataIndex: 'gender',
      key: 'gender',
      ...getColumnFilterGender('gender', [
        { text: 'Nam', value: true },
        { text: 'Nữ', value: false },
      ]),
      render: (gender: boolean) => (gender ? 'Nam' : 'Nữ'),
    },
    {
      title: 'Active',
      dataIndex: 'active',
      key: 'active',
      align: 'center',
      ...getColumnFilterStatus('active', [
        { text: 'Active', value: true },
        { text: 'Inactive', value: false },
      ]),
      render: (active: boolean) =>
        active ? <CheckCircleOutlined style={{ color: 'green' }} /> : <CloseCircleOutlined style={{ color: 'red' }} />,
    },
    {
      title: 'Created Date',
      dataIndex: 'createdDate',
      key: 'createdDate',
      sorter: (a, b) => {
        const accountA = accounts.find(acc => acc.accountId === a.accountId);
        const accountB = accounts.find(acc => acc.accountId === b.accountId);

        if (!accountA || !accountB) return 0;
        const dateA = new Date(accountA.createdDate);
        const dateB = new Date(accountB.createdDate);

        return dateA.getTime() - dateB.getTime();
      },
    },
    {
      title: 'Action',
      key: 'action',
      render: (text: string, record: AccountDetail) => (
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

  const formatDate = date => {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');

    return `${year}-${month}-${day}`;
  };

  const handleDateChange = date => {
    if (date) {
      const selectedDate = date.toDate();
      const formattedDate = formatDate(selectedDate);

      form.setFieldsValue({ dateOfBirth: formattedDate });
      console.log('Selected date:', formattedDate);
    }
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
          </Button>,
        ]}
      >
        <Form onValuesChange={handleNewAccountFormChange}>
          <Form.Item
            label="Username"
            name="username"
            rules={[
              { required: true, message: 'Please input your username!' },
              { pattern: /^\S+$/, message: 'Username cannot contain whitespace!' },
            ]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            label="Password"
            name="password"
            rules={[
              {
                required: true,
                message: 'Please input your password!',
              },
              {
                min: 8,
                message: 'Password must be at least 8 characters long!',
              },
              {
                pattern: /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/,
                message: 'Password must contain at least one letter, one number, and one special character!',
              },
            ]}
          >
            <Input.Password />
          </Form.Item>
          <Form.Item
            label="Confirm Password"
            name="confirmPassword"
            dependencies={['password']}
            rules={[
              { required: true, message: 'Please confirm your password!' },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue('password') === value) {
                    return Promise.resolve();
                  }

                  return Promise.reject(new Error('The two passwords that you entered do not match!'));
                },
              }),
            ]}
          >
            <Input.Password />
          </Form.Item>
          <Form.Item label="Role" name="roleId" rules={[{ required: true, message: 'Please select a role!' }]}>
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
          </Button>,
        ]}
      >
        <Form onValuesChange={handleNewUserFormChange}>
          <Form.Item
            label="First Name"
            name="firstName"
            rules={[{ required: true, message: 'Please input your first name!' }]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            label="Last Name"
            name="lastName"
            rules={[{ required: true, message: 'Please input your last name!' }]}
          >
            <Input />
          </Form.Item>
          <Form.Item
            label="Email"
            name="email"
            rules={[{ required: true, type: 'email', message: 'Please input a valid email address!' }]}
          >
            <Input />
          </Form.Item>
          <Form.Item label="Address" name="address" rules={[{ required: true, message: 'Please input your address!' }]}>
            <Input />
          </Form.Item>
          <Form.Item label="Gender" name="gender" rules={[{ required: true, message: 'Please select your gender!' }]}>
            <Radio.Group>
              <Radio value={true}> Male </Radio>
              <Radio value={false}> Female </Radio>
            </Radio.Group>
          </Form.Item>
          {/*<Form.Item*/}
          {/*  label="Birth"*/}
          {/*  name="dateOfBirth"*/}
          {/*  rules={[{ required: true, message: 'Please input your date of birth!' }]}*/}
          {/*>*/}
          {/*  <DatePicker format="YYYY-MM-DD" onChange={handleDateChange} />*/}
          {/*</Form.Item>*/}
          <Form.Item
            label="Level Of Training"
            name="levelOfTrainningId"
            rules={[{ required: true, message: 'Please input!' }]}
          >
            <Select>
              <Select.Option value="1">Junior College</Select.Option>
              <Select.Option value="2">Bachelor</Select.Option>
              <Select.Option value="3">Above Bachelor</Select.Option>
            </Select>
          </Form.Item>
          <Form.Item
            label="Specialized Department"
            name="departmentId"
            rules={[{ required: true, message: 'Please input!' }]}
          >
            <Select>
              <Select.Option value="1">Math</Select.Option>
              <Select.Option value="2">Engineering</Select.Option>
              <Select.Option value="3">Computer Science</Select.Option>
              <Select.Option value="4">Mathematics</Select.Option>
              <Select.Option value="5">Science </Select.Option>
              <Select.Option value="6">Visual Arts</Select.Option>
              <Select.Option value="7">Media Arts</Select.Option>
              <Select.Option value="8">Performing Arts </Select.Option>
              <Select.Option value="9">World Languages</Select.Option>
              <Select.Option value="10">Business</Select.Option>
              <Select.Option value="11">Vocational </Select.Option>
              <Select.Option value="12">Special Education </Select.Option>
            </Select>
          </Form.Item>
          <Form.Item
            label="Professional Standards"
            name="professionalStandardsId"
            rules={[{ required: true, message: 'Please input!' }]}
          >
            <Select>
              <Select.Option value="1">Excellent</Select.Option>
              <Select.Option value="2">Good</Select.Option>
              <Select.Option value="3">Pass</Select.Option>
              <Select.Option value="4">Not Pass</Select.Option>
            </Select>
          </Form.Item>
        </Form>
      </Modal>

      {/* User Table */}
      <Table columns={columns} dataSource={users} />

      {/* User Detail Modal */}
      <Modal
        title={`${selectedUser?.firstName}${selectedUser?.lastName}'s Detail`}
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
            {/*<Form.Item label="Role">*/}
            {/*  <Select value={updatedRole} onChange={(value: string) => setUpdatedRole(value)}>*/}
            {/*    <Select.Option value="1">Admin</Select.Option>*/}
            {/*    <Select.Option value="2">Teacher</Select.Option>*/}
            {/*    <Select.Option value="3">Leader</Select.Option>*/}
            {/*    <Select.Option value="5">Principal</Select.Option>*/}
            {/*  </Select>*/}
            {/*</Form.Item>*/}
            <Form.Item label="Role">
              <Input
                value={
                  accountDetail
                    ? // Tìm tên tương ứng với roleId
                      {
                        '1': 'Admin',
                        '2': 'Teacher',
                        '3': 'Leader',
                        '5': 'Principal',
                      }[accountDetail.roleId]
                    : ''
                }
                disabled
              />
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
        title={`Are you sure you want to ${actionType} ${selectedUser?.lastName}?`}
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
        {`This action will ${actionType} ${selectedUser?.lastName}.`}
      </Modal>
    </div>
  );
};

export default Account;
