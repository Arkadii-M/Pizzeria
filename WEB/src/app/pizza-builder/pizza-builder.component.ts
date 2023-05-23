import { Component } from '@angular/core';
import { BasketService } from '../basket/basket.service';
import { Basket, IBasket, IBasketItem } from '../shared/models/basket';
import { IMyPizza, IMyPizzaItem, IMyTopping, MyPizza, MyTopping } from '../shared/models/myPizza';
import { CustomProductsService } from './custom-products.service';

@Component({
  selector: 'app-pizza-builder',
  templateUrl: './pizza-builder.component.html',
  styleUrls: ['./pizza-builder.component.css'],
  providers: [BasketService]
})
export class PizzaBuilderComponent {
  pizzas: IMyPizza[] = []
  ingridients: IMyTopping[] = []

  currentBasket!: IBasket;


  constructor(
    private basketService: BasketService,
    private customProductService: CustomProductsService) {
    this.currentBasket = basketService.getCurrentBasketValue();

    this.customProductService.getPizzaToppings().subscribe(res => {
      this.ingridients = res;
    })


    console.log(this.currentBasket)

    this.pizzas.push(new MyPizza(1, "Pizza1", 100))
    this.pizzas.push(new MyPizza(2, "Pizza2", 100))
    this.pizzas.push(new MyPizza(3, "Pizza3", 100))
    this.pizzas.push(new MyPizza(4, "Pizza4", 100))

    //this.ingridients.push(new MyTopping(1, "cheese", 19))
    //this.ingridients.push(new MyTopping(2, "mushrooms", 19))
    //this.ingridients.push(new MyTopping(3, "ketchup", 20))

  }

  addSomeTopicToPizza(pizzaId: number, toppingId: number) {
    this.pizzas[pizzaId].items.push(this.ingridients[toppingId]);
  }

  printPizzas() {
    for (let i = 0; i < this.pizzas.length; i++) {
      console.log(this.pizzas[i]);
    }
  }

  updatePizza(pizzaToUpdate: any) {
    let indexToUpdate = this.pizzas.findIndex(item => item.itemId === pizzaToUpdate.itemId);
    this.pizzas[indexToUpdate] = pizzaToUpdate;
    console.log(this.pizzas)
  }



}
