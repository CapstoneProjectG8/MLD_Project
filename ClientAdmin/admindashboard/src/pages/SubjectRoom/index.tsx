import type { FC } from 'react';

import { Button, Form, Input, message, Modal, Spin, Table } from 'antd';
import axios from 'axios';
import { useEffect, useState } from 'react';

interface SubjectRoomData {
  id: number;
  name: string;
}

interface CombinedData {
  key: number;
  index: number;
  name: string;
}

const SubjectRoom: FC = () => {
  const [subjectRooms, setSubjectRooms] = useState<SubjectRoomData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [combinedData, setCombinedData] = useState<CombinedData[]>([]);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [isEditModalVisible, setIsEditModalVisible] = useState<boolean>(false);
  const [editSubjectRoomId, setEditSubjectRoomId] = useState<number | null>(null);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchSubjectRooms = async () => {
      try {
        const subjectRoomResponse = await axios.get('https://localhost:7241/api/SubjectRoom');

        setSubjectRooms(subjectRoomResponse.data);
      } catch (error) {
        message.error('Failed to fetch subject rooms');
      } finally {
        setLoading(false);
      }
    };

    fetchSubjectRooms();
  }, []);

  useEffect(() => {
    if (subjectRooms.length > 0) {
      const data = subjectRooms.map((subjectRoom, index) => ({
        key: subjectRoom.id,
        index: index + 1,
        name: subjectRoom.name,
      }));

      setCombinedData(data);
    }
  }, [subjectRooms]);

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      await axios.post('https://localhost:7241/api/SubjectRoom', {
        name: values.name,
      });
      message.success('Subject room added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchSubjectRooms = async () => {
        const subjectRoomResponse = await axios.get('https://localhost:7241/api/SubjectRoom');

        setSubjectRooms(subjectRoomResponse.data);
      };

      fetchSubjectRooms();
    } catch (error) {
      message.error('Failed to add subject room');
    }
  };

  const handleEdit = (subjectRoomId: number) => {
    const subjectRoom = subjectRooms.find(room => room.id === subjectRoomId);

    if (subjectRoom) {
      form.setFieldsValue({
        name: subjectRoom.name,
      });
      setEditSubjectRoomId(subjectRoomId);
      setIsEditModalVisible(true);
    }
  };

  const handleEditSubmit = async (values: any) => {
    try {
      await axios.put(`https://localhost:7241/api/SubjectRoom/UpdateSubjectRoom/`, {
        id: editSubjectRoomId,
        name: values.name,
      });
      message.success('Subject room updated successfully');
      setIsEditModalVisible(false);
      form.resetFields();

      const fetchSubjectRooms = async () => {
        const subjectRoomResponse = await axios.get('https://localhost:7241/api/SubjectRoom');

        setSubjectRooms(subjectRoomResponse.data);
      };

      fetchSubjectRooms();
    } catch (error) {
      message.error('Failed to update subject room');
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
        Add Subject Room
      </Button>
      <Table columns={columns} dataSource={combinedData} loading={loading} />
      <Modal
        title="Add Subject Room"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item
            label="Name"
            name="name"
            rules={[{ required: true, message: 'Please input the subject room name!' }]}
          >
            <Input />
          </Form.Item>
        </Form>
      </Modal>
      <Modal
        title="Edit Subject Room"
        visible={isEditModalVisible}
        onCancel={() => setIsEditModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleEditSubmit}>
          <Form.Item
            label="Name"
            name="name"
            rules={[{ required: true, message: 'Please input the subject room name!' }]}
          >
            <Input />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default SubjectRoom;
