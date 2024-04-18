import React, { FC, useEffect, useState } from 'react';
import { Button, Col, Form, Input, Modal, Row, Table, Typography } from 'antd';

const { Title, Paragraph } = Typography;

interface Document {
  id: string;
  name: string;
  note: string;
  status: boolean;
  isApprove: boolean;
  createdDate: string;
  linkFile: string;
  linkImage: string;
  otherTasks: string;
  approveByName: string;
  userName: string;
  subjectName: string;
  gradeName: string;
}

const DocumentationPage1: FC = () => {
  const [documents, setDocuments] = useState<Document[]>([]);
  const [selectedDocument, setSelectedDocument] = useState<Document | null>(null);
  const [modalVisible, setModalVisible] = useState<boolean>(false);
  const [form] = Form.useForm();

  useEffect(() => {
    fetch('https://localhost:7241/api/Document1')
      .then(response => response.json())
      .then(data => setDocuments(data))
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  const handleDetail = (record: Document) => {
    setSelectedDocument(record);
    setModalVisible(true);
  };

  const handleConfirmBanUnban = (record: Document, action: 'ban' | 'unban') => {
    // Thay đổi trạng thái của boolean status true/false
    const updatedDocuments = documents.map(doc => {
      if (doc.id === record.id) {
        return {
          ...doc,
          status: action === 'ban' ? false : true,
        };
      }
      return doc;
    });
    setDocuments(updatedDocuments);
  };

  const handleCloseModal = () => {
    setModalVisible(false);
    form.resetFields();
  };
  const handViewFileModal = () => {
    if (selectedDocument?.linkFile) {
      window.open(selectedDocument.linkFile, '_blank');
    }
  }
  const columns = [
    {
      title: 'Index',
      dataIndex: 'index',
      key: 'index',
      width: '70px',
      render: (text, record, index) => index + 1,
    },
    {
      title: 'Name',
      dataIndex: 'name',
      key: 'name',
      width: '500px',
      ellipsis: true,
    },
    {
      title: 'User Name',
      dataIndex: 'userName',
      key: 'userName',
    },
    {
      title: 'Is Approve',
      dataIndex: 'isApprove',
      key: 'isApprove',
      render: isApprove => (isApprove ? 'Yes' : 'No'),
    },
    {
      title: 'Status',
      dataIndex: 'status',
      key: 'status',
      render: status => (status ? 'Active' : 'Inactive'),
    },
    {
      title: 'Created Date',
      dataIndex: 'createdDate',
      key: 'createdDate',
    },
    {
      title: 'Action',
      key: 'action',
      render: (text: string, record: Document) => (
        <span>
          <Button onClick={() => handleDetail(record)}>Detail</Button>
          <Button onClick={() => handleConfirmBanUnban(record, record.status ? 'ban' : 'unban')}>
            {record.status ? 'Ban' : 'Unban'}
          </Button>
        </span>
      ),
    },
  ];

  return (
    <>
      <Table columns={columns} dataSource={documents} rowKey="id" />

      <Modal
        title="Document Details"
        visible={modalVisible}
        onCancel={handleCloseModal}
        width={1000}
        footer={[
          <Button key="submit" onClick={handViewFileModal}>View file</Button>,
          <Button key="cancel" onClick={handleCloseModal}>
            Close
          </Button>
        ]}
      >
        <Form form={form} layout="vertical">
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item label="ID">
                <Input value={selectedDocument?.id} disabled />
              </Form.Item>
              <Form.Item label="Name">
                <Input value={selectedDocument?.name} disabled />
              </Form.Item>
              <Form.Item label="Note">
                <Input value={selectedDocument?.note} disabled />
              </Form.Item>
              <Form.Item label="Status">
                <Input value={selectedDocument?.status ? 'Active' : 'Inactive'} disabled />
              </Form.Item>
              <Form.Item label="Is Approve">
                <Input value={selectedDocument?.isApprove ? 'Yes' : 'No'} disabled />
              </Form.Item>
              <Form.Item label="Created Date">
                <Input value={selectedDocument?.createdDate} disabled />
              </Form.Item>
              <Form.Item label="Link File">
                <Input value={selectedDocument?.linkFile} disabled />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item label="Link Image">
                <Input value={selectedDocument?.linkImage} disabled />
              </Form.Item>
              <Form.Item label="Other Tasks">
                <Input value={selectedDocument?.otherTasks} disabled />
              </Form.Item>
              <Form.Item label="Approve By Name">
                <Input value={selectedDocument?.approveByName} disabled />
              </Form.Item>
              <Form.Item label="User Name">
                <Input value={selectedDocument?.userName} disabled />
              </Form.Item>
              <Form.Item label="Subject Name">
                <Input value={selectedDocument?.subjectName} disabled />
              </Form.Item>
              <Form.Item label="Grade Name">
                <Input value={selectedDocument?.gradeName} disabled />
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Modal>
    </>
  );
};

export default DocumentationPage1;
