import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SignupService } from '../service/signup.service';
import { ApiService } from '../service/api.service';

@Component({
  selector: 'app-doctor-page',
  templateUrl: './doctor-page.component.html',
  styleUrls: ['./doctor-page.component.css']
})
export class DoctorspageComponent {
  constructor(private api:ApiService,
    private formBuilder: FormBuilder,
    private signup:SignupService
    ){}
  ngOnInit(): void {
    this.getAllDoctors()
  }
  AddForm!:FormGroup
  DDoctors!:any

  private getAllDoctors(): void {
    this.api.GetAppointmentDetails().subscribe((result: any) => {
      this.DDoctors = result
      console.log(this.DDoctors)
    });
  }


  public Add(doctor:any): void {
    this.signup.signup(doctor).subscribe({
      next: (res) => {
        console.log(res);
        this.del(doctor)
      }
    })
  }

  public del(doctor:any):void{
    console.log(doctor)

    this.api.DeleteDoctorDetails(doctor.id).subscribe((res: any) => {
      alert('Deleted');
    });
  }
}