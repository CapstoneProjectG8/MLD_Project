import type { FC } from 'react';

import { Button, Form, Input, message, Modal, Spin, Table } from 'antd';
import axios from 'axios';
import { useEffect, useState } from 'react';

interface DepartmentData {
  id: number;
  name: string;
}

interface CombinedData {
  key: number;
  index: number;
  name: string;
}

const Departmemt: FC = () => {
  const [departments, setDepartments] = useState<DepartmentData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [combinedData, setCombinedData] = useState<CombinedData[]>([]);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [isEditModalVisible, setIsEditModalVisible] = useState<boolean>(false);
  const [editDepartmentId, setEditDepartmentId] = useState<number | null>(null);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchDepartments = async () => {
      try {
        const departmentResponse = await axios.get('https://localhost:7241/api/SpecializedDepartment');

        setDepartments(departmentResponse.data);
      } catch (error) {
        message.error('Failed to fetch departments');
      } finally {
        setLoading(false);
      }
    };

    fetchDepartments();
  }, []);

  useEffect(() => {
    if (departments.length > 0) {
      const data = departments.map((department, index) => ({
        key: department.id,
        index: index + 1,
        name: department.name,
      }));

      setCombinedData(data);
    }
  }, [departments]);

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      await axios.post('https://localhost:7241/api/SpecializedDepartment', {
        name: values.name,
      });
      message.success('Department added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchDepartments = async () => {
        const departmentResponse = await axios.get('https://localhost:7241/api/SpecializedDepartment');

        setDepartments(departmentResponse.data);
      };

      fetchDepartments();
    } catch (error) {
      message.error('Failed to add department');
    }
  };

  const handleEdit = (departmentId: number) => {
    const department = departments.find(dep => dep.id === departmentId);

    if (department) {
      form.setFieldsValue({
        name: department.name,
      });
      setEditDepartmentId(departmentId);
      setIsEditModalVisible(true);
    }
  };

  const handleEditSubmit = async (values: any) => {
    try {
      await axios.put(`https://localhost:7241/api/SpecializedDepartment/UpdateSpecializedDepartment`, {
        id: editDepartmentId,
        name: values.name,
      });
      message.success('Department updated successfully');
      setIsEditModalVisible(false);
      form.resetFields();

      const fetchDepartments = async () => {
        const departmentResponse = await axios.get('https://localhost:7241/api/SpecializedDepartment');

        setDepartments(departmentResponse.data);
      };

      fetchDepartments();
    } catch (error) {
      message.error('Failed to update department');
    }
  };

  const columns = [
    {
      title: 'Index',
      dataIndex: 'index',
      key: 'index',
    },
    {
      title: 'Name',
      dataIndex: 'name',
      key: 'name',
    },
    {
      title: 'Action',
      key: 'action',
      render: (_: any, record: any) => (
        <Button type="link" onClick={() => handleEdit(record.key)}>
          Edit
        </Button>
      ),
    },
  ];

  if (loading) {
    return <Spin />;
  }

  return (
    <div style={{ padding: '20px' }}>
      <Button type="primary" onClick={handleAdd} style={{ marginBottom: 16 }}>
        Add Department
      </Button>
      <Table columns={columns} dataSource={combinedData} loading={loading} />
      <Modal
        title="Add Department"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item
            label="Name"
            name="name"
            rules={[{ required: true, message: 'Please input the department name!' }]}
          >
            <Input />
          </Form.Item>
        </Form>
      </Modal>
      <Modal
        title="Edit Department"
        visible={isEditModalVisible}
        onCancel={() => setIsEditModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleEditSubmit}>
          <Form.Item
            label="Name"
            name="name"
            rules={[{ required: true, message: 'Please input the department name!' }]}
          >
            <Input />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default Departmemt;
