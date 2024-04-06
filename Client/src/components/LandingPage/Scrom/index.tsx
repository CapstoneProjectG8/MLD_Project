import React from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { Remove } from '@mui/icons-material';
import './style.scss'

const Scrom = () => {
    const grades = ["Violet", "Thư viện Violet", "Macromedia Flash", "Sử dụng email"]
    const subMenu = [1, 2, 3];
    const navigate = useNavigate()

    return (
        <div className='scrom-panel'>
            <div className='scrom-panel-content'>
                <div className="scrom-panel-content-sub-menu">
                    <div className="scrom-panel-content-sub-menu-list">
                        <div className="scrom-panel-content-sub-menu-item-name">
                            <div className='add-row-button'>
                                <Link to="/upload-bai-giang">Đưa eleaning lên</Link>
                            </div>
                        </div>
                        {
                            grades?.map((grade, index) => (
                                <div key={index}>
                                    <div  className="grade-name" style={{ fontSize: "24px" }} onClick={() => navigate(`${grade}`)}>{grade}</div>
                                    <div  className="scrom-panel-content-sub-menu-item-content-grid"
                                        style={{ borderBottom: index === grades.length - 1 ? 'none' : '1px solid black' }}
                                    >
                                        {
                                            subMenu?.map((item, index) => (
                                                <div key={index} className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-1/detail-view')}>
                                                    <div className="remove-row-button">

                                                    </div>
                                                </div>
                                            ))
                                        }
                                    </div>
                                </div>
                            ))
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Scrom