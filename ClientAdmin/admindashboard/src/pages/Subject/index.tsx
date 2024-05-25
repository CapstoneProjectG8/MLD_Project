import type { FC } from 'react';

import { Button, Form, Input, message, Modal, Select, Spin, Table } from 'antd';
import axios from 'axios';
import React, { useEffect, useState } from 'react';

interface SubjectData {
  id: number;
  name: string;
  departmentId: number;
}

interface DepartmentData {
  id: number;
  name: string;
}

interface CombinedData {
  key: number;
  index: number;
  name: string;
  departmentName: string;
}

const Subject: FC = () => {
  const [subjects, setSubjects] = useState<SubjectData[]>([]);
  const [departments, setDepartments] = useState<DepartmentData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [combinedData, setCombinedData] = useState<CombinedData[]>([]);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [isEditModalVisible, setIsEditModalVisible] = useState<boolean>(false);
  const [editSubjectId, setEditSubjectId] = useState<number | null>(null);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchSubjects = async () => {
      try {
        const subjectResponse = await axios.get('https://localhost:7241/api/Subject');

        setSubjects(subjectResponse.data);
      } catch (error) {
        message.error('Failed to fetch subjects');
      }
    };

    const fetchDepartments = async () => {
      try {
        const departmentResponse = await axios.get('https://localhost:7241/api/SpecializedDepartment');

        setDepartments(departmentResponse.data);
      } catch (error) {
        message.error('Failed to fetch departments');
      }
    };

    const fetchData = async () => {
      setLoading(true);
      await Promise.all([fetchSubjects(), fetchDepartments()]);
      setLoading(false);
    };

    fetchData();
  }, []);

  useEffect(() => {
    if (subjects.length > 0 && departments.length > 0) {
      const data = subjects.map((subject, index) => {
        const department = departments.find(dep => dep.id === subject.departmentId);

        return {
          key: subject.id,
          index: index + 1,
          name: subject.name,
          departmentName: department ? department.name : 'Unknown',
        };
      });

      setCombinedData(data);
    }
  }, [subjects, departments]);

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      await axios.post('https://localhost:7241/api/Subject/AddSubject', {
        name: values.name,
        departmentId: values.departmentId,
      });
      message.success('Subject added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchSubjects = async () => {
        const subjectResponse = await axios.get('https://localhost:7241/api/Subject');

        setSubjects(subjectResponse.data);
      };

      fetchSubjects();
    } catch (error) {
      message.error('Failed to add subject');
    }
  };

  const handleEdit = (subjectId: number) => {
    const subject = subjects.find(sub => sub.id === subjectId);

    if (subject) {
      form.setFieldsValue({
        name: subject.name,
        departmentId: subject.departmentId,
      });
      setEditSubjectId(subjectId);
      setIsEditModalVisible(true);
    }
  };

  const handleEditSubmit = async (values: any) => {
    try {
      await axios.put('https://localhost:7241/api/Subject/UpdateSubject', {
        id: editSubjectId,
        name: values.name,
        departmentId: values.departmentId,
      });
      message.success('Subject updated successfully');
      setIsEditModalVisible(false);
      form.resetFields();

      const fetchSubjects = async () => {
        const subjectResponse = await axios.get('https://localhost:7241/api/Subject');

        setSubjects(subjectResponse.data);
      };

      fetchSubjects();
    } catch (error) {
      message.error('Failed to update subject');
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
      title: 'Department',
      dataIndex: 'departmentName',
      key: 'departmentName',
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
        Add Subject
      </Button>
      <Table columns={columns} dataSource={combinedData} loading={loading} />
      <Modal
        title="Add Subject"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the subject name!' }]}>
            <Input />
          </Form.Item>
          <Form.Item
            label="Department"
            name="departmentId"
            rules={[{ required: true, message: 'Please select a department!' }]}
          >
            <Select>
              {departments.map(dep => (
                <Select.Option key={dep.id} value={dep.id}>
                  {dep.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      </Modal>
      <Modal
        title="Edit Subject"
        visible={isEditModalVisible}
        onCancel={() => setIsEditModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleEditSubmit}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the subject name!' }]}>
            <Input />
          </Form.Item>
          <Form.Item
            label="Department"
            name="departmentId"
            rules={[{ required: true, message: 'Please select a department!' }]}
          >
            <Select>
              {departments.map(dep => (
                <Select.Option key={dep.id} value={dep.id}>
                  {dep.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default Subject;
