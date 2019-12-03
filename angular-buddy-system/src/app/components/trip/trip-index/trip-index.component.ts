import { Component, OnInit } from '@angular/core';
import { TripService } from 'src/app/services/trip.service';
import { Trip } from 'src/app/models/Trip';
import { MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-trip-index',
  templateUrl: './trip-index.component.html',
  styleUrls: ['./trip-index.component.css']
})
export class TripIndexComponent implements OnInit {

  columnNames = ['details', 'TripId', 'StartTime', 'BuddyId', 'BuddyName', 'VolunteerId', 'Volunteer', 'StartLocation', 'ProjectedEndLocation', 'EndLocation', 'EndTime', 'Description', 'buttons'];

  dataSource: MatTableDataSource<Trip>;


  constructor(private tripService: TripService) { }

  ngOnInit() {
    this.tripService.getTrips().subscribe((trips: Trip[]) => {
      this.dataSource = new MatTableDataSource<Trip>(trips);
    });
  }

}
