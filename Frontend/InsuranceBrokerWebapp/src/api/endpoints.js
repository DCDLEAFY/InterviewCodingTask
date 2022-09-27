import { url } from  "./common.js"
import axios from "axios"

export function GetAllCustomers() {
    const headers = { "Content-Type": "application/json" };
    return axios.get(url + "/api/Customer", {headers})
}

export function AddCustomer(customer){
    const headers = { "Content-Type": "application/json" };
    return axios.post(url + "/api/Customer", customer, headers)
}