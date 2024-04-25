import type { Notice } from '@/interface/layout/notice.interface';
import React, { FC } from 'react';

import { LoadingOutlined } from '@ant-design/icons';
import {
  Avatar,
  Badge,
  Button,
  Col,
  Form,
  Input,
  List,
  Modal,
  Popover,
  Row,
  Select,
  Spin,
  Tabs,
  Tag,
  Tooltip,
} from 'antd';
import { useEffect, useState } from 'react';
import { useSelector } from 'react-redux';

import { getNoticeList } from '@/api/layout.api';
import { ReactComponent as NoticeSvg } from '@/assets/header/notice.svg';
import { EventStatus } from '@/interface/layout/notice.interface';
import { useLocale } from '@/locales';
import axios from 'axios';
import { string } from 'yup';

const antIcon = <LoadingOutlined style={{ fontSize: 24 }} spin />;

const { TabPane } = Tabs;

const HeaderNoticeComponent: FC = () => {
  const [visible, setVisible] = useState(false);
  const [noticeList, setNoticeList] = useState<Notice[]>([]);
  const [loading, setLoading] = useState(false);
  const { noticeCount } = useSelector(state => state.user);
  const { formatMessage } = useLocale();
  const [updatedStatus, setUpdatedStatus] = useState<boolean>(false);
  const noticeListFilter = <T extends Notice['type']>(type: T) => {
    return noticeList.filter(notice => notice.type === type) as Notice<T>[];
  };

  // loads the notices belonging to logged in user
  // and sets loading flag in-process
  const getNotice = async () => {
    setLoading(true);
    const { status, result } = await getNoticeList();

    setLoading(false);
    status && setNoticeList(result);
  };

  useEffect(() => {
    getNotice();
  }, []);
  const [selectedDocument, setSelectedDocument] = useState<Document | null>(null);
  const [modalVisible, setModalVisible] = useState<boolean>(false);
  const handViewFileModal = () => {
    if (selectedDocument?.linkFile) {
      window.open(selectedDocument.linkFile, '_blank');
    }
  };
  const handleDetail = (docId: string, index: string) => {
    axios.get<Document>('https://localhost:7241/api/Document1/ById/' + docId).then(res => {
      const doc = res.data;
      setSelectedDocument(doc);
      setModalVisible(true);
      setVisible(false);
      //Write api put Feedback in here, change read is boolean, requestBody = { id: selectedFB.id, userId: selectedFB.userId, docType: selectedFB.docType, docId: selectedFB.docId, read: selectedFB.read };
      //api Put: https://localhost:7241/api/Feedback
      // Assume selectedFB is an item from noticeList that you want to update
      const selectedFB = noticeList[index];
      const updatedNoticeList = [...noticeList]; // Tạo một bản sao của noticeList
      const noticeToUpdate = updatedNoticeList[index]; // Lấy phần tử cần cập nhật
      if (noticeToUpdate) {
        noticeToUpdate.read = true; // Cập nhật thuộc tính read thành true
        setNoticeList(updatedNoticeList); // Cập nhật noticeList mới
      }

      // Check if selectedFB exists
      if (selectedFB) {
        // Chuẩn bị dữ liệu cần gửi trong yêu cầu PUT
        const requestBody = {
          id: selectedFB.id,
          userId: selectedFB.userId,
          docType: selectedFB.docType,
          docId: selectedFB.docId,
          read: true
        };

        // Gửi yêu cầu PUT để cập nhật trạng thái read của phần tử trong danh sách Feedback
        axios.put('https://localhost:7241/api/Feedback', requestBody)
          .then(response => {
            console.log('Feedback updated successfully:', response.data);
          })
          .catch(error => {
            console.error('Error updating feedback:', error);
          });
      } else {
        console.error('Selected feedback not found.');
      }
    })
      .catch(error => {
        console.error('Error fetching document:', error);
      });
  };
  const [form] = Form.useForm();
  const handleCloseModal = () => {
    setModalVisible(false);
    form.resetFields();
  };
  const tabs = (
    <div>
      <Spin tip="Loading..." indicator={antIcon} spinning={loading}>
        <Tabs defaultActiveKey="1">
          <TabPane
            tab={`${formatMessage({
              id: 'app.notice.news',
            })}(${noticeListFilter('message').length})`}
            key="2"
          >
            <List
              dataSource={noticeListFilter('message')}
              renderItem={item => (
                !item.read ? (<List.Item>
                    <List.Item.Meta
                      avatar={<Avatar src={item.avatar} />}
                      title={<a onClick={() => handleDetail(item.docId, item.index)}>{item.title}</a>}
                      description={
                        <div className="notice-description">
                          <div className="notice-description-content">{item.description}</div>
                          <div className="notice-description-datetime">{item.datetime}</div>
                        </div>
                      }
                    />
                  </List.Item>) : (<List.Item>
                  <List.Item.Meta
                    avatar={<Avatar src={item.avatar} />}
                    title={<a onClick={() => handleDetail(item.docId, item.index)} style={{color:'gray'}}>{item.title}</a>}
                    description={
                      <div className="notice-description">
                        <div className="notice-description-content">{item.description}</div>
                        <div className="notice-description-datetime">{item.datetime}</div>
                      </div>
                    }
                  />
                </List.Item>)
              )}
            />
          </TabPane>
        </Tabs>
      </Spin>
    </div>
  );

  return (
    <>
      <Modal
        title="Document Details"
        visible={modalVisible}
        onCancel={handleCloseModal}
        width={1000}
        footer={[
          <Button key="view" type={'primary'} onClick={handViewFileModal}>View file</Button>,
          <Button key="update" onClick={handleCloseModal}>
            Close
          </Button>,
        ]}
      ><Form form={form} layout="vertical">
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
              <Select value={updatedStatus} onChange={(value: boolean) => setUpdatedStatus(value)}>
                <Option value={true}>Active</Option>
                <Option value={false}>Inactive</Option>
              </Select>
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
      </Form></Modal>
      <Popover
        content={tabs}
        overlayClassName="bg-2"
        placement="bottomRight"
        trigger={['click']}
        open={visible}
        onOpenChange={v => setVisible(v)}
        overlayStyle={{
          width: 336,
          height:500,
          overflow:'auto',
        }}
      >
        <Tooltip
          title={formatMessage({
            id: 'gloabal.tips.theme.noticeTooltip',
          })}
        >
          <Badge count={noticeCount} overflowCount={999}>
          <span className="notice" id="notice-center">
            <NoticeSvg className="anticon" />
          </span>
          </Badge>
        </Tooltip>
      </Popover>
    </>

  );
};

export default HeaderNoticeComponent;
