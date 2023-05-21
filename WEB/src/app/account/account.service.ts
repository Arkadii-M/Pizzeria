import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient, private router: Router,
    @Inject('BASE_API_URL') private baseUrl: string) { }


  login(values: any) {
    return this.http.post(this.baseUrl + 'Account/login', { Username: values.username, Password: values.password });
    //return this.http.post(this.baseUrl + 'account/login', values).pipe(
    //  map((user: IUser) => {
    //    if (user) {
    //      localStorage.setItem('token', user.token);
    //      this.currentUserSource.next(user);
    //    }
    //  })
    //);
  }
}
