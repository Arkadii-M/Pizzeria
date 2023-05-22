import { Component } from '@angular/core';
import { IMyPizza, IMyPizzaItem, IMyTopping, MyPizza, MyTopping } from '../shared/models/myPizza';
import { PizzaBuilder } from '../shared/models/pizza-builder';

@Component({
  selector: 'app-pizza-builder',
  templateUrl: './pizza-builder.component.html',
  styleUrls: ['./pizza-builder.component.css']
})
export class PizzaBuilderComponent {
  pizzas: IMyPizza[] = []
  ingridients: IMyTopping[] = []
  pizzaBuilders: PizzaBuilder[] = []


  constructor() {


    this.pizzas.push(new MyPizza(1, "Pizza1", 100))
    this.pizzas.push(new MyPizza(2, "Pizza2", 100))
    this.pizzas.push(new MyPizza(3, "Pizza3", 100))
    this.pizzas.push(new MyPizza(4, "Pizza4", 100))

    this.ingridients.push(new MyTopping(1, "cheese", 19))
    this.ingridients.push(new MyTopping(1, "mushrooms", 19))
    this.ingridients.push(new MyTopping(1, "ketchup", 20))

  }

  addSomeTopicToPizza(pizzaId: number, toppingId: number) {
    this.pizzas[pizzaId].items.push(this.ingridients[toppingId]);
  }

  printPizzas() {
    for (let i = 0; i < this.pizzas.length; i++) {
      console.log(this.pizzas[i]);
    }
  }



}
