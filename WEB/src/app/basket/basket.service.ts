import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../shared/models/basket';
import { BehaviorSubject } from 'rxjs';
import { environment } from '@ng-bootstrap/ng-bootstrap/environment';
import { IProduct } from '../shared/models/product';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private basketSource = new BehaviorSubject<IBasket>(null as any);
  basket$ = this.basketSource.asObservable();

  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null as any);
  basketTotal$ = this.basketTotalSource.asObservable();
  constructor(private http: HttpClient, private router: Router, @Inject('BASE_API_URL') private baseUrl: string) { }


  getBasket(id: string) {
    var basket: IBasket = JSON.parse(localStorage.getItem('basket_' + id) ?? "");
    console.log(basket);
    this.basketSource.next(basket);
    // return this.http.get(this.baseUrl + 'basket?id=' + id)
    // .pipe(
    //   map((basket: any) => {
    //     this.basketSource.next(basket);
    //     this.calculateTotals();
    //   })
    // );
  }

  setBasket(basket: IBasket) {
    localStorage.setItem('basket_' + basket.id, JSON.stringify(basket));
    // @ts-ignore
    return this.http.post(this.baseUrl + 'basket', basket).subscribe((response: IBasket) => {
      this.basketSource.next(response as IBasket);
      this.calculateTotals();
    }, error => {
      console.log(error);
    });
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }

  incrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foudnItemIndex = basket.items.findIndex(x =>x.id === item.id);
    basket.items[foudnItemIndex].quantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x =>x.id === item.id);
    if(basket.items[foundItemIndex].quantity > 1)
    {
      basket.items[foundItemIndex].quantity--;
      this.setBasket(basket);
    } else{
      this.removeItemFromBasket(item);
    }
  }
  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if(basket.items.some(x => x.id === item.id))
    {
      basket.items = basket.items.filter(i => i.id !== item.id);
      if(basket.items.length > 0)
      {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket);
      }
    }
  }
  deleteBasket(basket: IBasket) {
    localStorage.removeItem(`basket_${basket.id}`);
    this.basketSource.next(null as any);
    this.basketTotalSource.next(null as any);

    // return this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe(() => {
    //   this.basketSource.next(null as any);
    //   this.basketTotalSource.next(null as any);
    //   localStorage.removeItem('basket_id');
    // }, error => {
    //   console.log(error);
    // })
  }


  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const delivery = 0;
    const subtotal = basket.items.reduce((a,b) => (b.price* b.quantity) + a, 0);
    const total = subtotal + delivery;
    this.basketTotalSource.next({delivery, total, subtotal});
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    console.log(items);
    const index = items.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }

    return items;
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id); //persisting the local storage of the browser.
    return basket;
  }

  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productName: item.name,
      price: item.price,
      pictureUrl: item.pictureUrl,
      quantity,
      pizzaSize: 'Large',
      type: item.productType,
    }
  }
}
