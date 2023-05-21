import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  constructor(private http: HttpClient, private router: Router,
    @Inject('BASE_API_URL') private baseUrl: string) { }


  addOrder(order: any) {
    return this.http.post(this.baseUrl + 'Order/add', order);
  }




}
