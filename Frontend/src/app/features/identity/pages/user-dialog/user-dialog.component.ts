import { DropDownObject } from './../../../../core/models/dropDownObject';
import { SettingService } from './../../../setting/setting.service';
import { IdentityService } from './../../identity.service';
import { Office } from './../../../setting/pages/office/office.component';
import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UntypedFormGroup, UntypedFormBuilder, Validators} from '@angular/forms';
import { User } from '../user/user.model';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ConfirmedValidator } from './confirmed-validator.service';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.scss']
})
export class UserDialogComponent implements OnInit {
  public userSignupform:UntypedFormGroup;
  public passwordHide:boolean = true;
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  offices!:DropDownObject[];

  constructor(public dialogRef: MatDialogRef<UserDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public user: User,
              private _identityService:IdentityService,
              private _snackBar: MatSnackBar,
              private _settingService:SettingService,
              public fb: UntypedFormBuilder) {
    this.userSignupform = this.fb.group({
      id: null,
      firstName: [null, Validators.compose([Validators.required])],
      middleName: [null, Validators.compose([Validators.required])],
      lastName: [null, Validators.compose([Validators.required])],
      email: [null, Validators.compose([Validators.required])],
      officeId: [null, Validators.compose([Validators.required])],
      userName: [null, Validators.compose([Validators.required, Validators.minLength(5)])],
      password: [null, Validators.compose([Validators.required, Validators.minLength(6)])],
      confirmPassword: ['', [Validators.required]]


    }, {
      validator: ConfirmedValidator('password', 'confirmPassword')
    });
  }

  ngOnInit() {
    if(this.user){
      this.userSignupform.setValue(this.user);
    }
    else{
      this.user = new User();

    }
    this.getOffices();
  }
  get f(){
    return this.userSignupform.controls;
  }
  public getOffices()
  {

    this._settingService.getOfficeList()
      .subscribe(data => {
       this.offices = data;
     });
  }

  public createUser()
   {

     this._identityService.createUser(this.userSignupform.value)
       .subscribe({
        next:(user)=>{
          //if(user){
            this.dialogRef.close();
            return user;
          //}
        },
        error:(err)=>
        {
          this._snackBar.open('User Create Failed', 'Undo', {
            duration:10000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
        }
      });
   }

  close(): void {

    this.dialogRef.close();
  }

}
