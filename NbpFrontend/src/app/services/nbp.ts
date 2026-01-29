import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NbpService {
  
  private apiUrl = 'https://localhost:7165/Currencies/fetch';

  constructor(private http: HttpClient) { }

  getRates(date: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}?date=${date}`, {});
  }

  getAllSavedRates(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7165/Currencies');
  }
}
