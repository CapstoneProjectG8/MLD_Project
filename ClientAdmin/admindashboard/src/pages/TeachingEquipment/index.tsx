import type { FC } from 'react';

import { Button, Form, Input, message, Modal, Spin, Table } from 'antd';
import axios from 'axios';
import { useEffect, useState } from 'react';

interface EquipmentData {
  id: number;
  name: string;
}

const Equipment: FC = () => {
  const [equipment, setEquipment] = useState<EquipmentData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [editingEquipment, setEditingEquipment] = useState<EquipmentData | null>(null);
  const [isEditModalVisible, setIsEditModalVisible] = useState<boolean>(false);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchEquipment = async () => {
      try {
        const equipmentResponse = await axios.get('https://localhost:7241/api/TeachingEquipment');

        setEquipment(equipmentResponse.data);
      } catch (error) {
        message.error('Failed to fetch equipment');
      } finally {
        setLoading(false);
      }
    };

    fetchEquipment();
  }, []);

  const handleEdit = (record: EquipmentData) => {
    setEditingEquipment(record);
    form.setFieldsValue({
      name: record.name,
    });
    setIsEditModalVisible(true);
  };

  const handleUpdate = async (values: any) => {
    if (editingEquipment) {
      try {
        await axios.put('https://localhost:7241/api/TeachingEquipment/UpdateTeachingEquipment', {
          id: editingEquipment.id,
          name: values.name,
        });
        message.success('Equipment updated successfully');
        setIsEditModalVisible(false);
        setEditingEquipment(null);
        form.resetFields();

        const fetchEquipment = async () => {
          const equipmentResponse = await axios.get('https://localhost:7241/api/TeachingEquipment');

          setEquipment(equipmentResponse.data);
        };

        fetchEquipment();
      } catch (error) {
        message.error('Failed to update equipment');
      }
    }
  };

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      await axios.post('https://localhost:7241/api/TeachingEquipment/AddTeachingEquipment', {
        name: values.name,
      });
      message.success('Equipment added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchEquipment = async () => {
        const equipmentResponse = await axios.get('https://localhost:7241/api/TeachingEquipment');

        setEquipment(equipmentResponse.data);
      };

      fetchEquipment();
    } catch (error) {
      message.error('Failed to add equipment');
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
      title: 'Action',
      key: 'action',
      render: (_: any, record: EquipmentData) => (
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
        Add Equipment
      </Button>
      <Table columns={columns} dataSource={equipment.map(e => ({ ...e, key: e.id }))} />
      <Modal
        title="Edit Equipment"
        visible={isEditModalVisible}
        onCancel={() => setIsEditModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleUpdate}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the equipment name!' }]}>
            <Input />
          </Form.Item>
        </Form>
      </Modal>
      <Modal
        title="Add Equipment"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item label="Name" name="name" rules={[{ required: true, message: 'Please input the equipment name!' }]}>
            <Input />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
};

export default Equipment;
