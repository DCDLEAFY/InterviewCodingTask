import { url, apiCustomerPath} from  "./common.js"
import axios from "axios"

export function GetAllCustomers() {
    const headers = { "Content-Type": "application/json" };
    return axios.get(url + apiCustomerPath, {headers})
}

export function AddCustomer(customer){
    const headers = { "Content-Type": "application/json" };
    return axios.post(url + apiCustomerPath, customer, headers)
}

export function DeleteCustomer(id){
    return axios.delete(url + apiCustomerPath + "?id=" + id);
}