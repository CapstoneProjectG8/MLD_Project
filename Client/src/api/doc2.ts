import { base_url } from "../utils/baseUrl"
import axios from "axios";


//đổi tên
export const apiGetDoc2 = async (): Promise<any> => {
    const result = await axios.get(`${base_url}Document2`);
    if (result)
        return result;
    else
        return null;
}

