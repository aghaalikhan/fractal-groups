import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  constructor(private http: HttpClient) {}

  public Search(query: string): Observable<Person[]>  {
    return this.http.post<Person[]>(`${environment.apiUrl}search?query=${query}`, null);
  }
}
