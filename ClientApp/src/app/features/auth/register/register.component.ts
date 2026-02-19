import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ROUTES } from '../../../core/routes.constants';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: false
})
export class RegisterComponent {
  public name: string = '';
  public email: string = '';
  public password: string = '';
  public confirmPassword: string = '';

  constructor(private router: Router) {}

  onSubmit() {
    // Aquí irá tu lógica de registro
    console.log('Register:', { 
      name: this.name, 
      email: this.email, 
      password: this.password,
      confirmPassword: this.confirmPassword
    });
  }

  goToLogin() {
    this.router.navigate([ROUTES.AUTH.LOGIN]);
  }
}
