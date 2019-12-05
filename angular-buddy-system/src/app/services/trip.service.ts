import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Trip } from '../models/Trip'

const Api_Url = 'https://localhost:44365'

@Injectable({
  providedIn: 'root'
})
export class TripService {

  constructor(private http: HttpClient) { }

  getTrips() {
    return this.http.get(`${Api_Url}/api/trip/TripsForAllUsers`, { headers: this.getHeaders() });
  }

  getTrip(id) {
    return this.http.get(`${Api_Url}/api/trip/${id}`, {headers: this.getHeaders() });
  }

  createTrip(trip: Trip) {
    return this.http.post(`${Api_Url}/api/trip/CreateTrip`, trip, { headers: this.getHeaders() })
  }

  private getHeaders() {
    return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('id_token')}`);
  }
}
