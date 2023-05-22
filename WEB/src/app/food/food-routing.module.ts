import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodComponent } from './food.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {path: 'new-menu', component: FoodComponent},
  {path: 'new-menu/:id', component: ProductDetailsComponent},
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class FoodRoutingModule { }
