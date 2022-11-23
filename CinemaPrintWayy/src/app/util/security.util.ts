import { User } from '../models/User';

export class Security {
  public static set(user: User, token: any) {
    const data = JSON.stringify(user);

    localStorage.setItem('cinemauser', data);
    localStorage.setItem('cinematoken', token);
  }

  public static setUser(user: User) {
    const data = JSON.stringify(user);
    localStorage.setItem('cinemauser', data);
  }

  public static setToken(token: string) {
    localStorage.setItem('cinematoken', token);
  }

  public static getUser(): any {
    const data = localStorage.getItem('cinemauser');
    if (data) {
      return JSON.parse(data);
    } else {
      return null;
    }
  }

  public static getToken(): any {
    const data = localStorage.getItem('cinematoken');
    if (data) {
      return data;
    } else {
      return null;
    }
  }

  public static hasToken(): boolean {
    if (this.getToken()) return true;
    else return false;
  }

  public static clear() {
    localStorage.removeItem('cinemauser');
    localStorage.removeItem('cinematoken');
  }
}
