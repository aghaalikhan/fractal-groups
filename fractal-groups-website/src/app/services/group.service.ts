import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Group } from '../models';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GroupService {

  constructor(private http: HttpClient) {}

  public Get(): Observable<Group[]>  { 
    return this.http.get<Group[]>(`${environment.apiUrl}groups/`);
  }
}
