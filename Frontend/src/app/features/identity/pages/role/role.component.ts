import { DropDownObject } from 'src/app/core/models/dropDownObject';
import { ConfirmDialogComponent } from './../../../../shared/components/confirm-dialog/confirm-dialog.component';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { IdentityService } from '../../identity.service';

export class Role
{
id:string;
name:string;
description:string;
}
@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})

export class RoleComponent {


  displayedColumns: string[] = ['name', 'description','action'];
    dataSource = new MatTableDataSource<any>();
   roles!:Role[];
   checkeditable = true;
   countrys!:DropDownObject[];
   isLoading = true;
   horizontalPosition: MatSnackBarHorizontalPosition = 'start';
   verticalPosition: MatSnackBarVerticalPosition = 'bottom';
   pageNumber: number = 1;
     RoleForm!: FormGroup;
     isEditableNew: boolean = true;
     constructor(
       private fb: FormBuilder,
       public dialog: MatDialog,
       private _snackBar: MatSnackBar,
       private _identityService: IdentityService,
       private _formBuilder: FormBuilder){

   }


     ngOnInit(): void {
       this.RoleForm = this._formBuilder.group({
         RoleFormRows: this._formBuilder.array([])
       });
       this._identityService.getRoles()
       .subscribe(data => {
         this.roles = data;
         this.RoleForm = this.fb.group({
           RoleFormRows: this.fb.array(this.roles.map(val => this.fb.group({
             id: new FormControl(val.id),
             name: new FormControl(val.name),
             description: new FormControl(val.description),
             action: new FormControl('existingRecord'),
             isEditable: new FormControl(true),
             isNewRow: new FormControl(false),
           })
           )) //end of fb array
         }); // end of form group cretation
   this.isLoading = false;
   this.dataSource = new MatTableDataSource((this.RoleForm.get('RoleFormRows') as FormArray).controls);
   this.dataSource.paginator = this.paginator;

   const filterPredicate = this.dataSource.filterPredicate;
     this.dataSource.filterPredicate = (data: AbstractControl, filter) => {
       return filterPredicate.call(this.dataSource, data.value, filter);
     }

     //Custom filter according to name column
       });

     }

     @ViewChild(MatPaginator) paginator!: MatPaginator;

   goToPage() {
       this.paginator.pageIndex = this.pageNumber - 1;
       this.paginator.page.next({
         pageIndex: this.paginator.pageIndex,
         pageSize: this.paginator.pageSize,
         length: this.paginator.length
       });
     }
     ngAfterViewInit() {
       this.dataSource.paginator = this.paginator;
       this.paginatorList = document.getElementsByClassName('mat-paginator-range-label');

      this.onPaginateChange(this.paginator, this.paginatorList);

      this.paginator.page.subscribe(() => { // this is page change event
        this.onPaginateChange(this.paginator, this.paginatorList);
      });
     }

      applyFilter(event: Event) {
       //  debugger;
       const filterValue = (event.target as HTMLInputElement).value;
       this.dataSource.filter = filterValue.trim().toLowerCase();
     }


     // @ViewChild('table') table: MatTable<PeriodicElement>;
     AddNewRow() {
       // this.getBasicDetails();
       const control = this.RoleForm.get('RoleFormRows') as FormArray;
       control.insert(0,this.initiateRoleForm());
       this.dataSource = new MatTableDataSource(control.controls)
       // control.controls.unshift(this.initiateRoleForm());
       // this.openPanel(panel);
         // this.table.renderRows();
         // this.dataSource.data = this.dataSource.data;
     }

     // this function will enabled the select field for editd
     EditRoleForm(RoleFormElement, i) {

       // RoleFormElement.get('RoleFormRows').at(i).get('name').disabled(false)
       RoleFormElement.get('RoleFormRows').at(i).get('isEditable').patchValue(false);
       // this.isEditableNew = true;

     }

     // On click of correct button in table (after click on edit) this method will call
     SaveRoleForm(RoleFormElement, i) {

       this._identityService.createRole(RoleFormElement.get('RoleFormRows').at(i).value)
       .subscribe(data => {
         RoleFormElement.get('RoleFormRows').at(i).controls.id.setValue(data.id);

         console.log(data);
         RoleFormElement.get('RoleFormRows').at(i).get('isEditable').patchValue(true);

             this._snackBar.open('Role added successfully', 'Undo', {
               duration:10000,
               horizontalPosition: this.horizontalPosition,
               verticalPosition: this.verticalPosition,
             });


       });
     }

     deleteRole(RoleFormElement, i) {
       const dialogRef = this.dialog.open(ConfirmDialogComponent, {
         maxWidth: "400px",
         data: {
           title: "Confirm Action",
           message: "Are you sure you want remove this job?"
         }
       });
       dialogRef.afterClosed().subscribe(dialogResult => {
         if(dialogResult){
           this._identityService.deleteRole(RoleFormElement.get('RoleFormRows').at(i).controls.id.value)
           .subscribe( ()=> {
             console.log(this.roles );
             const index: number = this.roles.findIndex(x => x.id == RoleFormElement.get('RoleFormRows').at(i).controls.id.value);
             if (index !== -1) {
               this.roles =   this.roles.splice(index, 1);
               this._snackBar.open('Role delted successfully', 'Undo', {
                 duration:10000,
                 horizontalPosition: this.horizontalPosition,
                 verticalPosition: this.verticalPosition,
               });
             }
             this.ngOnInit();
           });

         }
       });

     }

     // On click of cancel button in the table (after click on edit) this method will call and reset the previous data
     CancelRoleForm(RoleFormElement, i) {
       RoleFormElement.get('RoleFormRows').at(i).get('isEditable').patchValue(true);
     }


   paginatorList!: HTMLCollectionOf<Element>;
   idx!: number;
   onPaginateChange(paginator: MatPaginator, list: HTMLCollectionOf<Element>) {
        setTimeout((idx) => {
            let from = (paginator.pageSize * paginator.pageIndex) + 1;

            let to = (paginator.length < paginator.pageSize * (paginator.pageIndex + 1))
                ? paginator.length
                : paginator.pageSize * (paginator.pageIndex + 1);

            let toFrom = (paginator.length == 0) ? 0 : `${from} - ${to}`;
            let pageNumber = (paginator.length == 0) ? `0 of 0` : `${paginator.pageIndex + 1} of ${paginator.getNumberOfPages()}`;
            let rows = `Page ${pageNumber} (${toFrom} of ${paginator.length})`;

            if (list.length >= 1)
                list[0].innerHTML = rows;

        }, 0, paginator.pageIndex);
   }


     initiateRoleForm(): FormGroup {
       return this.fb.group({

                  id: new FormControl(""),
                  name: new FormControl(''),
                  description: new FormControl(''),
                   action: new FormControl('newRecord'),
                   isEditable: new FormControl(false),
                   isNewRow: new FormControl(true),
       });
     }

}
