import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private http: HttpClient) { }

  getAll(size: number = 10, page: number = 1) {
    return this.http.get(`${environment.apiUrl}department?size=${size}&page=${page}`);
  }

  get(id: string) {
    return this.http.get(`${environment.apiUrl}department/${id}`);
  }

  add(entity: any) {
    return this.http.post(`${environment.apiUrl}department`, entity);
  }

  update(entity: any, id: number) {
    return this.http.put(`${environment.apiUrl}department/${id}`, entity);
  }
}
