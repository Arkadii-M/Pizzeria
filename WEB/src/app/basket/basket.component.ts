import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../shared/models/basket';
import { BasketService } from './basket.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent {
  basket$!: Observable<IBasket>;

  purchase: boolean = false;

  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.basketService.setBasket({
      id: 'Some',
      items: [
        {
          id: 1,
          productName: 'Custom Pizza',
          price: 15,
          quantity: 1,
          pictureUrl: '/assets/images/pizza.jpg',
          type: "Pizza",
          pizzaSize: "Medium",
        }
      ],
    });
    this.basketService.getBasket('Some');
    this.basket$ = this.basketService.basket$;
  }

  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFromBasket(item);
  }

  incrementItemQuantity(item: IBasketItem) {
    this.basketService.incrementItemQuantity(item);
  }

  decrementItemQuantity(item: IBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }
  // decreaseQuantity(){
  //   this.basketService.basket$.u
  // }

  resetBasket() {
    const basket = this.basketService.getCurrentBasketValue();
    this.basketService.deleteBasket(basket);
    this.basket$ = this.basketService.basket$;
    this.purchase = true;
  }
}
