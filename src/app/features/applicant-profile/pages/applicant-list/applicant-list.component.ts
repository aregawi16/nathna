import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';
import { ApplicantRequiredVerifiedDocumentComponent } from '../applicant-required-verified-document/applicant-required-verified-document.component';
import { Status } from './../../../../core/constants/status.enum';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ConfirmDialogComponent } from './../../../../shared/components/confirm-dialog/confirm-dialog.component';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { SettingService } from 'src/app/features/setting/setting.service';
import { DropDownObject } from 'src/app/core/models/dropDownObject';
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource } from '@angular/material/table';
import { environment } from './../../../../../environments/environment';
import { Religion } from './../../../../core/constants/religion.enum';
import { MaritalStatus } from './../../../../core/constants/marital-status.enum';
import { AddApplicantComponent } from './../add-applicant/add-applicant.component';
import { Component, OnInit, ViewEncapsulation, Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ApplicantProfileService } from '../../services/applicant-profile.service';
import { Gender } from 'src/app/core/constants/gender.enum';
import { faLess } from '@fortawesome/free-brands-svg-icons';
import { ApplicantContractAgreementComponent } from '../applicant-contract-agreement/applicant-contract-agreement.component';
import { YellowCardRequestComponent } from '../yellow-card-request/yellow-card-request.component';
export interface ApplicantProfile {
  id: number;
  applicantProfileId: number;
  applicantProfilename: string;
  password: string;
  fullName: string;
  applicantDocument: ApplicantDocument;
  applicantPlacement:ApplicantPlaceMent

}

export interface ApplicantPlaceMent{
  staus: number;
officeId:number}
export interface ApplicantDocument{
  applicantIdFilePath: string;
  applicantPassportFilePath: string;
}
export interface ApplicantProfileProfile {
  name: string;
  surname: string;
  birthday: Object;
  gender: string;
  image: string;
}

export interface ApplicantProfileWork {
  company: string;
  position: string;
  salary: number;
}

export interface ApplicantProfileContacts{
  email: string;
  phone: string;
  address: string;
}

export interface ApplicantProfileSocial {
  facebook: string;
  twitter: string;
  google: string;
}

export interface ApplicantProfileSettings{
  isActive: boolean;
  isDeleted: boolean;
  registrationDate: string;
  joinedDate: string;
}
@Component({
  selector: 'app-applicant-list',
  templateUrl: './applicant-list.component.html',
  styleUrls: ['./applicant-list.component.scss']
})




@Injectable({ providedIn: 'root' })
export class ApplicantListComponent implements OnInit {
  displayedColumns: string[] = ['select', 'id', 'fullName','phoneNumber', 'passportNumber', 'agentId','status','action'];
  dataSource = new MatTableDataSource<ApplicantProfile>();
  selection = new SelectionModel<ApplicantProfile>(true, []);
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  agents!:DropDownObject[];
  offices!:DropDownObject[];
  placementFormGroup!: FormGroup;
    public applicantProfiles!: ApplicantProfile[];
    public searchText!: string;
    public startDate!: string;
    public endDate!: string;
    public page:any;
    base_url = environment.backend.base_url;
    countries!:{name:string,code:string}[];
    isAnySelected :boolean=false;
    genders!:number[];
    genderList=Gender;
    maritalStatuses!:number[];
    maritalStatusList=MaritalStatus;
    religions!:number[];
    religionList=Religion;
    statuses!:number[];
    statusList=Status;
    host = environment.backend.base_url;
    constructor(
      public _formBuilder: FormBuilder,
                public dialog: MatDialog,
                public _dialogRef: MatDialogRef<any>,
                private _snackBar: MatSnackBar,
                public _applicantService: ApplicantProfileService,
                public _settingService: SettingService,
                public _processManagementService: ProcessManagementService,
                ){
    }

    ngOnInit() {

        this.getApplicantProfiles();
              this.genders= Object.keys(this.genderList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
              this.maritalStatuses= Object.keys(this.maritalStatusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
              this.statuses= Object.keys(this.statusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
              this.religions= Object.keys(this.religionList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));


              this.getAgents();
              this.getOffices();

              this.placementFormGroup = this._formBuilder.group({
                officeId: ['', Validators.required],
                applicantIds: [],

                });
            }

    public getApplicantProfiles(): void {
      this._applicantService.getApplicantRofiles()
      .subscribe(data => {
        this.applicantProfiles = data;
        this.dataSource = new MatTableDataSource(data);

        console.log(data);
      });


    }
    checkDeleteStatus(applicantPlacement:any)
    {
      if(applicantPlacement==null)
      {
        return true;
      }
      else{
        return false;
      }
    }
    checkUploadStatus(applicantPlacement:any)
    {
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==this.statusList.Selected)
        {
          return true;
        }
        return false;
      }
    }
    checkUploadContractStatus(applicantPlacement:any)
    {
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==this.statusList.DocumentVerified)
        {
          return true;
        }
        return false;
      }
    }
    checkVerifyContractStatus(applicantPlacement:any)
    {
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==this.statusList.ContractReady)
        {
          return true;
        }
        return false;
      }
    }
    checkYellowCardStatus(applicantPlacement:any)
    {
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==this.statusList.ContractAgreed)
        {
          return true;
        }
        return false;
      }
    }
   placeApplicant()
  {
    if(this.placementFormGroup.valid)
    {

    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: {
        title: "Confirm Placement",
        message: "Are you sure to assign offices?"
      }
  });
  dialogRef.afterClosed().subscribe(customer => {

      let ids = this.selection.selected.map((obj) => obj.applicantProfileId);

      this.placementFormGroup.controls['applicantIds'].setValue(ids);

    console.log(this.placementFormGroup.value);
    this._applicantService.placeApplicant(this.placementFormGroup.value)
    .subscribe(data => {

          this._snackBar.open('Job added successfully', 'Undo', {
            duration:10000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });
          this.selection.clear();
          this.isAnySelected=false;
    });
  });

}
 }
    public addApplicantProfile(applicantProfile:any){
    }
    public updateApplicantProfile(applicantProfile:any){
    }
    public deleteApplicantProfile(id:any){
      const dialogRef = this.dialog.open(ConfirmDialogComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want remove this Applicant?"
        }
      });
      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){

      this._applicantService.deleteApplicantRofile(id)
      .subscribe(() => {
        const index: number = this.applicantProfiles.findIndex(x => x.applicantProfileId == id);
          if (index !== -1) {
            this.applicantProfiles =   this.applicantProfiles.splice(index, 1);
          }
        // this.applicantProfiles = data;
        // console.log(data);
      });
    }
    });
    }
    public detailApplicantProfile(applicantProfile){
      this._applicantService.getApplicantRofileById(applicantProfile.applicantProfileId)
      .subscribe(data => {
        this.applicantProfiles = data;
        console.log(data);
      });

    }

    public uploadContractDocument(id:any)
    {
      const dialogRef = this.dialog.open(ApplicantContractAgreementComponent, {
        maxWidth: "400",
        data:id

      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){


          this._snackBar.open('Contract Agreement Document uploaded successfully', 'Undo', {
            duration:10000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });

        }
      });

    }
    public verifyContractDocument(id:any)
    {
      const dialogRef = this.dialog.open(ConfirmDialogComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want approve this contract?"
        }
      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){
          let data = {
            "applicantId":id,
             "status":this.statusList.ContractAgreed,
                };

                this._processManagementService.rejectApplicant(data)
                .subscribe(data => {

                      this._snackBar.open('Contract Verified successfully', 'Undo', {
                        duration:10000,
                        horizontalPosition: this.horizontalPosition,
                        verticalPosition: this.verticalPosition,
                      });


                });



          this._dialogRef.close();
        }
      });

    }
    public requestYellowCard(id:any)
    {
      const dialogRef = this.dialog.open(YellowCardRequestComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want approve this contract?"
        }
      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){
          let data = {
            "applicantId":id,
             "status":this.statusList.ContractAgreed,
                };

                this._processManagementService.rejectApplicant(data)
                .subscribe(data => {

                      this._snackBar.open('Contract Verified successfully', 'Undo', {
                        duration:10000,
                        horizontalPosition: this.horizontalPosition,
                        verticalPosition: this.verticalPosition,
                      });


                });



          this._dialogRef.close();
        }
      });

    }

    public uploadVerifiedDocument(id:any)
    {
      const dialogRef = this.dialog.open(ApplicantRequiredVerifiedDocumentComponent, {
        maxWidth: "400",
        data:id

      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){

        }
      });

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

      if(this.selection.selected.length>0)
      {
        this.isAnySelected = true;
      }
      else{
        this.isAnySelected = false;
      }
}

selectRow(row) {
  this.selection.toggle(row);
  this.isAnySelected = true;
  if(this.selection.selected.length>0)
      {
        this.isAnySelected = true;
      }
      else{
        this.isAnySelected = false;
      }

  console.log(this.selection.selected);
}

/** The label for the checkbox on the passed row */
checkboxLabel(row?: ApplicantProfile): string {
console.log(row);
  if (!row) {
    return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
  }
  return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
}
    public getAgents()
    {

      this._settingService.getAgentList()
        .subscribe(data => {
         this.agents = data;
       });
    }

    public getOffices()
    {

      this._settingService.getOfficeList()
        .subscribe(data => {
         this.offices = data;
       });
    }


    public onPageChanged(event){
        this.page = event;
        this.getApplicantProfiles();
        window.scrollTo(0,0);
        // if(this.settings.fixedHeader){
        //     document.getElementById('main-content').scrollTop = 0;
        // }
        // else{
        //     document.getElementsByClassName('mat-drawer-content')[0].scrollTop = 0;
        // }
    }

    public openApplicantProfileDialog(applicantProfile){
        let dialogRef = this.dialog.open(AddApplicantComponent, {
            data: applicantProfile
        });

        dialogRef.afterClosed().subscribe(applicantProfile => {
            if(applicantProfile){
                (applicantProfile.id) ? this.updateApplicantProfile(applicantProfile) : this.addApplicantProfile(applicantProfile);
            }
        });
    }



}
