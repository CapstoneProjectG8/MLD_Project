import './style.scss'
import { Swiper, SwiperSlide } from "swiper/react";
import { Autoplay } from "swiper/modules"
import 'swiper/css';
import { useNavigate } from 'react-router-dom';

const Home = () => {
    const navigate = useNavigate()
    return (
        <div className='home-panel'>
            <div className='home-panel-content'>
                <div className="home-panel-content-sub-menu">
                    <div className="home-panel-content-sub-menu-list">
                        <div className="home-panel-content-sub-menu-item-name">
                            Phụ lục 1
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
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-1/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-1/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-1/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-1/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-1/detail')}>
                                    </div>
                                </SwiperSlide>
                            </Swiper>
                        </div>
                    </div>
                </div>
                <div className="home-panel-content-sub-menu">
                    <div className="home-panel-content-sub-menu-list">
                        <div className="home-panel-content-sub-menu-item-name">
                            Phụ lục 2
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
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-2/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-2/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-2/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-2/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-2/detail')}>
                                    </div>
                                </SwiperSlide>
                            </Swiper>
                        </div>
                    </div>
                </div>
                <div className="home-panel-content-sub-menu">
                    <div className="home-panel-content-sub-menu-list">
                        <div className="home-panel-content-sub-menu-item-name">
                            Phụ lục 3
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
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-3/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-3/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-3/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-3/detail')}>
                                    </div>
                                </SwiperSlide>
                                <SwiperSlide>
                                    <div className='sub-menu-content-detail' onClick={() => navigate('/sub-menu-3/detail')}>
                                    </div>
                                </SwiperSlide>
                            </Swiper>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Home