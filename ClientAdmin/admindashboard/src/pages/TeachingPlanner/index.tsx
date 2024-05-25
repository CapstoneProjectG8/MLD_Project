import type { FC } from 'react';

import { useEffect, useState } from 'react';

interface PlannerData {
  id: number;
  userId: number;
  classId: number;
  subjectId: number;
}

interface UserData {
  id: number;
  firstName: string;
  lastName: string;
}

interface ClassData {
  id: number;
  name: string;
}

interface SubjectData {
  id: number;
  name: string;
}

interface CombinedData {
  key: number;
  index: number;
  teacher: string;
  className: string;
  subjectName: string;
}
import { Button, Form, message, Modal, Select, Spin, Table } from 'antd';
import axios from 'axios';

const Planner: FC = () => {
  const [planners, setPlanners] = useState<PlannerData[]>([]);
  const [users, setUsers] = useState<UserData[]>([]);
  const [classes, setClasses] = useState<ClassData[]>([]);
  const [subjects, setSubjects] = useState<SubjectData[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [combinedData, setCombinedData] = useState<CombinedData[]>([]);
  const [isAddModalVisible, setIsAddModalVisible] = useState<boolean>(false);
  const [form] = Form.useForm();

  useEffect(() => {
    const fetchPlanners = async () => {
      try {
        const plannerResponse = await axios.get('https://localhost:7241/api/TeachingPlanner');

        setPlanners(plannerResponse.data);
      } catch (error) {
        message.error('Failed to fetch planners');
      }
    };

    const fetchUsers = async () => {
      try {
        const userResponse = await axios.get('https://localhost:7241/api/User/GetAllUsers');

        setUsers(userResponse.data);
      } catch (error) {
        message.error('Failed to fetch users');
      }
    };

    const fetchClasses = async () => {
      try {
        const classResponse = await axios.get('https://localhost:7241/api/Class/GetAllClasses');

        setClasses(classResponse.data);
      } catch (error) {
        message.error('Failed to fetch classes');
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
      await Promise.all([fetchPlanners(), fetchUsers(), fetchClasses(), fetchSubjects()]);
      setLoading(false);
    };

    fetchData();
  }, []);

  useEffect(() => {
    if (planners.length > 0 && users.length > 0 && classes.length > 0 && subjects.length > 0) {
      const data = planners.map((planner, index) => {
        const user = users.find(user => user.id === planner.userId);
        const classItem = classes.find(cls => cls.id === planner.classId);
        const subject = subjects.find(sub => sub.id === planner.subjectId);

        return {
          key: planner.id,
          index: index + 1,
          teacher: user ? `${user.firstName} ${user.lastName}` : 'Unknown',
          className: classItem ? classItem.name : 'Unknown',
          subjectName: subject ? subject.name : 'Unknown',
        };
      });

      setCombinedData(data);
    }
  }, [planners, users, classes, subjects]);

  const handleAdd = () => {
    form.resetFields();
    setIsAddModalVisible(true);
  };

  const handleAddSubmit = async (values: any) => {
    try {
      const { userId, subjectId, classId } = values;

      await axios.post(
        `https://localhost:7241/api/TeachingPlanner?userId=${userId}&subjectId=${subjectId}&classId=${classId}`,
      );
      message.success('Planner added successfully');
      setIsAddModalVisible(false);
      form.resetFields();

      const fetchPlanners = async () => {
        const plannerResponse = await axios.get('https://localhost:7241/api/TeachingPlanner');

        setPlanners(plannerResponse.data);
      };

      fetchPlanners();
    } catch (error) {
      message.error('Failed to add planner');
    }
  };

  const columns = [
    {
      title: 'Index',
      dataIndex: 'index',
      key: 'index',
    },
    {
      title: 'Teacher',
      dataIndex: 'teacher',
      key: 'teacher',
    },
    {
      title: 'Class',
      dataIndex: 'className',
      key: 'className',
    },
    {
      title: 'Subject',
      dataIndex: 'subjectName',
      key: 'subjectName',
    },
  ];

  if (loading) {
    return <Spin />;
  }

  return (
    <div style={{ padding: '20px' }}>
      <Button type="primary" onClick={handleAdd} style={{ marginBottom: 16 }}>
        Add Planner
      </Button>
      <Table columns={columns} dataSource={combinedData} loading={loading} />
      <Modal
        title="Add Planner"
        visible={isAddModalVisible}
        onCancel={() => setIsAddModalVisible(false)}
        onOk={() => form.submit()}
      >
        <Form form={form} onFinish={handleAddSubmit}>
          <Form.Item label="Teacher" name="userId" rules={[{ required: true, message: 'Please select a teacher!' }]}>
            <Select>
              {users.map(user => (
                <Select.Option key={user.id} value={user.id}>
                  {`${user.firstName} ${user.lastName}`}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>
          <Form.Item label="Class" name="classId" rules={[{ required: true, message: 'Please select a class!' }]}>
            <Select>
              {classes.map(cls => (
                <Select.Option key={cls.id} value={cls.id}>
                  {cls.name}
                </Select.Option>
              ))}
            </Select>
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

export default Planner;
