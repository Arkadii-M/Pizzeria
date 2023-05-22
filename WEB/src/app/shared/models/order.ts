import { IBasket } from "./basket";

export interface IOrder {
    id: number,
    employeeName: string,
    customerFistName: string,
    customerLastName: string,
    customerPhoneNumber: number,
    customerAddress: string,
    customerAddressZipCode: number,
    promisedDeliveryTime: number,
    pizzasSize: string,
    initialDeliveryTime: number,
    finalDeliveryTime: number,
    errorInDeliveryTime: number,
    tip: number,
    orderTotalRevenue: number,

    orderBasket: IBasket,

    orderStatus: string,


}