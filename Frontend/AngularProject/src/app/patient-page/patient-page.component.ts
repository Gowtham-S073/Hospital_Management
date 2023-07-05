import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { validPattern } from '../Helpers/patter-match.validator';
import { MustMatch } from '../Helpers/must-match.validator';
import { Status } from 'src/app/models/status';
import { Router } from '@angular/router';
import { ApiService } from '../service/api.service';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-patient-page',
  templateUrl: './patient-page.component.html',
  styleUrls: ['./patient-page.component.css']
})
export class PatientPageComponent {
  patientForm!: FormGroup;
  DDoctors!: any
  prdtlist!: any

  constructor(private formBuilder: FormBuilder,
    private api: ApiService,
    private router: Router) { }

  ngOnInit() {
    this.patientForm = this.formBuilder.group({
      patientName: ['', Validators.required],
      sex: ['', Validators.required],
      age: ['', Validators.required],
      date: ['', Validators.required],
      doctorId: ['']
    });

    this.prdtlist = this.formBuilder.group({
      name: [],
      sex: [],
      specialization: [],
      experience: [],
      phoneNumber: []

    })
    this.getDoctors();
  }

  onSubmit() {

  }

  public getDoctors(): void {
    this.api.GetAllDoctorDetails().subscribe((result) => {
      this.DDoctors = result
    })
  }


  public Add(): void {
    console.log(this.patientForm);

    this.api.PostAppointment(this.patientForm.value).subscribe((result) => {
      let showAlert = true;
      alert("Appointment Booked");
      setTimeout(() => {
        showAlert = false;
      }, 3000);

      setTimeout(() => {
        if (!showAlert) {
          console.log("Appointment closed");
          window.location.reload();
        }
      }, 4000);
    })
  }
}


