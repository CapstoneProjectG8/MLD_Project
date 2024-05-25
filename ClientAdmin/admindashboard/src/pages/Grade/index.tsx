import type { FC } from 'react';

import { Button, Form, Input, message, Modal, Spin, Table } from 'antd';
import axios from 'axios';
import { useEffect, useState } from 'react';

interface GradeData {
  id: number;
  name: string;
}

interface CombinedData {
  key: number;
  index: number;
  name: string;
}

const Grade: FC = () => {
  const [grades, setGrades] = useState<GradeData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [combinedData, setCombinedData] = useState<CombinedData[]>([]);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [isEditModalVisible, setIsEditModalVisible] = useState<boolean>(false);
  const [editGradeId, setEditGradeId] = useState<number | null>(null);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchGrades = async () => {
      try {
        const gradeResponse = await axios.get('https://localhost:7241/api/Grade/GetAllGrades');

        setGrades(gradeResponse.data);
      } catch (error) {
        message.error('Failed to fetch grades');
      } finally {
        setLoading(false);
      }
    };

    fetchGrades();
  }, []);

  useEffect(() => {
    if (grades.length > 0) {
      const data = grades.map((grade, index) => ({
        key: grade.id,
        index: index + 1,
        name: grade.name,
      }));

      setCombinedData(data);
    }
  }, [grades]);

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      await axios.post('https://localhost:7241/api/Grade/AddGrade', {
        name: values.name,
      });
      message.success('Grade added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchGrades = async () => {
        const gradeResponse = await axios.get('https://localhost:7241/api/Grade/GetAllGrades');

        setGrades(gradeResponse.data);
      };

      fetchGrades();
    } catch (error) {
      message.error('Failed to add grade');
    }
  };

  const handleEdit = (gradeId: number) => {
    const grade = grades.find(gr => gr.id === gradeId);

    if (grade) {
      form.setFieldsValue({
        name: grade.name,
      });
      setEditGradeId(gradeId);
      setIsEditModalVisible(true);
    }
  };

  const handleEditSubmit = async (values: any) => {
    try {
      await axios.put(`https://localhost:7241/api/Grade/UpdateGrade`, {
        id: editGradeId,
        name: values.name,
      });
      message.success('Grade updated successfully');
      setIsEditModalVisible(false);
      form.resetFields();

      const fetchGrades = async () => {
        const gradeResponse = await axios.get('https://localhost:7241/api/Grade/GetAllGrades');

        setGrades(gradeResponse.data);
      };

      fetchGrades();
    } catch (error) {
      message.error('Failed to update grade');
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
        Add Grade
      </Button>
      <Table columns={columns} dataSource={combinedData} loading={loading} />
      <Modal
        title="Add Grade"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the grade name!' }]}>
            <Input />
          </Form.Item>
        </Form>
      </Modal>
      <Modal
        title="Edit Grade"
        visible={isEditModalVisible}
        onCancel={() => setIsEditModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleEditSubmit}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the grade name!' }]}>
            <Input />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default Grade;
