import { config } from "process";
import { base_url } from "../utils/baseUrl"
import axios from "axios";


//chưa đổi
export const apiEvaluateById = async (docId: any) => {
    const result = await axios.get(`${base_url}Evaluate/${docId}`);
    if (result)
        return result;
    else
        return null;
}


//chưa đổi
export const apiPostEvaluate = async (data: any) => {
    const result = await axios.post(`${base_url}Evaluate`, data);
    if (result)
        return result;
    else
        return null;
}

//chưa đổi
export const apiUpdateEvaluate = async (data: any) => {
    const result = await axios.put(`${base_url}Evaluate`, data);
    if (result)
        return result;
    else
        return null;
}