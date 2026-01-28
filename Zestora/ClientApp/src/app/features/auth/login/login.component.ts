import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { ROUTES } from '../../../core/routes.constants';
import { Auth } from '../../../core/services/auth';
import { LoginRequestDto } from '../../../core/models/loginRequest.dto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false,
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  private authService = inject(Auth);
  private router = inject(Router);

  onSubmit() {
    // Aquí irá tu lógica de autenticación
    // console.log('Login:', { email: this.email, password: this.password });
    const loginData: Readonly<LoginRequestDto> = {
      email: this.email,
      password: this.password,
    };

    this.authService.login(loginData).subscribe({
      next: (response) => {
        console.log(response);
      },
      error: (errors) => {
        console.log(errors);
      },
    });
  }

  goToRegister() {
    this.router.navigate([ROUTES.AUTH.REGISTER]);
  }
}
