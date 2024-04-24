import { Grid } from '@mui/material'
import React, { useEffect, useState } from 'react'
import '../style.scss'
import { Article, Folder, Note, Square } from '@mui/icons-material'
import { apiGetSpecializedDepartment, apiGetSpecializedDepartmentById } from '../../../../api/specializedDepartment'
import axios from 'axios'
import { base_url } from '../../../../utils/baseUrl'
import { Link } from 'react-router-dom'

const LeftSubNavBar = () => {
    const [depts, setDepts] = useState<any>([])


    useEffect(() => {

        const getDepartmentHandler = async () => {
            await apiGetSpecializedDepartment().then((res) => {
                setDepts(res.data);
                console.log(res.data);
            })
        }
        getDepartmentHandler();
    }, []);

    
    return (
        <Grid item xs={2} style={{ padding: 0 }}>
            <div className='sub-nav-bar sub-nav-bar-left'>
                <div className="sub-nav-bar-item">
                    <div className="sub-nav-bar-item-name">Thư mục</div>
                    <div className="sub-nav-bar-item-content">
                        <div className="sub-nav-bar-item-content-folder">
                            {
                                depts.map((dep: any, index: any) => (
                                    <>
                                        <Document dep={dep}></Document>
                                    </>
                                ))
                            }
                        </div>
                    </div>
                </div>
                <div className="sub-nav-bar-item">
                    <div className="sub-nav-bar-item-name">Thông báo</div>
                    <div className="sub-nav-bar-item-content">
                    </div>
                </div>
            </div>
        </Grid>
    )
}

// may th kia , co th nao ranh ko , bao no sua me cai api cho nhanh
// dang lay submenu o trong document chu dep lam gi 



const Document = ({ dep }: any) => {
    const [documents, setDocuments] = useState<any>([]);
    const [show, setShow] = useState<any>(false);
    const [rs1,Setrs1] =  useState<any>([]);
    const [rs2,Setrs2] =  useState<any>([]);
    const [rs3,Setrs3] =  useState<any>([]);
    const [rs4,Setrs4] =  useState<any>([]);
    
    useEffect(() => {
        const getDocument = async () => {
            var doc1 = await axios.get(base_url + "Document1/GetDocument1ByUserSpecialiedDepartment?listId=" + dep.id)
            var doc2 = await axios.get(base_url + "Document2/GetDocument2ByUserSpecialiedDepartment?listId=" + dep.id)
            var doc3 = await axios.get(base_url + "Document3/GetDocument3ByUserSpecialiedDepartment?listId=" + dep.id)
            var doc4 = await axios.get(base_url + "Document4/GetDocument4ByUserSpecialiedDepartment?listId=" + dep.id)
            var rs1 = doc1.data[0].documents.map((item : any) => {
                return {...item , submenu : 1};
            });
            var rs2 = doc2.data[0].documents.map((item : any) => {
                return {...item , submenu : 2};
            });
            var rs3 = doc3.data[0].documents.map((item : any) => {
                return {...item , submenu : 3};
            });
            var rs4 = doc4.data[0].documents.map((item : any) => {
                return {...item , submenu : 4};
            });
            //setDocuments([...doc1.data[1].documents, ...doc2.data[2].documents, ...doc3.data[3].documents, ...doc4.data[4].documents]);
            // setDocuments([...rs1, ...rs2, ...rs3, ...rs4]);
            Setrs1(rs1);
            Setrs2(rs2);
            Setrs3(rs3);
            Setrs4(rs4);
        }
        
        //de luu bien
       
        getDocument();
    }, [dep.id])

  // la hien o dau
  // vc du lieu o dau ra , voi api the kia
  // chuan chua
  // tao component khac roi tuong tu
  

    return <>
        <div className='sub-nav-bar-item-content-folder-name' onClick={() => setShow(!show)}>
            <Folder style={{ width: "30", height: "30", color: "orange" }} />
            <div>{dep.name}</div>
        </div>
       
        <div className={show ? 'nav-is-show' : 'nav-is-hidden'}>
           
        <Content doc_number={1} rs={rs1} />
        <Content doc_number={2} rs={rs2} />
        <Content doc_number={3} rs={rs3} />
        <Content doc_number={4} rs={rs4} />
        </div>
    </>
}



const Content = ({doc_number , rs} : any) => {
    const [show, setShow] = useState<any>(false);

    return  <>
    
    <div className='sub-nav-bar-item-content-folder-course' onClick={() => setShow(!show)}>
            <Note style={{ width: "30px", height: "30px", color: "#EFB38E" }} />
            Phụ lục {doc_number}
        </div>
    <div className={show ? 'nav-ok nav-is-show' : 'nav-ok nav-is-hidden'}>
    {rs.map((doc: any) => (
        <>
        <Link key={doc.id} to={`/sub-menu-${doc.submenu}/detail-view/${doc.id}`}>
        <div className='sub-nav-bar-item-content-folder-course'>
            <Article style={{ width: "30px", height: "30px", color: "#EFB38E" }} />
            {doc.name}
        </div>
    </Link>
        </>
    ))
    }
    </div>
    </>
}


export default LeftSubNavBar