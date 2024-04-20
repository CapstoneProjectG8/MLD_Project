import React, { useState } from 'react';
import { Upload, Button, message } from 'antd';
import { UploadOutlined } from '@ant-design/icons';
import axios from 'axios';

const UploadComponent: React.FC = () => {
  const [fileList, setFileList] = useState<any[]>([]);

  const handleUpload = async () => {
    const formData = new FormData();
    fileList.forEach((file) => {
      formData.append('files', file);
    });

    try {
      await axios.post('https://localhost:7241/api/S3FileUpload/upload', formData, {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      });
      console.log('FormData:', formData);
      message.success('Upload successful');
      setFileList([]);
    } catch (error) {
      message.error('Upload failed');
    }
  };

  const handleChange = (info: any) => {
    let fileList = [...info.fileList];

    // Limit the number of uploaded files
    fileList = fileList.slice(-3);

    setFileList(fileList);
  };

  return (
    <div>
      <Upload
        fileList={fileList}
        onChange={handleChange}
        multiple
        beforeUpload={() => false}
      >
        <Button icon={<UploadOutlined />}>Select Files</Button>
      </Upload>
      <Button
        type="primary"
        onClick={handleUpload}
        disabled={fileList.length === 0}
        style={{ marginTop: 16 }}
      >
        Upload
      </Button>
    </div>
  );
};

export default UploadComponent;
