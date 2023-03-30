import { ApplicantRequiredVerifiedDocumentComponent } from './../applicant-required-verified-document/applicant-required-verified-document.component';
import { SettingService } from './../../../setting/setting.service';
import { DropDownObject } from './../../../../core/models/dropDownObject';
import { ActivatedRoute } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http';
import { ProcessManagementService } from './../../../process-management/service/process-management.service';
import { ApplicantProfileService } from './../../services/applicant-profile.service';
import { MatTableDataSource } from '@angular/material/table';
import { ApplicantContractStatus, ApplicantInsuranceStatus, ApplicantLabourStatus, ApplicantTicketStatus, Status } from './../../model/Status.enum';
import { Component, OnInit } from '@angular/core';
import { ApplicantPlacementStatus } from '../../model/Status.enum';

@Component({
  selector: 'app-process-management',
  templateUrl: './process-management.component.html',
  styleUrls: ['./process-management.component.scss']
})
export class ProcessManagementComponent implements OnInit  {

  applicantPlacementStatuses!:number[];
  statusList=Status;
  applicantPlacementStatusList=ApplicantPlacementStatus;
  applicantContractStatuses!:number[];
  applicantContractStatusList=ApplicantContractStatus;
  applicantInsuranceStatuses!:number[];
  applicantInsuranceStatusList=ApplicantInsuranceStatus;
  applicantLabourOfficeStatuses!:number[];
  applicantLabourOfficeStatusList=ApplicantLabourStatus;
  applicantFlightTicketStatuses!:number[];
  applicantFlightTicketStatuseList=ApplicantTicketStatus;
  dataSource = new MatTableDataSource<any>();
  applicantProfileData!:any;
  applicantPlacementStatusDataSource!:any;
  applicantContractStatusDataSource!:any;
  applicantInsuranceStatusDataSource!:any;
  applicantLabourStatusDataSource!:any;
  applicantTicketStatusDataSource!:any;
  applicantContractStatus!:any;
  applicantInsuranceStatus!:any;
  applicantCoCStatusDataSource!:any;
  applicantPreFlightTrainingStatusDataSource!:any;
  applicantLabourOfficeStatus!:any;
  applicantTicketStatus!:any;
  offices!:DropDownObject[];


  displayedApplicantPlacements: string[] = ['fullName', 'fullNameAm',  'date','description','status','action'];
  constructor(
    public _settingService: SettingService,
    public _applicantService: ApplicantProfileService,
    private _processManagementService: ProcessManagementService,
    private _httpClient: HttpClientModule,
     private _dialog : MatDialog,
    private _snackBar : MatSnackBar,
    public dialog: MatDialog,
    private activatedRoute: ActivatedRoute
  ){

  }
  ngOnInit(): void {
    this.applicantPlacementStatuses= Object.keys(this.applicantPlacementStatusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
    this.applicantContractStatuses= Object.keys(this.applicantContractStatusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
    this.applicantInsuranceStatuses= Object.keys(this.applicantInsuranceStatusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
    this.applicantLabourOfficeStatuses= Object.keys(this.applicantLabourOfficeStatusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
    this.applicantFlightTicketStatuses= Object.keys(this.applicantFlightTicketStatuseList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
    this.getOffices();
    this.activatedRoute.params.subscribe(params => {
      if(params['id']){
        this.getApplicantProfileById(params['id']);
      }
      else{
        this.getApplicantProfileById(1);
      }
    });
  }

  public getApplicantProfileById(id:any){
    let placementStatus = this.statusList[this.statusList.Placement];
    let contractStatus = this.statusList[this.statusList.ContractAgreement];
    let insuranceStatus = this.statusList[this.statusList.Insurance];
    let labourStatus = this.statusList[this.statusList.MinistryOfLabor];
    let ticketStatus = this.statusList[this.statusList.Ticket];
    let cocStatus = this.statusList[this.statusList.CoC];
    let preFlightTrainingStatus = this.statusList[this.statusList.PreFlightTraining];

    this._applicantService.getApplicantRofileById(id)
    .subscribe(data => {
      this.applicantProfileData = data;
      this.applicantPlacementStatusDataSource = new MatTableDataSource(data.applicantStatuses.filter(item => item.officeLevel ==placementStatus ));
      this.applicantContractStatusDataSource = new MatTableDataSource(data.applicantStatuses.filter(item => item.officeLevel ==contractStatus ));
      this.applicantInsuranceStatusDataSource = new MatTableDataSource(data.applicantStatuses.filter(item => item.officeLevel ==insuranceStatus ));
      this.applicantLabourStatusDataSource = new MatTableDataSource(data.applicantStatuses.filter(item => item.officeLevel ==labourStatus ));
      this.applicantTicketStatusDataSource = new MatTableDataSource(data.applicantStatuses.filter(item => item.officeLevel ==ticketStatus ));
      this.applicantCoCStatusDataSource = new MatTableDataSource(data.applicantStatuses.filter(item => item.officeLevel ==cocStatus ));
      this.applicantPreFlightTrainingStatusDataSource = new MatTableDataSource(data.applicantStatuses.filter(item => item.officeLevel ==preFlightTrainingStatus ));

      console.log(data);
    });

  }

  public getOffices()
  {

    this._settingService.getOfficeList()
      .subscribe(data => {
       this.offices = data;
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
  checkUploadStatus(applicantPlacementStatus:any)
  {
    if(applicantPlacementStatus==null)
    {
      return false;
    }
    else{
      if(applicantPlacementStatus==this.applicantPlacementStatusList.Selected)
      {
        return true;
      }
      return false;
    }
  }
}
