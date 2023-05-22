import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodComponent } from './food.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';
import { FoodRoutingModule } from './food-routing.module';



@NgModule({
  declarations: [
    FoodComponent,
    ProductItemComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FoodRoutingModule
  ],
  exports: [
    FoodComponent
  ],
  // exports: [FoodComponent]
})
export class FoodModule { }
