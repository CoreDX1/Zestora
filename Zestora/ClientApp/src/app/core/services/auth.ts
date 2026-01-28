import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginRequestDto } from '../models/loginRequest.dto';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  public pathUrl: string = 'http://localhost:5018';

  constructor(private http: HttpClient) {}

  register(username: string, password: string): Observable<any> {
    return this.http.post(`${this.pathUrl}/auth/register`, {
      username: username,
      password: password,
    });
  }

  login(data: LoginRequestDto): Observable<any> {
    return this.http.post(`${this.pathUrl}/api/Customer/ValidateUser`, data);
  }
}
