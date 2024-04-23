import React, { FC, useEffect, useRef, useState } from 'react';
import { Button, Col, Form, Input, message, Modal, Row, Space, Table, Typography } from 'antd';
import axios from 'axios';
import { CloseCircleOutlined, SearchOutlined } from '@ant-design/icons';
import { CheckCircleOutlined } from '@ant-design/icons/lib/icons';
import Highlighter from 'react-highlight-words';
const { Title, Paragraph } = Typography;

interface Document {
  id: string;
  name: string;
  document4_id: string;
  total: boolean;
  userId: string;
  slot: string;
  date: string;
  createdDate: string;
  linkFile: string;
  linkImage: string;
}

const DocumentationPage5: FC = () => {
  const [documents, setDocuments] = useState<Document[]>([]);
  const [selectedDocument, setSelectedDocument] = useState<Document | null>(null);
  const [modalVisible, setModalVisible] = useState<boolean>(false);
  const [form] = Form.useForm();
  const [actionToPerform, setActionToPerform] = useState('');
  const [selectedDoc, setSelectedDoc] = useState<Document | null>(null);
  const [confirmModalVisible, setConfirmModalVisible] = useState(false);
  const [searchText, setSearchText] = useState('');
  const [searchedColumn, setSearchedColumn] = useState('');
  const searchInput = useRef(null);
  const handleConfirmBanUnban = (doc: Document, action: string) => {
    setSelectedDoc(doc);
    setActionToPerform(action);
    setConfirmModalVisible(true);
  };
  useEffect(() => {
    fetch('https://localhost:7241/api/Document5')
      .then(response => response.json())
      .then(data => setDocuments(data))
      .catch(error => console.error('Error fetching data:', error));
  }, []);

  const handleDetail = (record: Document) => {
    setSelectedDocument(record);
    setModalVisible(true);
  };

  // const confirmBanUnban = async () => {
  //   try {
  //     const updatedDoc = { ...selectedDoc, status: !selectedDoc.status };
  //     const requestBody = { id: selectedDoc.id, document4_id:selectedDoc?.document4_id, userId: selectedDoc?.userId, status: updatedDoc.status };
  //     await axios.put(`https://localhost:7241/api/Document5`, requestBody);
  //     const updatedDocs = documents.map(u => (u.id === selectedDoc.id ? updatedDoc : u));
  //     setDocuments(updatedDocs);
  //     message.success(`User ${updatedDoc.status ? 'unbanned' : 'banned'} successfully.`);
  //   } catch (error) {
  //     console.error(error);
  //     message.error('Failed to update Doc.');
  //   } finally {
  //     setConfirmModalVisible(false);
  //   }
  // };

  const handleCloseModal = () => {
    setModalVisible(false);
    form.resetFields();
  };
  const handViewFileModal = () => {
    if (selectedDocument?.linkFile) {
      window.open(selectedDocument.linkFile, '_blank');
    }
  }
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
      ...getColumnSearchProps('name'),
      width: '500px',
      ellipsis: true,
    },
    {
      title: 'Slot',
      dataIndex: 'slot',
      key: 'slot',
    },
    {
      title: 'Mark',
      dataIndex: 'total',
      key: 'total',
      sorter: true,
    },
    {
      title: 'Created Date',
      dataIndex: 'date',
      key: 'date',sorter: (a, b) => {
        const dateA = new Date(a.createdDate);
        const dateB = new Date(b.createdDate);
        return dateA - dateB;
      },
    },
    {
      title: 'Action',
      key: 'action',
      render: (text: string, record: Document) => (
        <span>
          <Button onClick={() => handleDetail(record)}>Detail</Button>
          {/*<Button onClick={() => handleConfirmBanUnban(record, record.status ? 'ban' : 'unban')}>*/}
          {/*  {record.status ? 'Ban' : 'Unban'}*/}
          {/*</Button>*/}
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
                <Input value={selectedDocument?.document4_id} disabled />
              </Form.Item>
              <Form.Item label="Slot">
                <Input value={selectedDocument?.slot} disabled />
              </Form.Item>
              <Form.Item label="Mark">
                <Input value={selectedDocument?.total} disabled />
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
            </Col>
          </Row>
        </Form>
      </Modal>
      {/* Confirm Ban/Unban Modal */}
      {/*<Modal*/}
      {/*  title={`Are you sure you want to ${actionToPerform} ${selectedDoc?.name}?`}*/}
      {/*  visible={confirmModalVisible}*/}
      {/*  onCancel={() => setConfirmModalVisible(false)}*/}
      {/*  footer={[*/}
      {/*    <Button key="cancel" onClick={() => setConfirmModalVisible(false)}>*/}
      {/*      Cancel*/}
      {/*    </Button>,*/}
      {/*    <Button key="confirm" type="primary" onClick={confirmBanUnban}>*/}
      {/*      Confirm*/}
      {/*    </Button>,*/}
      {/*  ]}*/}
      {/*>*/}
      {/*  {`This action will ${actionToPerform} ${selectedDoc?.name}.`}*/}
      {/*</Modal>*/}
    </>
  );
};

export default DocumentationPage5;
