import {v4 as uuidv4} from 'uuid';
import { IBasket } from './basket';

export interface IMyPizzaItem {
    itemId: number,
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
export interface IMyTopping {
  productId: number;
  productName: string;
  price: number;
}

export class MyTopping implements IMyTopping {
  constructor(id: number, name: string, price: number) {
    this.productId = id;
    this.productName = name;
    this.price = price;
  }
    productId: number;
    productName: string;
    price: number;

}

export interface IMyPizza {
  itemId: number,
  itemName: string,
   items: IMyTopping[];
}

export class MyPizza implements IMyPizza {

  constructor(id: number, name: string, price: number) {
    this.itemId = id;
    this.itemName = name;
    this.price = price;
  }

  itemId: number = 0;
  itemName: string = "";
  price: number = 0;

  items: IMyTopping[] = [];
}
