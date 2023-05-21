import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { AppComponent } from './app.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MenuComponent } from './menu/menu.component';
import { ProductItemComponent } from './menu/product-item/product-item.component';
import { PizzaBuilderComponent } from './pizza-builder/pizza-builder.component';
import { BasketComponent } from './basket/basket.component';
import { OrdersComponent } from './orders/orders.component';

const appRoutes: Routes = [
  { path: '', component: AppComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'menu', component: MenuComponent },
  { path: 'pizza-builder', component: PizzaBuilderComponent }
];


@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    NavBarComponent,
    MenuComponent,
    ProductItemComponent,
    PizzaBuilderComponent,
    BasketComponent,
    OrdersComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule, ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    NgbModule
  ],
  providers: [
    {
      provide: "BASE_API_URL", useValue: 'https://localhost:62136/api/'
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
