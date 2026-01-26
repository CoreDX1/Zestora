import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: false
})
export class RegisterComponent {
  name: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

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
    this.router.navigate(['/auth/login']);
  }
}
