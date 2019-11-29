import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const Api_Url = 'https://localhost:44365'

@Injectable({
  providedIn: 'root'
})
export class BuddyService {

  constructor(private http: HttpClient) { }

  getAllBuddies() {
    return this.http.get(`${Api_Url}/api/buddy`, { headers: this.getHeaders() });
  }

  private getHeaders() {
    return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('id_token')}`);
  }
}
