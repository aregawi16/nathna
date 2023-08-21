import { CocComponent } from './../coc/coc.component';
import { VerifyFlightTicketComponent } from './../verify-flight-ticket/verify-flight-ticket.component';
import { CompleteInsuranceDocumentComponent } from './../complete-insurance-document/complete-insurance-document.component';
import { VerfContractDocumentComponent } from './../verf-contract-document/verf-contract-document.component';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';
import { ApplicantRequiredVerifiedDocumentComponent } from '../applicant-required-verified-document/applicant-required-verified-document.component';
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
import { Component, OnInit, ViewEncapsulation, Injectable, Input, ChangeDetectorRef, ChangeDetectionStrategy,AfterViewChecked, AfterViewInit, AfterContentChecked, AfterContentInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ApplicantProfileService } from '../../services/applicant-profile.service';
import { Gender } from 'src/app/core/constants/gender.enum';
import { ApplicantContractAgreementComponent } from '../applicant-contract-agreement/applicant-contract-agreement.component';
import { YellowCardRequestComponent } from '../yellow-card-request/yellow-card-request.component';
import { ApplicantPreFlightTrainingStatus, Status } from '../../model/Status.enum';
import { ApplicantPlacementStatus, ApplicantInsuranceStatus, ApplicantLabourStatus, ApplicantTicketStatus, ApplicantContractStatus, ApplicantCocStatus } from './../../model/Status.enum';
import { ReceiveYellowCardComponent } from '../receive-yellow-card/receive-yellow-card.component';
import { AuthService } from 'src/app/features/auth/services/auth.service';
import { Observable } from 'rxjs';

export interface ApplicantProfile {
  id: number;
  applicantProfileId: number;
  applicantProfilename: string;
  password: string;
  fullName: string;
  officeLevel: string;
  status: string;
  applicantDocument: ApplicantDocument;
  applicantPlacement:ApplicantPlaceMent
  isDeleted:Boolean

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
  // changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-applicant-list',
  templateUrl: './applicant-list.component.html',
  styleUrls: ['./applicant-list.component.scss']
})




@Injectable({ providedIn: 'root' })
export class ApplicantListComponent implements OnInit,AfterViewInit,AfterContentInit,AfterContentChecked {
  displayedColumns: string[] = ['select', 'id', 'fullName','phoneNumber', 'passportNumber', 'agentId','process','status','action'];
  dataSource = new MatTableDataSource<ApplicantProfile>();
  @Input() candidateType :any;
  @Input() pageNumber :any;
  @Input() totalItems :any;
  @Input() applicantProfiles :any[];

  selection = new SelectionModel<ApplicantProfile>(true, []);
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  agents!:DropDownObject[];
  offices!:DropDownObject[];
  applicantPlacementStatuses!:number[];
  applicantPlacementStatusList=ApplicantPlacementStatus;
  applicantContractStatuses!:number[];
  applicantContractStatusList=ApplicantContractStatus;
  applicantInsuranceStatuses!:number[];
  applicantInsuranceStatusList=ApplicantInsuranceStatus;
  applicantCoCStatuses!:number[];
  applicantCoCStatusList=ApplicantCocStatus;
  applicantPreFligtTrainingStatuses!:number[];
  applicantPreFligtTrainingStatusList=ApplicantPreFlightTrainingStatus;
  applicantLabourOfficeStatuses!:number[];
  applicantLabourOfficeStatusList=ApplicantLabourStatus;
  applicantFlightTicketStatuses!:number[];
  applicantFlightTicketStatuseList=ApplicantTicketStatus;


  placementFormGroup!: FormGroup;
    public searchText!: string;
    public startDate!: string;
    public endDate!: string;
    // public page:any;

    base_url = environment.backend.base_url;
    countries!:{name:string,code:string}[];
    isAnySelected :boolean=false;
    isHeadOffice:boolean=true;
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
                private _authService: AuthService,
                private cdr: ChangeDetectorRef,
                public _processManagementService: ProcessManagementService,
                ){
    }

    ngOnInit() {

      this.genders= Object.keys(this.genderList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
              this.maritalStatuses= Object.keys(this.maritalStatusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
              this.statuses= Object.keys(this.statusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
              this.religions= Object.keys(this.religionList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));

              this.isHeadOffice = this._authService.isHeadOffice();

              this.getAgents();
              this.getOffices();

              this.placementFormGroup = this._formBuilder.group({
                officeId: ['', Validators.required],
                applicantIds: [],

                });

                this.dataSource = new MatTableDataSource( this.applicantProfiles);

            }
            ngAfterViewInit(): void {
              //Called after ngAfterContentInit when the component's view has been initialized. Applies to components only.
              //Add 'implements AfterViewInit' to the class.
               this.cdr.detectChanges();
             // this.getApplicantProfiles(0);

              setTimeout(() => {
                this.cdr.detectChanges(); /*cdRef injected in constructor*/
              }, 0)
            }
            ngAfterContentChecked(): void {
              this.cdr.detectChanges();
           }
            ngAfterContentInit()
            {
              this.cdr.detectChanges();

            }


    checkRejectStatus(applicantPlacement:any)
    {
      if(applicantPlacement!=null)
      {
        return true;
      }
      else{
        return false;
      }
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



    checkReceieveContractStatus(applicantPlacement:any)
    {
      let status = this.applicantContractStatusList[this.applicantContractStatusList.Ready];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status)
        {
          return true;
        }
        return false;
      }
    }
    checkVerifyContractStatus(applicantPlacement:any)
    {
      let status = this.applicantContractStatusList[this.applicantContractStatusList.Received];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status)
        {
          return true;
        }
        return false;
      }
    }
    checkInsuranceStatus(applicantPlacement:any)
    {
      let officeLevel = this.statusList[this.statusList.ContractAgreement];
      let status = this.applicantContractStatusList[this.applicantContractStatusList.Verified];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status&&applicantPlacement.officeLevel==officeLevel)
        {
          return true;
        }
        return false;
      }
    }
    checkCocStatus(applicantPlacement:any)
    {
      let officeLevel = this.statusList[this.statusList.Insurance];
      let status = this.applicantInsuranceStatusList[this.applicantInsuranceStatusList.Completed];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status&&applicantPlacement.officeLevel==officeLevel)
        {
          return true;
        }
        return false;
      }
    }
    checkCompleteInsuranceStatus(applicantPlacement:any)
    {
      let status = this.applicantInsuranceStatusList[this.applicantInsuranceStatusList.Requested];
      let officeLevel = this.statusList[this.statusList.Insurance];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status&& applicantPlacement.officeLevel==officeLevel)
        {
          return true;
        }
        return false;
      }
    }
    checkCompleteCocStatus(applicantPlacement:any)
    {
      let status = this.applicantCoCStatusList[this.applicantCoCStatusList.Requested];
      let officeLevel = this.statusList[this.statusList.CoC];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status&& applicantPlacement.officeLevel==officeLevel)
        {
          return true;
        }
        return false;
      }
    }
    checkRequestYellowCardStatus(applicantPlacement:any)
    {
      let officeLevel = this.statusList[this.statusList.PreFlightTraining];
      let status = this.applicantCoCStatusList[this.applicantPreFligtTrainingStatusList.Completed];
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status&& applicantPlacement.officeLevel==officeLevel)
        {
          return true;
        }
        return false;
      }
    }

    checkGetYellowCardStatus(applicantPlacement:any)
    {
      let officeLevel = this.statusList[this.statusList.MinistryOfLabor];
      let status = this.applicantFlightTicketStatuseList[this.applicantFlightTicketStatuseList.Requested];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status && applicantPlacement.officeLevel==officeLevel)
        {
          return true;
        }
        return false;
      }
    }

    checkTicketStatus(applicantPlacement:any)
    {
      let officeLevel = this.statusList[this.statusList.Ticket];
      let status = this.applicantFlightTicketStatuseList[this.applicantFlightTicketStatuseList.Requested];
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status&&applicantPlacement.officeLevel==officeLevel)
        {
          return true;
        }
        return false;
      }
    }
    checkFlightStatus(applicantPlacement:any)
    {
      let officeLevel = this.statusList[this.statusList.Ticket];
      let status = this.applicantFlightTicketStatuseList[this.applicantFlightTicketStatuseList.Verified];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status&&applicantPlacement.officeLevel ==officeLevel)
        {
          return true;
        }
        return false;
      }
    }
    checkArrivalStatus(applicantPlacement:any)
    {
      let status = this.applicantFlightTicketStatuseList[this.applicantFlightTicketStatuseList.Flighted];

      if(applicantPlacement==null)
      {
        return false;
      }
      else{
        if(applicantPlacement.status==status)
        {
          return true;
        }
        return false;
      }
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
    checkUploadStatus(applicantStatus:any)
    {
      let status = this.applicantPlacementStatusList[this.applicantPlacementStatusList.Selected];
      let status2 = this.applicantPlacementStatusList[this.applicantPlacementStatusList.Assigned];

        if(applicantStatus?.status==status||applicantStatus?.status==status2||applicantStatus==null)
        {
          return true;
        }
        return false;

    }

    checkContractStatus(applicantProfile:any)
    {
    let status = this.applicantPlacementStatusList[this.applicantPlacementStatusList.DocumentVerified];
      if(applicantProfile.applicantStatuses==null)
      {
        return false;
      }
      else{
      if(applicantProfile.applicantStatuses[0]?.status==status)
      {
        console.log(applicantProfile);
        return true;
      }
      return false;
    }

}
public uploadContractDocument(id:any)
{
  const dialogRef = this.dialog.open(ApplicantContractAgreementComponent, {
    maxWidth: "400",
    data:id

  });

  dialogRef.afterClosed().subscribe(dialogResult => {
    if(dialogResult){

    }
  });


}
public receiveYellowCard(id:any)
{
  const dialogRef = this.dialog.open(ReceiveYellowCardComponent, {
    maxWidth: "400",
    data:id

  });

  dialogRef.afterClosed().subscribe(dialogResult => {
    if(dialogResult){

    }
  });


}
public verifyFlightTicket(id:any)
{
  const dialogRef = this.dialog.open(VerifyFlightTicketComponent, {
    maxWidth: "400",
    data:id

  });

  dialogRef.afterClosed().subscribe(dialogResult => {
    if(dialogResult){

    }
  });


}
public startFlight(id:any)
{

    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      maxWidth: "400px",
      data: {
        title: "Confirm Action",
        message: "Are you sure the applicant is starting his flight?"
      }
    });
    dialogRef.afterClosed().subscribe(dialogResult => {
      if(dialogResult){
  let data = {
"applicantId":id,
"status":this.applicantFlightTicketStatuseList.Flighted,
  };

  this._processManagementService.followFlight(data)
  .subscribe(data => {

        this._snackBar.open('Applicant started Flight', 'Undo', {
          duration:10000,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });


  });
}
    });

}
public confirmArrival(id:any)
{
  const dialogRef = this.dialog.open(ConfirmDialogComponent, {
    maxWidth: "400px",
    data: {
      title: "Confirm Action",
      message: "Are you sure you want select this Applicant?"
    }
  });
  dialogRef.afterClosed().subscribe(dialogResult => {
    if(dialogResult){
let data = {
"applicantId":id,
"status":this.applicantFlightTicketStatuseList.Arrived,
};

this._processManagementService.followFlight(data)
.subscribe(data => {

      this._snackBar.open('Applicant started Flight', 'Undo', {
        duration:10000,
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });


});
}
  });


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

          this._snackBar.open('Office assigned successfully', 'Undo', {
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
      const index: number = this.applicantProfiles.findIndex(x => x.applicantProfileId == applicantProfile.applicantProfileId);
      if (index !== -1) {
        this.applicantProfiles.splice(index, 1,applicantProfile);
      }
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
              this.applicantProfiles.splice(index, 1);
          }
        // this.applicantProfiles = data;
        // console.log(data);
      });
    }
    });
    }

    public rejectApplicantProfile(id:any){
      const dialogRef = this.dialog.open(ConfirmDialogComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want reject this Applicant?"
        }
      });
      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){

      this._applicantService.rejectApplicantRofile(id)
      .subscribe(() => {
        const index: number = this.applicantProfiles.findIndex(x => x.applicantProfileId == id);
          if (index !== -1) {
              this.applicantProfiles.splice(index, 1);
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


    public receieveContractDocument(id:any)
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
             "status":this.applicantContractStatusList.Received,
                };

                this._processManagementService.updateContractStatus(data)
                .subscribe(data => {

                      this._snackBar.open('Contract Verified successfully', 'Undo', {
                        duration:10000,
                        horizontalPosition: this.horizontalPosition,
                        verticalPosition: this.verticalPosition,
                      });

                      this._dialogRef.close();

                });



        }
      });

    }
    public requestInsurance(id:any)
    {
      const dialogRef = this.dialog.open(ConfirmDialogComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want request this insurance?"
        }
      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){
          let data = {
            "applicantId":id,
             "status":this.applicantInsuranceStatusList.Requested,
                };

                this._processManagementService.requestInsurance(data)
                .subscribe(data => {

                      this._snackBar.open('Insurance requested successfully', 'Undo', {
                        duration:10000,
                        horizontalPosition: this.horizontalPosition,
                        verticalPosition: this.verticalPosition,
                      });

                      this._dialogRef.close();

                });



        }
      });

    }
    public verifyContractDocument(id:any)
    {
      const dialogRef = this.dialog.open(VerfContractDocumentComponent, {
        maxWidth: "400",
        data:id

      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){

        }
      });

    }
    public completeInsurance(id:any)
    {
      const dialogRef = this.dialog.open(CompleteInsuranceDocumentComponent, {
        maxWidth: "400",
        data:id

      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){

        }
      });

    }
    public completeCoc(id:any)
    {
      const dialogRef = this.dialog.open(CocComponent, {
        maxWidth: "500",
        maxHeight:"500",
        data:id

      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){

        }
      });

    }
    public requestYellowCard(id:any)
    {
      const dialogRef = this.dialog.open(YellowCardRequestComponent, {
        maxWidth: "400px",
          data:id

      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){
          let data = {
            "applicantId":id,
             "status":this.statusList.ContractAgreement,
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




    public openApplicantProfileDialog(applicantProfile){
        let dialogRef = this.dialog.open(AddApplicantComponent, {
            data: applicantProfile
        });

        dialogRef.componentInstance.event.subscribe(data => {

        console.log(data.data);
        console.log("Here");
          if(data)
              this.updateApplicantProfile(data);
              dialogRef.close();

        });
    }




    ///


    public requestCoc(id:any)
    {
      const dialogRef = this.dialog.open(ConfirmDialogComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want request this Coc?"
        }
      });

      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){
          let data = {
            "applicantId":id,
             "status":this.applicantInsuranceStatusList.Requested,
                };

                this._processManagementService.requestCoc(data)
                .subscribe(data => {

                      this._snackBar.open('Coc requested successfully', 'Undo', {
                        duration:10000,
                        horizontalPosition: this.horizontalPosition,
                        verticalPosition: this.verticalPosition,
                      });

                      this._dialogRef.close();

                });



        }
      });

    }

}
