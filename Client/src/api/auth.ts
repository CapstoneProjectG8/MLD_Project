import { config } from "process";
import { base_url } from "../utils/baseUrl"
import axios from "axios";

//thay đổi
export const apiPostSendEmail = async (email: string): Promise<any> => {
    const result = await axios.post(`${base_url}Account/SendMailResetPassword?mail=${email}`);
    if (result)
        return result;
    else
        return null;
}

//thay đổi
export const apiCheckVerifyPassword = async (data: any, query: any): Promise<any> => {
    const result = await axios.post(`${base_url}Account/CheckVerifyPassword`, data, { params: query });
    if (result)
        return result;
    else
        return null;
}

