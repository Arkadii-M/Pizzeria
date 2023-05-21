import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent {
  constructor(private http: HttpClient, private router: Router,
    @Inject('BASE_API_URL') private baseUrl: string) { }


  getAllMyOrders() {
    return this.http.get(this.baseUrl + 'Order');
  }

  cancelOrder(orderId: number) {
    return this.http.post(this.baseUrl + 'Order/cancel/' + orderId);
  }

  processOrder(orderId: number) {
    return this.http.post(this.baseUrl + 'Order/process/' + orderId);
  }

}
