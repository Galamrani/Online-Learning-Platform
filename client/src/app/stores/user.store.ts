import { Injectable, Signal, signal, effect } from '@angular/core';
import { UserModel } from '../models/user.model';

@Injectable({ providedIn: 'root' })
export class UserStore {
  private _user = signal<UserModel | null>(this.loadUserFromLocalStorage()); // Load from local storage

  constructor() {
    // Automatically sync user state to local storage when updated
    effect(() => {
      this.saveUserToLocalStorage(this._user());
    });
  }

  get user(): Signal<UserModel | null> {
    return this._user;
  }

  setUser(newUser: UserModel) {
    this._user.set(newUser);
  }

  clearUser() {
    this._user.set(null);
    localStorage.removeItem('user');
  }

  isLoggedIn(): boolean {
    return this._user() !== null;
  }

  getUserName(): string | undefined {
    return this._user()?.name;
  }

  getUserId(): string | undefined {
    return this._user()?.id;
  }

  private loadUserFromLocalStorage(): UserModel | null {
    const userData = localStorage.getItem('user');
    return userData ? JSON.parse(userData) : null;
  }

  private saveUserToLocalStorage(user: UserModel | null): void {
    if (user) {
      localStorage.setItem('user', JSON.stringify(user));
    } else {
      localStorage.removeItem('user');
    }
  }
}
