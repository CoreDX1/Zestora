import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {ROUTES} from '../../../core/routes.constants'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private router: Router) {}

  onSubmit() {
    // Aquí irá tu lógica de autenticación
    console.log('Login:', { email: this.email, password: this.password });
  }

  goToRegister() {
    this.router.navigate([ROUTES.AUTH.REGISTER]);
  }
}
