import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/models/status';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../service/api.service';
import { ProtectedService } from '../service/protected.service';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})

export class AdminComponent implements OnInit{
  public clicked:boolean = false;
  public results!: any;
  public Getmenubyid! : string
  public Menus!: any
  public AddForm!: FormGroup;
  status!:Status;
  
  constructor(private protectedService:ProtectedService, private formBuilder: FormBuilder,private api: ApiService) { }

  ngOnInit(): void {
    this.Callgetmenus();

    // this.protectedService.getAdminData().subscribe({
    //   next: (res)=>{
    //    this.status=res;
    //   },
    //   error: (err)=>{
    //     console.log(err);      }
    // })
    this.init();
   
  }
  private init(): void {
    this.AddForm = this.formBuilder.group({
      menuId:[],
      eventName:[],
      menuName:[],
      menuDesc:[]
    });
  }


  MenuList: any = {
    menuId:'',
    eventName:'',
    menuName:'',
    menuDesc:''
  };

  public PutMenu() {
    console.log(this.MenuList);
    return this.api.PutMenu(this.MenuList.menuId, this.MenuList)
      .subscribe((result) => {
        alert(' Data Updated ');
      });
  }

  menuId!: string;


 public DeleteMenu(): void {
    console.log('hi');
    this.api.DeleteMenu(this.menuId).subscribe((res) => {
      alert('Deleted');
    });
  }

  public PostMenu():void {
    console.log("Give the values");
    this.api.PostMenu(this.AddForm.value).subscribe((result) => {
      alert(' Data Added');
    });
  }
  //  public menuByID!:string;
  public GetMenuId(): void {
    console.log(this.menuId);
    this.api.GetMenu(this.menuId).subscribe((result) => {
      this.results=result;
      this.clicked=true;
      alert(' Details Found ');
      this.openPopup4();
      console.log(this.results);
});
  }
  private Callgetmenus(): void {
    this.api.GetMenus().subscribe(result => {
      this.Menus = result
      console.log(this.Menus);
    });

  }
  openPopup() {
    let popup = document.getElementById('popup');
    popup?.classList.add('open');
  }
  closePopup() {
    let popup = document.getElementById('popup');
    popup?.classList.remove('open');
  }
  openPopup1() {
    let popup = document.getElementById('popup1');
    popup?.classList.add('open');
  }
  closePopup1() {
    let popup = document.getElementById('popup1');
    popup?.classList.remove('open');
  }
  openPopup2() {
    let popup = document.getElementById('popup2');
    popup?.classList.add('open');
  }
  closePopup2() {
    let popup = document.getElementById('popup2');
    popup?.classList.remove('open');
  }
  openPopup3() {
    let popup = document.getElementById('popup3');
    popup?.classList.add('open');
  }
  openPopup4() {
    let popup = document.getElementById('popup4');
    popup?.classList.add('open');
  }
  closePopup3() {
    let popup = document.getElementById('popup3');
    popup?.classList.remove('open');
  }
 
  closePopup4() {
    let popup = document.getElementById('popup4');
    popup?.classList.remove('open');
  }
}




  