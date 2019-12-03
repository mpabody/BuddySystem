import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { RouterModule } from '@angular/router'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatToolbarModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatTableModule
} from '@angular/material';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { AuthService } from './services/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { RegistrationComponent } from './components/registration/registration.component';
import { LoginComponent } from './components/login/login.component';
import { BuddyService } from './services/buddy.service';
import { TripService } from './services/trip.service';
import { BuddyIndexComponent } from './components/buddy/buddy-index/buddy-index.component';
import { BuddyCreateComponent } from './components/buddy/buddy-create/buddy-create.component';
import { BuddyDetailComponent } from './components/buddy/buddy-detail/buddy-detail.component';
import { BuddyEditComponent } from './components/buddy/buddy-edit/buddy-edit.component';
import { BuddyDeleteComponent } from './components/buddy/buddy-delete/buddy-delete.component';
import { TripIndexComponent } from './components/trip/trip-index/trip-index.component';

const routes = [
  { path: 'register', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'trip', component: TripIndexComponent },
  {
    path: 'buddies', children: [
      { path: '', component: BuddyIndexComponent },
      { path: 'create', component: BuddyCreateComponent },
      { path: 'detail/:id', component: BuddyDetailComponent },
      { path: 'edit/:id', component: BuddyEditComponent },
      { path: 'delete/:id', component: BuddyDeleteComponent }
    ]
  },
  // {
  //   path: 'trip', children: [
  //     { path: '', componentt: TripIndexComponent }
  //   ]
  // },

  { path: '**', component: RegistrationComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegistrationComponent,
    LoginComponent,
    BuddyIndexComponent,
    BuddyCreateComponent,
    BuddyDetailComponent,
    BuddyEditComponent,
    BuddyDeleteComponent,
    TripIndexComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule
  ],
  providers: [
    AuthService,
    BuddyService,
    TripService

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
