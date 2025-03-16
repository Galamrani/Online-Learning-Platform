import { inject, Injectable } from '@angular/core';
import { UserStore } from '../stores/user.store';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/user.model';
import { environment } from '../../environments/environment';
import { CredentialsModel } from '../models/credentials.model';
import { catchError, firstValueFrom, Observable } from 'rxjs';
import { jwtDecode } from 'jwt-decode';
import { CourseManagerService } from './course-manager.service';
import { ViewStore } from '../stores/view.store';

@Injectable({ providedIn: 'root' })
export class UserService {
  private userStore = inject(UserStore);
  private viewStore = inject(ViewStore);
  private courseManagerService = inject(CourseManagerService);
  private http = inject(HttpClient);

  public async register(user: UserModel): Promise<void> {
    try {
      const token$ = this.http.post<string>(environment.userRegisterUrl, user, {
        responseType: 'text' as 'json',
      });
      await this.handleAuthToken(token$);
    } catch (error) {
      throw error;
    }
  }

  public async login(credentials: CredentialsModel): Promise<void> {
    try {
      const token$ = this.http.post<string>(
        environment.userLoginUrl,
        credentials,
        { responseType: 'text' as 'json' }
      );
      await this.handleAuthToken(token$);
    } catch (error) {
      throw error;
    }
  }

  public logout(): void {
    this.userStore.clearUser();
    this.viewStore.clearView();
    this.courseManagerService.reset();
    localStorage.clear();
  }

  private async handleAuthToken(token$: Observable<string>) {
    try {
      const token: string = await firstValueFrom(
        token$.pipe(
          catchError((err) => {
            throw new Error(err.error || 'Invalid credentials');
          })
        )
      );
      const payload = jwtDecode<{ userData: string }>(token);
      const userData: UserModel = JSON.parse(payload.userData);

      this.userStore.setUser(userData);
      localStorage.setItem('token', token);
    } catch (error) {
      throw error;
    }
  }
}
