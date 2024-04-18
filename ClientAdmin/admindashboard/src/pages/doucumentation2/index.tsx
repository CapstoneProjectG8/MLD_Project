import { FC, useEffect, useState } from 'react';
import React from 'react';
import { InboxOutlined } from '@ant-design/icons';
import type { UploadProps } from 'antd';
import { message, Upload } from 'antd';
import { Typography } from 'antd';

import { LocaleFormatter } from '@/locales';
import axios from 'axios';

const { Title, Paragraph } = Typography;

const div = <div style={{ height: 200 }}>2333</div>;
const { Dragger } = Upload;

const props: UploadProps = {
  name: 'file',
  multiple: true,
  action: 'https://localhost:7241/api/S3FileUpload/upload?prefix=doc2%2F',
  onChange(info) {
    const { status } = info.file;
    if (status !== 'uploading') {
      console.log(info.file, info.fileList);
    }
    if (status === 'done') {
      message.success(`${info.file.name} file uploaded successfully.`);
    } else if (status === 'error') {
      message.error(`${info.file.name} file upload failed.`);
    }
  },
  onDrop(e) {
    console.log('Dropped files', e.dataTransfer.files);
  },
};
const DocumentationPage2: FC = () => {
  const [documentList, setDocumentList] = useState<string[]>([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('https://localhost:7241/api/S3FileUpload', {
          params: { prefix: 'doc2/' }
        });
        setDocumentList(response.data.fileUrls); // Assuming the API response contains an array of file URLs
      } catch (error) {
        console.error('Error fetching document list:', error);
      }
    };

    fetchData();
  }, []);
  return (
    <Dragger {...props}>
      <p className="ant-upload-drag-icon">
        <InboxOutlined />
      </p>
      <p className="ant-upload-text">Click or drag file to this area to upload</p>
      <p className="ant-upload-hint">
        Support for a single or bulk upload. Strictly prohibited from uploading company data or other
        banned files.
      </p>
    </Dragger>
  );
};

export default DocumentationPage2;
