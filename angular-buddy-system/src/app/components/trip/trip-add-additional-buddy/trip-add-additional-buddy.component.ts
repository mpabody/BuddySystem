import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, ControlContainer } from '@angular/forms';
import { TripService } from 'src/app/services/trip.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-trip-add-additional-buddy',
  templateUrl: './trip-add-additional-buddy.component.html',
  styleUrls: ['./trip-add-additional-buddy.component.css']
})
export class TripAddAdditionalBuddyComponent implements OnInit {

  addAdditionalBuddyForm: FormGroup;

  constructor(private form: FormBuilder, private tripService: TripService, private router: Router) {
    this.createForm();
   }

  ngOnInit() {
  }

createForm() {
  this.addAdditionalBuddyForm = this.form.group({
    BuddyId: new FormControl,
    TripId: new FormControl
    })
  }

  onSubmit() {
    this.tripService.addAdditionalBuddy(this.addAdditionalBuddyForm.value).subscribe(() => {
      this.router.navigate(['/trip'])
    })
  }
}
