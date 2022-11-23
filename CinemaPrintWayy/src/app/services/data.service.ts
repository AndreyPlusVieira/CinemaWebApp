import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  Movie,
  RequestMovie,
  ResponseById,
  ResponseMovies,
  ResponseMoviesById,
  ResponseMoviesUpdate,
  Value,
} from '../models/Movies';
import { ResponseRooms } from '../models/Rooms';
import {
  RequestSession,
  ResponseSession,
  ResponseSessionById,
  ResponseSessionUpdate,
} from '../models/Session';
import { Security } from '../util/security.util';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  public url = 'https://localhost:7116';

  constructor(private http: HttpClient) {}

  public composeHeaders() {
    const token = Security.getToken();
    const headers = new HttpHeaders().set('Authorization', `bearer ${token}`);
    return headers;
  }

  authenticate(data: any): Observable<any> {
    return this.http.post<any>(`${this.url}/api/create-token`, data);
  }

  // --------- MOVIES ----------

  getMovies(): Observable<ResponseMovies> {
    return this.http.get<ResponseMovies>(`${this.url}/api/get-movie-all`, {
      headers: this.composeHeaders(),
    });
  }

  getMoviesById(id: any): Observable<ResponseMoviesById> {
    const _url = `${this.url}/api/get-movie/${id}`;
    return this.http.get<ResponseMoviesById>(_url, {
      headers: this.composeHeaders(),
    });
  }

  createMovie(request: RequestMovie): Observable<ResponseMovies> {
    return this.http.post<ResponseMovies>(
      `${this.url}/api/add-movie`,
      request,
      {
        headers: this.composeHeaders(),
      }
    );
  }

  updateMovie(
    id: any,
    request: RequestMovie
  ): Observable<ResponseMoviesUpdate> {
    const _url = `${this.url}/api/update-movie/${id}`;
    return this.http.put<ResponseMoviesUpdate>(_url, request, {
      headers: this.composeHeaders(),
    });
  }

  deleteMovie(id: string): Observable<ResponseMovies> {
    const _url = `${this.url}/api/delete-movie/${id}`;

    return this.http.delete<ResponseMovies>(_url, {
      headers: this.composeHeaders(),
    });
  }

  // --------- SESSION ----------

  getSessionByMovieId(id: any): Observable<ResponseSession> {
    const _url = `${this.url}/api/get-sessions-movie/${id}`;
    return this.http.get<ResponseSession>(_url, {
      headers: this.composeHeaders(),
    });
  }

  getSession(): Observable<ResponseSession> {
    return this.http.get<ResponseSession>(`${this.url}/api/get-session-all`, {
      headers: this.composeHeaders(),
    });
  }

  getSessionById(id: any): Observable<ResponseSessionById> {
    const _url = `${this.url}/api/get-session/${id}`;
    return this.http.get<ResponseSessionById>(_url, {
      headers: this.composeHeaders(),
    });
  }

  createSession(request: RequestSession): Observable<ResponseSessionById> {
    return this.http.post<ResponseSessionById>(
      `${this.url}/api/add-session`,
      request,
      {
        headers: this.composeHeaders(),
      }
    );
  }

  updateSession(
    id: any,
    request: RequestSession
  ): Observable<ResponseSessionUpdate> {
    const _url = `${this.url}/api/update-session/${id}`;
    return this.http.put<ResponseSessionUpdate>(_url, request, {
      headers: this.composeHeaders(),
    });
  }

  deleteSession(id: string): Observable<ResponseSessionUpdate> {
    const _url = `${this.url}/api/delete-session/${id}`;

    return this.http.delete<ResponseSessionUpdate>(_url, {
      headers: this.composeHeaders(),
    });
  }

  // --------- ROOMS ----------

  getRooms(): Observable<ResponseRooms> {
    return this.http.get<ResponseRooms>(`${this.url}/api/get-rooms-all`, {
      headers: this.composeHeaders(),
    });
  }

  // -------------- IMAGE MOVIE -------------------

  postUpload(eventId: number, file: File): Observable<Movie> {
    const i_url = `${this.url}/api/upload-image/${eventId}`;
    const fileToUpload = file as File;
    const formData = new FormData();
    formData.append('file', fileToUpload);
    return this.http.post<Movie>(i_url, formData, {
      headers: this.composeHeaders(),
    });
  }
}
