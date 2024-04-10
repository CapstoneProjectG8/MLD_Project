import type { FC } from 'react';

import { Typography } from 'antd';

import { LocaleFormatter } from '@/locales';

const { Title, Paragraph } = Typography;

const div = <div style={{ height: 200 }}>2333</div>;

const DocumentationPage5: FC = () => {
  return (
    <div>
      <Typography className="innerText">
        <div>Doc 5</div>
      </Typography>
    </div>
  );
};

export default DocumentationPage5;
