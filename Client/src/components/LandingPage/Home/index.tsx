import './style.scss'
import { Swiper, SwiperSlide } from "swiper/react";
import { Autoplay } from "swiper/modules"
import 'swiper/css';
import { useNavigate } from 'react-router-dom';
import { Add } from '@mui/icons-material';

const Home = () => {
    const navigate = useNavigate()
    const handleAddSubMenu1 = () => {
        navigate("/sub-menu-1/detail-edit")
    }

    const handleAddSubMenu2 = () => {
        navigate("/sub-menu-2/detail-edit")
    }

    const handleAddSubMenu3 = () => {
        navigate("/sub-menu-3/detail-edit")
    }

    const Arr = [1, 2, 3, 4, 5, 6, 7, 8, 9]
    return (
        <div className='home-panel'>
            <div className='home-panel-content'>
                <div className="home-panel-content-sub-menu">
                    <div className="home-panel-content-sub-menu-list">
                        <div className="home-panel-content-sub-menu-item-name">
                            <span>
                                Phụ lục 1
                            </span>
                            <div className='add-row-button'>
                                <Add style={{ color: "black" }} className='add-row-icon' onClick={handleAddSubMenu1} />
                            </div>
                        </div>
                        <div className="home-panel-content-sub-menu-item-content">
                            <Swiper
                                modules={[Autoplay]}
                                autoplay={{
                                    delay: 2500,
                                    disableOnInteraction: false,
                                }}
                                spaceBetween={20}
                                centeredSlides={true}
                                slidesPerView={3}
                                loop={true}
                            >
                                {
                                    Arr.map((a, index) => (
                                        <SwiperSlide key={index} style={{ display: 'flex', flexDirection: 'column' }}>
                                            <div className='sub-menu-content-detail' style={{ backgroundImage: `url('https://o.rada.vn/data/image/2022/08/26/Trang-tri-8.jpg')` }} onClick={() => navigate('/sub-menu-1/detail-view')}>

                                            </div>
                                            <div>
                                                {a}
                                            </div>
                                        </SwiperSlide>
                                    ))
                                }


                            </Swiper>
                        </div>
                    </div>
                </div>
                <div className="home-panel-content-sub-menu">
                    <div className="home-panel-content-sub-menu-list">
                        <div className="home-panel-content-sub-menu-item-name">
                            <span>
                                Phụ lục 2
                            </span>
                            <div className='add-row-button'>
                                <Add style={{ color: "black" }} className='add-row-icon' onClick={handleAddSubMenu2} />
                            </div>
                        </div>
                        <div className="home-panel-content-sub-menu-item-content">
                            <Swiper
                                modules={[Autoplay]}
                                autoplay={{
                                    delay: 2500,
                                    disableOnInteraction: false,
                                }}
                                spaceBetween={20}
                                centeredSlides={true}
                                slidesPerView={3}
                                loop={true}
                            >
                                {
                                    Arr.map((a, index) => (
                                        <SwiperSlide key={index} style={{ display: 'flex', flexDirection: 'column' }}>
                                            <div className='sub-menu-content-detail' style={{ backgroundImage: `url('https://o.rada.vn/data/image/2022/08/26/Trang-tri-8.jpg')` }} onClick={() => navigate('/sub-menu-1/detail-view')}>

                                            </div>
                                            <div>
                                                {a}
                                            </div>
                                        </SwiperSlide>
                                    ))
                                }
                            </Swiper>
                        </div>
                    </div>
                </div>
                <div className="home-panel-content-sub-menu">
                    <div className="home-panel-content-sub-menu-list">
                        <div className="home-panel-content-sub-menu-item-name">
                            <span>
                                Phụ lục 3
                            </span>
                            <div className='add-row-button'>
                                <Add style={{ color: "black" }} className='add-row-icon' onClick={handleAddSubMenu3} />
                            </div>
                        </div>
                        <div className="home-panel-content-sub-menu-item-content">
                            <Swiper
                                modules={[Autoplay]}
                                autoplay={{
                                    delay: 2500,
                                    disableOnInteraction: false,
                                }}
                                spaceBetween={20}
                                centeredSlides={true}
                                slidesPerView={3}
                                loop={true}
                            >
                                {
                                    Arr.map((a, index) => (
                                        <SwiperSlide key={index} style={{ display: 'flex', flexDirection: 'column' }}>
                                            <div className='sub-menu-content-detail' style={{ backgroundImage: `url('https://o.rada.vn/data/image/2022/08/26/Trang-tri-8.jpg')` }} onClick={() => navigate('/sub-menu-1/detail-view')}>

                                            </div>
                                            <div>
                                                {a}
                                            </div>
                                        </SwiperSlide>
                                    ))
                                }
                            </Swiper>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Home