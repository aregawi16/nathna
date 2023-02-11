import { MatDialog } from '@angular/material/dialog';
import { UserDialogComponent } from './../user-dialog/user-dialog.component';
import { DropDownObject } from 'src/app/core/models/dropDownObject';
import { IdentityService } from './../../identity.service';
import { MatTableDataSource } from '@angular/material/table';
import {SelectionModel} from '@angular/cdk/collections';
import {Component} from '@angular/core';
import { SettingService } from 'src/app/features/setting/setting.service';





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
  displayedColumns: string[] = ['select', 'userName','email', 'fullName', 'officeId'];
  dataSource = new MatTableDataSource<User>();
  selection = new SelectionModel<User>(true, []);
  offices!:DropDownObject[];

  constructor(
    private _identityService:IdentityService,
    public dialog: MatDialog,
    private _settingService:SettingService

    ) { }



  ngOnInit() {

    this.getUsers();
    this.getOffices();
  }
  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.dataSource.data.forEach(row => this.selection.select(row));
  }

  public getUsers()
   {

     this._identityService.getUserList()
       .subscribe(data => {
        this.dataSource = new MatTableDataSource(data);
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

    dialogRef.afterClosed().subscribe(user => {
        if(user){
          // this.get;
        }
        this.getOffices();
    });
}
}


