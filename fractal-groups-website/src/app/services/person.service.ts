import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private http: HttpClient) {}

  public AddPerson(person: Person): Observable<void>  {
    return this.http.post<void>(`${environment.apiUrl}persons/`, person);
  }
}
