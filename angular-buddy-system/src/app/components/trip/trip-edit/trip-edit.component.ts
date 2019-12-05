import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TripService } from 'src/app/services/trip.service';
import { Trip } from 'src/app/models/Trip';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';

@Component({
  selector: 'app-trip-edit',
  templateUrl: './trip-edit.component.html',
  styleUrls: ['./trip-edit.component.css']
})
export class TripEditComponent implements OnInit {

  trip: Trip;
  editForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private tripService: TripService, private activatedRoute: ActivatedRoute, private router: Router) { 
    this.activatedRoute.paramMap.subscribe(params => {
      this.tripService.getTrip(params.get('id')).subscribe((trip: Trip) => {
        this.trip = trip;
        this.createForm();
      });
    });
  }

  ngOnInit() {
  }

  createForm() {
    this.editForm = this.formBuilder.group({
      TripId: new FormControl(this.trip.TripId),
      StartTime: new FormControl(this.trip.StartTime),
      BuddyId: new FormControl(this.trip.BuddyId),
      VolunteerId: new FormControl(this.trip.VolunteerId),
      StartLocation: new FormControl(this.trip.StartLocation),
      ProjectedEndLocation: new FormControl(this.trip.ProjectedEndLocation),
      EndLocation: new FormControl(this.trip.EndLocation),
      EndTime: new FormControl(this.trip.EndTime)
    });
  }

  onSubmit() {
    const updatedTrip: Trip = {
      TripId: this.editForm.value.TripId,
      StartTime: this.editForm.value.StartTime,
      BuddyId: this.editForm.value.BuddyId,
      VolunteerId: this.editForm.value.VolunteerId,
      StartLocation: this.editForm.value.StartLocation,
      ProjectedEndLocation: this.editForm.value.ProjectedEndLocation,
      EndLocation: this.editForm.value.EndLocation,
      EndTime: this.editForm.value.EndTime,
      BuddyName: this.editForm.value.BuddyName,
      VolunteerName: this.editForm.value.VolunteerName
    };
    this.tripService.updateTrip(updatedTrip).subscribe(() => {
      this.router.navigate(['/trip']);
    });
  }
}