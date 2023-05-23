import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IMyPizza, IMyTopping } from '../../shared/models/myPizza';


class ToppingCount {
  constructor(
    public toppingId: number,
    public count: number = 1) {

    }
}

@Component({
  selector: 'app-topping-list',
  templateUrl: './topping-list.component.html',
  styleUrls: ['./topping-list.component.css']
})
export class ToppingListComponent {
  @Input() toppings: IMyTopping[] = [];
  toppingCount: ToppingCount[] = [];
  currentPizza?: IMyPizza;




  @Input() set setPizza(inputPizza: IMyPizza) {
    this.currentPizza = inputPizza;
    this.currentPizza.items.forEach((val, index, arr) => {
      this.updateToppingCount(val);
    })

  }
  @Output() pizzaOutput = new EventEmitter<IMyPizza>();


  private updateToppingCount(topping: IMyTopping) {
    let indexToUpdate = this.toppingCount.findIndex(item => item.toppingId === topping.productId);
    if (indexToUpdate == -1) {
      this.toppingCount.push(new ToppingCount(topping.productId))
    }
    else {
      this.toppingCount[indexToUpdate].count += 1
    }
  }

  getToppingCount(id: number): number | undefined {
    return this.toppingCount.find(p => p.toppingId == id)?.count;
  }

  addTopping(topping: IMyTopping) {
    this.currentPizza!.items.push(topping);
    this.updateToppingCount(topping);
    console.log(this.toppingCount)
  }

  applyToppings() {
    console.log("All Toppings has been added!")
    console.log(this.currentPizza);
    this.pizzaOutput.emit(this.currentPizza);
  }


}
