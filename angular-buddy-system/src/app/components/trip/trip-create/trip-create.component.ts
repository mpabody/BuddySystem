import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, ControlContainer } from '@angular/forms';
import { TripService } from 'src/app/services/trip.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-trip-create',
  templateUrl: './trip-create.component.html',
  styleUrls: ['./trip-create.component.css']
})
export class TripCreateComponent implements OnInit {

tripForm: FormGroup;

  constructor(private form: FormBuilder, private tripService: TripService, private router: Router) {
    this.createForm();
   }

  ngOnInit() {
  }

  createForm() {
    this.tripForm = this.form.group({
      StartTime: new FormControl,
      BuddyId: new FormControl,
      VolunteerId: new FormControl,
      StartLocation: new FormControl,
      ProjectedEndLocation: new FormControl,
      EndLocation: new FormControl,
      EndTime: new FormControl
    })
  }

  onSubmit() {
    this.tripService.createTrip(this.tripForm.value).subscribe(() => {
      this.router.navigate(['/trip']);
    })
  }
}
