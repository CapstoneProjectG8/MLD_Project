import React, { FC, useEffect, useRef, useState } from 'react';
import axios from 'axios';
import { Button, DatePicker, Form, Input, message, Modal, Radio, Select, Space, Table } from 'antd';
import { CheckCircleOutlined } from '@ant-design/icons/lib/icons';
import { CloseCircleOutlined, SearchOutlined } from '@ant-design/icons';
import Highlighter from 'react-highlight-words';
interface User {
  id: string;
  fullName: string;
  email: string;
  placeOfBirth: string;
  gender: boolean;
  active: boolean;
  createdDate: string;
  accountId: string;
  address: string;
  photo: string;
  levelOfTrainningId: string;
  specializedDepartmentId: string;
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
  const [searchText, setSearchText] = useState('');
  const [searchedColumn, setSearchedColumn] = useState('');
  const searchInput = useRef(null);
  useEffect(() => {
    axios.get('https://localhost:7241/api/User')
      .then(response => {
        const formattedUsers = response.data.map((user: any, index: number) => ({
          key: index.toString(),
          id: user.id,
          fullName: user.fullName,
          email: user.email,
          active: user.active,
          gender: user.gender,
          createdDate: user.createdDate,
          placeOfBirth: user.placeOfBirth,
          accountId: user.accountId,
          address: user.address,
          photo: user.photo,
          levelOfTrainningId: user.levelOfTrainningId,
          specializedDepartmentId: user.specializedDepartmentId,
          professionalStandardsId: user.professionalStandardsId,
        }));
        setUsers(formattedUsers);
      })
      .catch(error => {
        console.error(error);
      });
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
      const updatedUser1 = { ...selectedUser, active: !selectedUser.active };
      const requestBody = { id: selectedUser.id, accountId: selectedUser.accountId, active: updatedUser1.active };
      await axios.put(`https://localhost:7241/api/User/${selectedUser.id}`, requestBody);
      const updatedUsers1 = users.map(u => (u.id === selectedUser.id ? updatedUser1 : u));
      setUsers(updatedUsers1);
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
      const requestBody = { id: selectedUser.id, accountId: selectedUser.accountId, active: updatedUser.active };
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
  const handleSearch = (selectedKeys, confirm, dataIndex) => {
    confirm();
    setSearchText(selectedKeys[0]);
    setSearchedColumn(dataIndex);
  };

  const handleReset = (clearFilters) => {
    clearFilters();
    setSearchText('');
  };

  const getColumnSearchProps = (dataIndex) => ({
    filterDropdown: ({setSelectedKeys, selectedKeys, confirm, clearFilters}) => (
      <div style={{padding: 8}}>
        <Input
          ref={searchInput}
          placeholder={`Search ${dataIndex}`}
          value={selectedKeys[0]}
          onChange={(e) => setSelectedKeys(e.target.value ? [e.target.value] : [])}
          onPressEnter={() => handleSearch(selectedKeys, confirm, dataIndex)}
          style={{width: 188, marginBottom: 8, display: 'block'}}
        />
        <Space>
          <Button
            type="primary"
            onClick={() => handleSearch(selectedKeys, confirm, dataIndex)}
            icon={<SearchOutlined/>}
            size="small"
            style={{width: 90}}
          >
            Search
          </Button>
          <Button onClick={() => handleReset(clearFilters)} size="small" style={{width: 90}}>
            Reset
          </Button>
        </Space>
      </div>
    ),
    filterIcon: (filtered) => <SearchOutlined style={{color: filtered ? '#1890ff' : undefined}}/>,
    onFilter: (value, record) =>
      record[dataIndex] ? record[dataIndex].toString().toLowerCase().includes(value.toLowerCase()) : '',
    onFilterDropdownVisibleChange: (visible) => {
      if (visible) {
        setTimeout(() => searchInput.current.select(), 100);
      }
    },
    render: (text) =>
      searchedColumn === dataIndex ? (
        <Highlighter
          highlightStyle={{backgroundColor: '#ffc069', padding: 0}}
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
      title: 'Full Name',
      dataIndex: 'fullName',
      key: 'fullName',
      ...getColumnSearchProps('fullName'),
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
      ...getColumnFilterGender('gender', [
        {text: 'Male', value: true},
        {text: 'Female', value: false},
      ]),
    },
    {
      title: 'Active',
      dataIndex: 'active',
      key: 'active',
      align: "center",
      ...getColumnFilterStatus('active', [
        {text: 'Active', value: true},
        {text: 'Inactive', value: false},
      ]),
      render: (active: boolean) => (active ? <CheckCircleOutlined style={{color: "green"}}/> : <CloseCircleOutlined style={{color: "red"}}/>),
    },
    {
      title: 'Created Date',
      dataIndex: 'createdDate',
      key: 'createdDate',
      sorter: (a, b) => {
        const dateA = new Date(a.createdDate);
        const dateB = new Date(b.createdDate);
        return dateA - dateB;
      },
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
          <Form.Item label="First Name" name="firstName"
                     rules={[{ required: true, message: 'Please input your first name!' }]}>
            <Input />
          </Form.Item>
          <Form.Item label="Last Name" name="lastName"
                     rules={[{ required: true, message: 'Please input your last name!' }]}>
            <Input />
          </Form.Item>
          <Form.Item label="Email" name="email"
                     rules={[{ required: true, type: 'email', message: 'Please input a valid email address!' }]}>
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
          <Form.Item
            label="Birth"
            name="placeOfBirth"
            rules={[{ required: true, message: 'Please input your date of birth!' }]}
          >
            <DatePicker />
          </Form.Item>
          <Form.Item label="Level Of Training" name="levelOfTrainningId"
                     rules={[{ required: true, message: 'Please input!' }]}>
            <Select>
              <Select.Option value="1">Junior College</Select.Option>
              <Select.Option value="2">Bachelor</Select.Option>
              <Select.Option value="3">Above Bachelor</Select.Option>
            </Select>
          </Form.Item>
          <Form.Item label="Specialized Department" name="specializedDepartmentId"
                     rules={[{ required: true, message: 'Please input!' }]}>
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
          <Form.Item label="Professional Standards" name="professionalStandardsId"
                     rules={[{ required: true, message: 'Please input!' }]}>
            <Select>
              <Select.Option value="1">Excellent</Select.Option>
              <Select.Option value="2">Good</Select.Option>
              <Select.Option value="3">Pass</Select.Option>
              <Select.Option value="4">Not Pass</Select.Option>
            </Select>
          </Form.Item>
          <Form.Item label="Account ID" name="accountId" hidden>
            <Input value={newUserData.accountId} disabled />
          </Form.Item>
          <Form.Item label="Active" name="active" hidden initialValue={true}>
            <Input value={newUserData.active} disabled />
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
            {/*<Form.Item label="Role">*/}
            {/*  <Select value={updatedRole} onChange={(value: string) => setUpdatedRole(value)}>*/}
            {/*    <Select.Option value="1">Admin</Select.Option>*/}
            {/*    <Select.Option value="2">Teacher</Select.Option>*/}
            {/*    <Select.Option value="3">Leader</Select.Option>*/}
            {/*    <Select.Option value="5">Principal</Select.Option>*/}
            {/*  </Select>*/}
            {/*</Form.Item>*/}
            <Form.Item label="Role">
              <Input value={
                accountDetail ? (
                  // Tìm tên tương ứng với roleId
                  {
                    '1': 'Admin',
                    '2': 'Teacher',
                    '3': 'Leader',
                    '5': 'Principal',
                  }[accountDetail.roleId]
                ) : ''
              } disabled />
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
