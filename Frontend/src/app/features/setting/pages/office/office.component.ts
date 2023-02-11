import { DropDownObject } from 'src/app/core/models/dropDownObject';
import { ConfirmDialogComponent } from './../../../../shared/components/confirm-dialog/confirm-dialog.component';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { SettingService } from '../../setting.service';
import { MatTableDataSource } from '@angular/material/table';


export interface Office {
  officeId: number;
  countryId: number;
  name: string;
  code: string;
  isHeadOffice: Boolean;
  remark: string;
}

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.scss']
})



  export class OfficeComponent {

    displayedColumns: string[] = ['id','countryId','code', 'name','isHeadOffice', 'remark','action'];
    dataSource = new MatTableDataSource<any>();
   offices!:Office[];
   countrys!:DropDownObject[];
   isLoading = true;
   horizontalPosition: MatSnackBarHorizontalPosition = 'start';
   verticalPosition: MatSnackBarVerticalPosition = 'bottom';
   pageNumber: number = 1;
     OfficeForm!: FormGroup;
     isEditableNew: boolean = true;
     constructor(
       private fb: FormBuilder,
       public dialog: MatDialog,
       private _snackBar: MatSnackBar,
       private _settingService: SettingService,
       private _formBuilder: FormBuilder){

   }


     ngOnInit(): void {
       this.OfficeForm = this._formBuilder.group({
         OfficeFormRows: this._formBuilder.array([])
       });
       this._settingService.getOffices()
       .subscribe(data => {
         this.offices = data;
         this.OfficeForm = this.fb.group({
           OfficeFormRows: this.fb.array(this.offices.map(val => this.fb.group({
             id: new FormControl(val.officeId),
             countryId: new FormControl(val.countryId),
             code: new FormControl(val.code),
             name: new FormControl(val.name),
             isHeadOffice: new FormControl(val.isHeadOffice),
             remark: new FormControl(val.remark),
             action: new FormControl('existingRecord'),
             isEditable: new FormControl(true),
             isNewRow: new FormControl(false),
           })
           )) //end of fb array
         }); // end of form group cretation
   this.isLoading = false;
   this.dataSource = new MatTableDataSource((this.OfficeForm.get('OfficeFormRows') as FormArray).controls);
   this.dataSource.paginator = this.paginator;

   const filterPredicate = this.dataSource.filterPredicate;
     this.dataSource.filterPredicate = (data: AbstractControl, filter) => {
       return filterPredicate.call(this.dataSource, data.value, filter);
     }

     //Custom filter according to name column
       });

  this.getCountryList();
       // this.dataSource.filterPredicate = (data: {name: string}, filterValue: string) =>
       //   data.name.trim().toLowerCase().indexOf(filterValue) !== -1;
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
       const control = this.OfficeForm.get('OfficeFormRows') as FormArray;
       control.insert(0,this.initiateOfficeForm());
       this.dataSource = new MatTableDataSource(control.controls)
       // control.controls.unshift(this.initiateOfficeForm());
       // this.openPanel(panel);
         // this.table.renderRows();
         // this.dataSource.data = this.dataSource.data;
     }

     // this function will enabled the select field for editd
     EditOfficeForm(OfficeFormElement, i) {

       // OfficeFormElement.get('OfficeFormRows').at(i).get('name').disabled(false)
       OfficeFormElement.get('OfficeFormRows').at(i).get('isEditable').patchValue(false);
       // this.isEditableNew = true;

     }

     // On click of correct button in table (after click on edit) this method will call
     SaveOfficeForm(OfficeFormElement, i) {

       this._settingService.createOffice(OfficeFormElement.get('OfficeFormRows').at(i).value)
       .subscribe(data => {
         OfficeFormElement.get('OfficeFormRows').at(i).controls.id.setValue(data.officeId);

         console.log(data);
         OfficeFormElement.get('OfficeFormRows').at(i).get('isEditable').patchValue(true);

             this._snackBar.open('Office added successfully', 'Undo', {
               duration:10000,
               horizontalPosition: this.horizontalPosition,
               verticalPosition: this.verticalPosition,
             });


       });
     }

     deleteOffice(OfficeFormElement, i) {
       const dialogRef = this.dialog.open(ConfirmDialogComponent, {
         maxWidth: "400px",
         data: {
           title: "Confirm Action",
           message: "Are you sure you want remove this job?"
         }
       });
       dialogRef.afterClosed().subscribe(dialogResult => {
         if(dialogResult){
           this._settingService.deleteOffice(OfficeFormElement.get('OfficeFormRows').at(i).controls.id.value)
           .subscribe( ()=> {
             console.log(this.offices );
             const index: number = this.offices.findIndex(x => x.officeId == OfficeFormElement.get('OfficeFormRows').at(i).controls.id.value);
             if (index !== -1) {
               this.offices =   this.offices.splice(index, 1);
               this._snackBar.open('Office delted successfully', 'Undo', {
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
     CancelOfficeForm(OfficeFormElement, i) {
       OfficeFormElement.get('OfficeFormRows').at(i).get('isEditable').patchValue(true);
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


     initiateOfficeForm(): FormGroup {
       return this.fb.group({

                  id: new FormControl(0),
                  countryId: new FormControl(0),
                  code: new FormControl(''),
                   name: new FormControl(''),
                   isHeadOffice: new FormControl(false),
                   remark: new FormControl(''),
                   action: new FormControl('newRecord'),
                   isEditable: new FormControl(false),
                   isNewRow: new FormControl(true),
       });
     }

   public getCountryList()
   {

     this._settingService.getCountryList()
       .subscribe(data => {
         this.countrys = data;
       });
   }
  }
