import { DialogRef } from '@angular/cdk/dialog';
import { MatDialog } from '@angular/material/dialog';
import { UserDialogComponent } from './../user-dialog/user-dialog.component';
import { DropDownObject } from 'src/app/core/models/dropDownObject';
import { IdentityService } from './../../identity.service';
import { MatTableDataSource } from '@angular/material/table';
import {SelectionModel} from '@angular/cdk/collections';
import {Component} from '@angular/core';
import { SettingService } from 'src/app/features/setting/setting.service';
import { ConfirmDialogComponent } from 'src/app/shared/components/confirm-dialog/confirm-dialog.component';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';





export interface User {
  id: string;
  userId: string;
  select: string;
  userName: string;
  email: string;
  fullName: string;
  officeId: number;
}


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})



export class UserComponent {
  selection = new SelectionModel<User>(true, []);
  users:any[]=[];
  offices!:DropDownObject[];
  horizontalPosition: MatSnackBarHorizontalPosition = 'end';
  verticalPosition: MatSnackBarVerticalPosition = 'top';
  constructor(
    private _identityService:IdentityService,
    public dialog: MatDialog,
    private _snackBar: MatSnackBar,
    private _settingService:SettingService

    ) { }



  ngOnInit() {

    this.getUsers();
    this.getOffices();
  }


  public getUsers()
   {

     this._identityService.getUserList()
       .subscribe( {
        next:(data)=>{
this.users = data;
        },
        error:(err)=>
        {

        }
      });
   }

  public getOffices()
   {

     this._settingService.getOfficeList()
       .subscribe(data => {
        this.offices = data;
      });
   }

   public openUserDialog(user){
    let dialogRef = this.dialog.open(UserDialogComponent, {
        data: user
    });

    dialogRef.afterClosed().subscribe({
      next:(user)=>{
        this._snackBar.open('User Create Succeed', 'Undo', {
          duration:10000,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });
       // window.location.reload();
        if(user){
         this.users.push(user);
          console.log(user)
         // this.dialog.closeAll();
          this.getOffices();

        }
      },
      error:(err)=>
      {

      }

   });
}
editUser(user:any)
{

}
deleteUser(user:any)
{ const dialogRef = this.dialog.open(ConfirmDialogComponent, {
  maxWidth: "400px",
  data: {
    title: "Confirm Action",
    message: "Are you sure you want remove this user?"
  }
});
dialogRef.afterClosed().subscribe(dialogResult => {
  if(dialogResult){
  this._identityService.deleteUser(user.id)
  .subscribe(data => {
  //  this.offices = data;
 });
}
});
}


}


