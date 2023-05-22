import {v4 as uuidv4} from 'uuid';
import { IBasket } from './basket';

export interface IMyPizzaItem {
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

export interface IMyPizza {
    id: string,
    items: IMyPizzaItem[];
}

export class MyPizza implements IMyPizza {
    id = uuidv4();
    items: IMyPizzaItem[] = [];
}