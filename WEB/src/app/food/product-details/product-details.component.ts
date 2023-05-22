import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';
import { FoodService } from '../food.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product?: IProduct;
  quantity = 1;

  constructor(
    private foodService: FoodService,
    private activatedRoute: ActivatedRoute,
    private basketService: BasketService) { }

  ngOnInit(): void {
    this.loadProduct();
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product as any, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    this.quantity--;
  }



  loadProduct() {
    if (!this.activatedRoute.snapshot.paramMap.get('id')) { return ; }
    this.product = {
      id: 1,
      name: "Pizza",
      description: "Pizza",
      pictureUrl: "Pizza",
      price: 25,
      cost: 15,
      preWageEarning: 5,
      productType: "Pizza",
    };
    // @ts-ignore
    // this.foodService.getProduct(+this.activatedRoute?.snapshot?.paramMap?.get('id')).subscribe(product => {
    //   this.product = product;
    // }, error => {
    //   console.log(error);
    // });
  }

}
