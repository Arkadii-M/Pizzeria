import { Pizza } from "./pizza";
import { Topping } from "./topping";

export class PizzaBuilder {
  private pizza: Pizza;

  constructor(pizza?: Pizza) {
    this.pizza = { id: 0, toppings: [] };
  }

  addTopping(topping: Topping) {
    this.pizza.toppings.push(topping)
  }

  build(): Pizza {
    return this.pizza;
  }


}

