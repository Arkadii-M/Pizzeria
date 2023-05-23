import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { IMyTopping } from '../shared/models/myPizza';

@Injectable({
  providedIn: 'root'
})
export class CustomProductsService {

  constructor(private http: HttpClient, private router: Router,
    @Inject('BASE_API_URL') private baseUrl: string) { }


  getPizzaToppings() {
    return this.http.get<IMyTopping[]>(this.baseUrl + 'CustomProduct/pizza');
  }
}
