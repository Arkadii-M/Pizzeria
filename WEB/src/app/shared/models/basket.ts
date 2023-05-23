import { v4 as uuidv4} from 'uuid';
import { IMyPizza, MyPizza } from './myPizza';

export interface IBasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    type: string;
    pizzaSize: string;
}

export interface IBasket {
    id: string;
    items: IBasketItem[];
}

export class Basket implements IBasket {
    id= uuidv4();
    items: IBasketItem[] = [];
}

export interface IBasketTotals {
    delivery: number;
    subtotal: number;
    total: number;
}
