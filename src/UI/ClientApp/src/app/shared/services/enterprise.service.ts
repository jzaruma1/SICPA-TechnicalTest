import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EnterpriseService {

  constructor(private http: HttpClient) { }

  getAll(size: number = 10, page: number = 1) {
    return this.http.get(`api/enterprise?size=${size}&page=${page}`);
  }

  get(id: string) {
    return this.http.get(`api/enterprise/${id}`);
  }

  add(entity: any) {
    return this.http.post(`api/enterprise`, entity);
  }

  update(entity: any, id: number) {
    return this.http.put(`api/enterprise/${id}`, entity);
  }
}
