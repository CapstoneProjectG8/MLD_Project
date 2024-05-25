import type { FC } from 'react';

import { Button, Form, Input, message, Modal, Select, Spin, Table } from 'antd';
import axios from 'axios';
import { useEffect, useState } from 'react';

interface ClassData {
  id: number;
  name: string;
  totalStudent: number;
  gradeId: number;
}

interface GradeData {
  id: number;
  name: string;
}

interface CombinedData {
  key: number;
  name: string;
  totalStudent: number;
  gradeName: string;
}

const Class: FC = () => {
  const [classes, setClasses] = useState<ClassData[]>([]);
  const [grades, setGrades] = useState<GradeData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [combinedData, setCombinedData] = useState<CombinedData[]>([]);
  const [editingClass, setEditingClass] = useState<ClassData | null>(null);
  const [isModalVisible, setIsModalVisible] = useState<boolean>(false);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchClasses = async () => {
      try {
        const classResponse = await axios.get('https://localhost:7241/api/Class/GetAllClasses');

        setClasses(classResponse.data);
      } catch (error) {
        message.error('Failed to fetch classes');
      }
    };

    const fetchGrades = async () => {
      try {
        const gradeResponse = await axios.get('https://localhost:7241/api/Grade/GetAllGrades');

        setGrades(gradeResponse.data);
      } catch (error) {
        message.error('Failed to fetch grades');
      }
    };

    const fetchData = async () => {
      setLoading(true);
      await Promise.all([fetchClasses(), fetchGrades()]);
      setLoading(false);
    };

    fetchData();
  }, []);

  useEffect(() => {
    if (classes.length > 0 && grades.length > 0) {
      const data = classes.map(cls => {
        const grade = grades.find(gr => gr.id === cls.gradeId);

        return {
          key: cls.id,
          name: cls.name,
          totalStudent: cls.totalStudent,
          gradeName: grade ? grade.name : 'Unknown',
        };
      });

      setCombinedData(data);
    }
  }, [classes, grades]);

  const handleEdit = (record: CombinedData) => {
    const cls = classes.find(c => c.id === record.key);

    if (cls) {
      setEditingClass(cls);
      form.setFieldsValue({
        name: cls.name,
        totalStudent: cls.totalStudent,
        gradeId: cls.gradeId,
      });
      setIsModalVisible(true);
    }
  };

  const handleUpdate = async (values: any) => {
    if (editingClass) {
      try {
        await axios.put('https://localhost:7241/api/Class/UpdateClass', {
          id: editingClass.id,
          name: values.name,
          totalStudent: values.totalStudent,
          gradeId: values.gradeId,
        });
        message.success('Class updated successfully');
        setIsModalVisible(false);
        setEditingClass(null);
        form.resetFields();

        const fetchClasses = async () => {
          const classResponse = await axios.get('https://localhost:7241/api/Class/GetAllClasses');

          setClasses(classResponse.data);
        };

        fetchClasses();
      } catch (error) {
        message.error('Failed to update class');
      }
    }
  };

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      await axios.post('https://localhost:7241/api/Class/AddClass', {
        name: values.name,
        totalStudent: values.totalStudent,
        gradeId: values.gradeId,
      });
      message.success('Class added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchClasses = async () => {
        const classResponse = await axios.get('https://localhost:7241/api/Class/GetAllClasses');

        setClasses(classResponse.data);
      };

      fetchClasses();
    } catch (error) {
      message.error('Failed to add class');
    }
  };

  const columns = [
    {
      title: '#',
      dataIndex: 'index',
      key: 'index',
      render: (_: any, record: any, index: number) => index + 1,
    },
    {
      title: 'Name',
      dataIndex: 'name',
      key: 'name',
    },
    {
      title: 'Total Student',
      dataIndex: 'totalStudent',
      key: 'totalStudent',
    },
    {
      title: 'Grade Name',
      dataIndex: 'gradeName',
      key: 'gradeName',
    },
    {
      title: 'Action',
      key: 'action',
      render: (_: any, record: CombinedData) => (
        <Button type="link" onClick={() => handleEdit(record)}>
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
      <Button type="primary" onClick={handleAdd}>
        Add Class
      </Button>
      <Table columns={columns} dataSource={combinedData} />
      <Modal
        title="Edit Class"
        visible={isModalVisible}
        onCancel={() => setIsModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleUpdate}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the class name!' }]}>
            <Input />
          </Form.Item>
          <Form.Item
            label="Total Student"
            name="totalStudent"
            rules={[{ required: true, message: 'Please input the total number of students!' }]}
          >
            <Input type="number" />
          </Form.Item>
          <Form.Item label="Grade" name="gradeId" rules={[{ required: true, message: 'Please select a grade!' }]}>
            <Select>
              {grades.map(grade => (
                <Select.Option key={grade.id} value={grade.id}>
                  {grade.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      </Modal>
      <Modal
        title="Add Class"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the class name!' }]}>
            <Input />
          </Form.Item>
          <Form.Item
            label="Total Student"
            name="totalStudent"
            rules={[{ required: true, message: 'Please input the total number of students!' }]}
          >
            <Input type="number" />
          </Form.Item>
          <Form.Item label="Grade" name="gradeId" rules={[{ required: true, message: 'Please select a grade!' }]}>
            <Select>
              {grades.map(grade => (
                <Select.Option key={grade.id} value={grade.id}>
                  {grade.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default Class;
