import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  constructor(private http: HttpClient, private router: Router,
    @Inject('BASE_API_URL') private baseUrl: string) { }


  getAllMenu() {
    return this.http.get(this.baseUrl + 'Menu');
  }

  getAllCutsomProducts() {
    return this.http.get(this.baseUrl + 'CustomProduct');
  }
  getAllCutsomPizzaProducts() {
    return this.http.get(this.baseUrl + 'CustomProduct/pizza');
  }
  getAllCutsomSaladProducts() {
    return this.http.get(this.baseUrl + 'CustomProduct/salad');
  }

}
