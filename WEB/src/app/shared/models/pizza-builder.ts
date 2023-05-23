import { IMyPizza, IMyTopping } from "./myPizza";
import { Pizza } from "./pizza";
import { Topping } from "./topping";

export class PizzaBuilder {
  private pizza: IMyPizza;

  constructor(pizza: IMyPizza) {
    this.pizza = pizza;
  }

  addTopping(topping: IMyTopping) {
    this.pizza.items.push(topping);
  }

  build(): IMyPizza {
    return this.pizza;
  }


}

