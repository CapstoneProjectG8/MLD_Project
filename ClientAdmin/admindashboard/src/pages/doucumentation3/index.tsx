import type { FC } from 'react';

import { Typography } from 'antd';

import { LocaleFormatter } from '@/locales';

const { Title, Paragraph } = Typography;

const div = <div style={{ height: 200 }}>2333</div>;

const DocumentationPage3: FC = () => {
  return (
    <div>
      <Typography className="innerText">
        <div>Doc 3</div>
      </Typography>
    </div>
  );
};

export default DocumentationPage3;