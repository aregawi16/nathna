import { ConfirmDialogComponent } from './../../../../shared/components/confirm-dialog/confirm-dialog.component';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { SettingService } from '../../setting.service';
import { MatTableDataSource } from '@angular/material/table';

export interface Agent {
  agentId: number;
  fullName: string;
  code: string;
  phoneNumber: string;
  description: string;

}


@Component({
  selector: 'app-agent',
  templateUrl: './agent.component.html',
  styleUrls: ['./agent.component.scss']
})

export class AgentComponent {

  displayedColumns: string[] = ['id','code', 'fullName', 'phoneNumber','description','action'];
  dataSource = new MatTableDataSource<any>();
 agents!:Agent[];
 isLoading = true;
 horizontalPosition: MatSnackBarHorizontalPosition = 'start';
 verticalPosition: MatSnackBarVerticalPosition = 'bottom';
 pageNumber: number = 1;
   AgentForm!: FormGroup;
   isEditableNew: boolean = true;
   constructor(
     private fb: FormBuilder,
     public dialog: MatDialog,
     private _snackBar: MatSnackBar,
     private _settingService: SettingService,
     private _formBuilder: FormBuilder){

 }


   ngOnInit(): void {
     this.AgentForm = this._formBuilder.group({
       AgentFormRows: this._formBuilder.array([])
     });
     this._settingService.getAgents()
     .subscribe(data => {
       this.agents = data;
       this.AgentForm = this.fb.group({
         AgentFormRows: this.fb.array(this.agents.map(val => this.fb.group({
           id: new FormControl(val.agentId),
           code: new FormControl(val.code),
           fullName: new FormControl(val.fullName),
           phoneNumber: new FormControl(val.phoneNumber),
           description: new FormControl(val.description),
           action: new FormControl('existingRecord'),
           isEditable: new FormControl(true),
           isNewRow: new FormControl(false),
         })
         )) //end of fb array
       }); // end of form group cretation
 this.isLoading = false;
 this.dataSource = new MatTableDataSource((this.AgentForm.get('AgentFormRows') as FormArray).controls);
 this.dataSource.paginator = this.paginator;

 const filterPredicate = this.dataSource.filterPredicate;
   this.dataSource.filterPredicate = (data: AbstractControl, filter) => {
     return filterPredicate.call(this.dataSource, data.value, filter);
   }

   //Custom filter according to name column
     });


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
     const control = this.AgentForm.get('AgentFormRows') as FormArray;
     control.insert(0,this.initiateAgentForm());
     this.dataSource = new MatTableDataSource(control.controls)
     // control.controls.unshift(this.initiateAgentForm());
     // this.openPanel(panel);
       // this.table.renderRows();
       // this.dataSource.data = this.dataSource.data;
   }

   // this function will enabled the select field for editd
   EditAgentForm(AgentFormElement, i) {

     // AgentFormElement.get('AgentFormRows').at(i).get('name').disabled(false)
     AgentFormElement.get('AgentFormRows').at(i).get('isEditable').patchValue(false);
     // this.isEditableNew = true;

   }

   // On click of correct button in table (after click on edit) this method will call
   SaveAgentForm(AgentFormElement, i) {

     this._settingService.createAgent(AgentFormElement.get('AgentFormRows').at(i).value)
     .subscribe(data => {
       AgentFormElement.get('AgentFormRows').at(i).controls.id.setValue(data.agentId);

       console.log(data);
       AgentFormElement.get('AgentFormRows').at(i).get('isEditable').patchValue(true);

           this._snackBar.open('Agent added successfully', 'Undo', {
             duration:10000,
             horizontalPosition: this.horizontalPosition,
             verticalPosition: this.verticalPosition,
           });


     });
   }

   deleteJob(AgentFormElement, i) {
     const dialogRef = this.dialog.open(ConfirmDialogComponent, {
       maxWidth: "400px",
       data: {
         title: "Confirm Action",
         message: "Are you sure you want remove this job?"
       }
     });
     dialogRef.afterClosed().subscribe(dialogResult => {
       if(dialogResult){
         this._settingService.deleteAgent(AgentFormElement.get('AgentFormRows').at(i).controls.id.value)
         .subscribe( ()=> {
           console.log(this.agents );
           const index: number = this.agents.findIndex(x => x.agentId == AgentFormElement.get('AgentFormRows').at(i).controls.id.value);
           if (index !== -1) {
             this.agents =   this.agents.splice(index, 1);
             this._snackBar.open('Agent deleted successfully', 'Undo', {
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
   CancelAgentForm(AgentFormElement, i) {
     AgentFormElement.get('AgentFormRows').at(i).get('isEditable').patchValue(true);
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


   initiateAgentForm(): FormGroup {
     return this.fb.group({

                 id: new FormControl(121),
                 code: new FormControl(''),
                 fullName: new FormControl(''),
                 phoneNumber: new FormControl(''),
                 description: new FormControl(''),
                 action: new FormControl('newRecord'),
                 isEditable: new FormControl(false),
                 isNewRow: new FormControl(true),
     });
   }

 public getAgentList()
 {

   this._settingService.getAgents()
     .subscribe(data => {
       this.agents = data;
     });
 }
}
