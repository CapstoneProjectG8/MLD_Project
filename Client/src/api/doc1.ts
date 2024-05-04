import { base_url } from "../utils/baseUrl"
import axios from "axios";


//đổi tên
export const apiGetDoc = async (): Promise<any> => {
    const result = await axios.get(`${base_url}Document1`);
    if (result)
        return result;
    else
        return null;
}

