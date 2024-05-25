import type { FC } from 'react';

import { Button, Form, Input, message, Modal, Select, Spin, Table } from 'antd';
import axios from 'axios';
import { useEffect, useState } from 'react';

interface CurriculumData {
  id: number;
  name: string;
  subjectId: number;
}

interface SubjectData {
  id: number;
  name: string;
}

interface CombinedData {
  key: number;
  name: string;
  subjectName: string;
}

const Curriculum: FC = () => {
  const [curriculums, setCurriculums] = useState<CurriculumData[]>([]);
  const [subjects, setSubjects] = useState<SubjectData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [combinedData, setCombinedData] = useState<CombinedData[]>([]);
  const [editingCurriculum, setEditingCurriculum] = useState<CurriculumData | null>(null);
  const [isEditModalVisible, setIsEditModalVisible] = useState<boolean>(false);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchCurriculums = async () => {
      try {
        const curriculumResponse = await axios.get(
          'https://localhost:7241/api/CurriculumDistribution/GetAllCurriculums',
        );

        setCurriculums(curriculumResponse.data);
      } catch (error) {
        message.error('Failed to fetch curriculums');
      }
    };

    const fetchSubjects = async () => {
      try {
        const subjectResponse = await axios.get('https://localhost:7241/api/Subject');

        setSubjects(subjectResponse.data);
      } catch (error) {
        message.error('Failed to fetch subjects');
      }
    };

    const fetchData = async () => {
      setLoading(true);
      await Promise.all([fetchCurriculums(), fetchSubjects()]);
      setLoading(false);
    };

    fetchData();
  }, []);

  useEffect(() => {
    if (curriculums.length > 0 && subjects.length > 0) {
      const data = curriculums.map(curriculum => {
        const subject = subjects.find(sub => sub.id === curriculum.subjectId);

        return {
          key: curriculum.id,
          name: curriculum.name,
          subjectName: subject ? subject.name : 'Unknown',
        };
      });

      setCombinedData(data);
    }
  }, [curriculums, subjects]);

  const handleEdit = (record: CombinedData) => {
    const curriculum = curriculums.find(cur => cur.id === record.key);

    if (curriculum) {
      setEditingCurriculum(curriculum);
      form.setFieldsValue({
        name: curriculum.name,
        subjectId: curriculum.subjectId,
      });
      setIsEditModalVisible(true);
    }
  };

  const handleUpdate = async (values: any) => {
    if (editingCurriculum) {
      try {
        await axios.put('https://localhost:7241/api/CurriculumDistribution/UpdateCurriculumDistribution', {
          id: editingCurriculum.id,
          name: values.name,
          subjectId: values.subjectId,
        });
        message.success('Curriculum updated successfully');
        setIsEditModalVisible(false);
        setEditingCurriculum(null);
        form.resetFields();

        const fetchCurriculums = async () => {
          const curriculumResponse = await axios.get(
            'https://localhost:7241/api/CurriculumDistribution/GetAllCurriculums',
          );

          setCurriculums(curriculumResponse.data);
        };

        fetchCurriculums();
      } catch (error) {
        message.error('Failed to update curriculum');
      }
    }
  };

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      await axios.post('https://localhost:7241/api/CurriculumDistribution/AddCurriculum', {
        name: values.name,
        subjectId: values.subjectId,
      });
      message.success('Curriculum added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchCurriculums = async () => {
        const curriculumResponse = await axios.get(
          'https://localhost:7241/api/CurriculumDistribution/GetAllCurriculums',
        );

        setCurriculums(curriculumResponse.data);
      };

      fetchCurriculums();
    } catch (error) {
      message.error('Failed to add curriculum');
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
      title: 'Subject Name',
      dataIndex: 'subjectName',
      key: 'subjectName',
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
      <Button type="primary" onClick={handleAdd} style={{ marginBottom: 16 }}>
        Add Curriculum
      </Button>
      <Table columns={columns} dataSource={combinedData} />
      <Modal
        title="Edit Curriculum"
        visible={isEditModalVisible}
        onCancel={() => setIsEditModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleUpdate}>
          <Form.Item
            label="Name"
            name="name"
            rules={[{ required: true, message: 'Please input the curriculum name!' }]}
          >
            <Input />
          </Form.Item>
          <Form.Item label="Subject" name="subjectId" rules={[{ required: true, message: 'Please select a subject!' }]}>
            <Select>
              {subjects.map(subject => (
                <Select.Option key={subject.id} value={subject.id}>
                  {subject.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      </Modal>
      <Modal
        title="Add Curriculum"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item
            label="Name"
            name="name"
            rules={[{ required: true, message: 'Please input the curriculum name!' }]}
          >
            <Input />
          </Form.Item>
          <Form.Item label="Subject" name="subjectId" rules={[{ required: true, message: 'Please select a subject!' }]}>
            <Select>
              {subjects.map(subject => (
                <Select.Option key={subject.id} value={subject.id}>
                  {subject.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default Curriculum;
