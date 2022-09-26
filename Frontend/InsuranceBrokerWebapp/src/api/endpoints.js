import { url } from  "./common.js"
import axios from "axios"

export function GetAllCustomers() {
    const headers = { "Content-Type": "application/json" };
    return axios.get(url + "/api/Customer", {headers})
}