import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Buddy } from '../models/Buddy';

const Api_Url = 'https://localhost:44365'

@Injectable({
  providedIn: 'root'
})
export class BuddyService {

  constructor(private http: HttpClient) { }

  getAllBuddies() {
    return this.http.get(`${Api_Url}/api/buddy`, { headers: this.getHeaders() });
  }

  createBuddy(buddy: Buddy) {
    return this.http.post(`${Api_Url}/api/buddy`, buddy, { headers: this.getHeaders() });
  }

  private getHeaders() {
    return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('id_token')}`);
  }
}
