import { config } from "process";
import { base_url } from "../utils/baseUrl"
import axios from "axios";


//chưa đổi
export const apiGetGrade = async () => {
    const result = await axios.get(`${base_url}Grade`);
    if (result)
        return result;
    else
        return null;
}