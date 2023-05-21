import { Injectable } from '@angular/core';
import { Pizza } from '../../shared/models/pizza';
import { PizzaBuilder } from '../../shared/models/pizza-builder';

@Injectable({
  providedIn: 'root'
})
export class PizzaBuilderService {
  pizzaBuilders: PizzaBuilder[] = [];
  constructor() {
  }
  addPizzaToBuilder(pizza: Pizza) {
    this.pizzaBuilders.push(new PizzaBuilder(pizza));
  }
  getPizzaBuilders(): PizzaBuilder[] {
    return this.pizzaBuilders;
  }

}
