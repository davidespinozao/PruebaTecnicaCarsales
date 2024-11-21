import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RickAndMortyService {
  private apiBaseUrl = 'https://localhost:7103/api/rickandmorty'; //.NET backend URL

  constructor(private http: HttpClient) {}

  getCharacters(): Observable<any> {
    return this.http.get(`${this.apiBaseUrl}/characters`);
  }

  getCharacterById(id: number): Observable<any> {
    return this.http.get(`${this.apiBaseUrl}/characters/${id}`);
  }

  getEpisodes(): Observable<any> {
    return this.http.get(`${this.apiBaseUrl}/episodes`);
  }

  getEpisodeById(id: number): Observable<any> {
    return this.http.get(`${this.apiBaseUrl}/episodes/${id}`);
  }

}
