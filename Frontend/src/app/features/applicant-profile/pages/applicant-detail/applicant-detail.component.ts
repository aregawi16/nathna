import { ApplicantContractAgreementComponent } from './../applicant-contract-agreement/applicant-contract-agreement.component';
import { ApplicantPlacementStatus, ApplicantInsuranceStatus, ApplicantLabourStatus, ApplicantTicketStatus } from './../../model/Status.enum';
import { ConfirmDialogComponent } from './../../../../shared/components/confirm-dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { DropDownObject } from './../../../../core/models/dropDownObject';
import { HttpClient } from '@angular/common/http';
import { Observable, Observer } from 'rxjs';
import { Religion } from './../../../../core/constants/religion.enum';
import { MaritalStatus } from './../../../../core/constants/marital-status.enum';
import { Gender } from './../../../../core/constants/gender.enum';
import { environment } from './../../../../../environments/environment';
import { SettingService } from './../../../setting/setting.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { ApplicantProfileService } from './../../services/applicant-profile.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { DocPreviewConfig } from 'img-pdf-viewer';
import { DialogRef } from '@angular/cdk/dialog';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';
import { Status } from '../../model/Status.enum';
import { AuthService } from 'src/app/features/auth/services/auth.service';

@Component({
  selector: 'app-applicant-detail',
  templateUrl: './applicant-detail.component.html',
  styleUrls: ['./applicant-detail.component.scss']
})
export class ApplicantDetailComponent implements OnInit {
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
   applicantProfile !:any;

   applicantPlacementStatuses!:number[];
   applicantPlacementStatusList=ApplicantPlacementStatus;
   applicantContractStatuses!:number[];
   applicantContractStatusList=ApplicantPlacementStatus;
   applicantInsuranceStatuses!:number[];
   applicantInsuranceStatusList=ApplicantInsuranceStatus;
   applicantLabourOfficeStatuses!:number[];
   applicantLabourOfficeStatusList=ApplicantLabourStatus;
   applicantFlightTicketStatuses!:number[];
   applicantFlightTicketStatuseList=ApplicantTicketStatus;
   jobs !: [];
   shareUrl:any;
   name = "Mr";
   base64Image: any;
   agents!:DropDownObject[];
   offices!:DropDownObject[];
   genders!:number[];
   genderList=Gender;
   statuses!:number[];
   statusList=Status;
   isHeadOffice:boolean=true;
   applicationStatusList=ApplicantPlacementStatus;
   maritalStatuses!:number[];
   maritalStatusList=MaritalStatus;
   religions!:number[];
   religionList=Religion;
   workExperienceDataSource!: MatTableDataSource<any>;
   experiencedJobDataSource!: MatTableDataSource<any>;
   @ViewChild(MatPaginator) paginator!: MatPaginator;
   @ViewChild(MatSort) sort!: MatSort;
   base_url = environment.backend.base_url;
   displayedWorkExperienceColumns: string[] = ['duration', 'country', 'jobDescription'];
   displayedExperiencedJobsColumns: string[] = ['job', 'haveExperience'];

   docPreviewConfig: DocPreviewConfig = {
    zoomIn: true,
    zoomOut: true,
    rotate: true,
    download: true,
    openModal: true,
    close: false,
    docScreenWidth: '80%',
    modalSize: 'md',
    customStyle: '',
    zoomIndicator: true,
  };


  constructor(
    public _applicantService: ApplicantProfileService,
    private _settingService: SettingService,
    private _authService: AuthService,
    private _processManagementService: ProcessManagementService,
    private _httpClient: HttpClient,
     private _dialog : MatDialog,
    private _snackBar : MatSnackBar,

    private activatedRoute: ActivatedRoute

  ) { }


  ngOnInit(): void {


    this.getJobs();
    this.getAgents();
    this.getOffices();
     this.isHeadOffice = this._authService.isHeadOffice();


  this.activatedRoute.params.subscribe(params => {
    if(params['id']){
      this.shareUrl = "https://nathanjobs.com/#/applicant-profile/detail/"+params['id'];
      this.getApplicantProfileById(params['id']);
    }
    else{
      this.getApplicantProfileById(1);
    }
  });
}

getJobs()
{
this._applicantService.getCommonJobs()
.subscribe(data => {
  this.jobs = data;
});
}
public getApplicantProfileById(id:any){
  this._applicantService.getApplicantRofileById(id)
  .subscribe(data => {
    this.applicantProfile = data;
    this.workExperienceDataSource = new MatTableDataSource(data.workExperiences);
    this.workExperienceDataSource.paginator = this.paginator;
    this.workExperienceDataSource.sort = this.sort;

    this.experiencedJobDataSource = new MatTableDataSource(data.experiencedJobs);
    this.experiencedJobDataSource.paginator = this.paginator;
    this.experiencedJobDataSource.sort = this.sort;
    console.log(data);
  });

}

downloadImage(imageUrl:any) {

  //imageUrl = this._httpClient.get("https://localhost:44374/NathnaDocuments/NIB1020FullPhoto.png");
    // imageUrl =
    //  "http://southparkstudios.mtvnimages.com/shared/characters/celebrities/mr-hankey.png?height=165";
    let documentName = imageUrl.substring(imageUrl.lastIndexOf("\\")+1);


  this.getBase64ImageFromURL(imageUrl).subscribe(base64data => {
    console.log(base64data);
    this.base64Image = "data:image/jpg;base64," + base64data;
    // save image to disk
    var link = document.createElement("a");

    document.body.appendChild(link); // for Firefox

    link.setAttribute("href", this.base64Image);
    link.setAttribute("download", documentName);
    link.click();
  });
}

getBase64ImageFromURL(url: string) {
  return Observable.create((observer: Observer<string>) => {
    const img: HTMLImageElement = new Image();
    img.crossOrigin = "Anonymous";
    img.src = url;
    if (!img.complete) {
      img.onload = () => {
        observer.next(this.getBase64Image(img));
        observer.complete();
      };
      img.onerror = err => {
        observer.error(err);
      };
    } else {
      observer.next(this.getBase64Image(img));
      observer.complete();
    }
  });
}

getBase64Image(img: HTMLImageElement) {
  const canvas: HTMLCanvasElement = document.createElement("canvas");
  canvas.width = img.width;
  canvas.height = img.height;
  const ctx = canvas.getContext("2d");
  ctx?.drawImage(img, 0, 0);
  const dataURL: string = canvas.toDataURL("image/png");

  return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
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

    selectApplicant(applicantId:any)
    {
      const dialogRef = this._dialog.open(ConfirmDialogComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want select this Applicant?"
        }
      });
      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){
    let data = {
"applicantId":applicantId,
 "status":this.applicantPlacementStatusList.Selected,
    };

    this._processManagementService.selectApplicant(data)
    .subscribe(data => {

          this._snackBar.open('Applicant Selected successfully', 'Undo', {
            duration:10000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });


    });
  }
      });
    }
 rejectApplicant(applicantId:any)
    {

      const dialogRef = this._dialog.open(ConfirmDialogComponent, {
        maxWidth: "400px",
        data: {
          title: "Confirm Action",
          message: "Are you sure you want select this Applicant?"
        }
      });
      dialogRef.afterClosed().subscribe(dialogResult => {
        if(dialogResult){
    let data = {
"applicantId":applicantId,
 "status":this.applicantPlacementStatusList.Rejected,
    };

    this._processManagementService.rejectApplicant(data)
    .subscribe(data => {

          this._snackBar.open('Applicant rejected successfully', 'Undo', {
            duration:10000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });


    });
  }
      });
    }


 checkStatus(applicantProfile:any)
    {
let status = this.applicantPlacementStatusList[this.applicantPlacementStatusList.Assigned];
      if(applicantProfile?.applicantStatuses==null)
      {
        return false;
      }
      else{
      if(applicantProfile?.applicantStatuses[0]?.status==status)
      {
        console.log(applicantProfile);
        return true;
      }
      return false;
    }
    }
    checkContractStatus(applicantProfile:any)
    {
let status = this.applicantPlacementStatusList[this.applicantPlacementStatusList.DocumentVerified];
      if(applicantProfile?.applicantStatuses==null)
      {
        return false;
      }
      else{
      if(applicantProfile?.applicantStatuses[0]?.status==status)
      {
        console.log(applicantProfile);
        return true;
      }
      return false;
    }

}
public uploadContractDocument(id:any)
{
  const dialogRef = this._dialog.open(ApplicantContractAgreementComponent, {
    maxWidth: "400",
    data:id

  });

  dialogRef.afterClosed().subscribe(dialogResult => {
    if(dialogResult){

    }
  });

}
  checkVerifiedDoc(applicantPlacement:any)
    {
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
      if(parseInt(applicantPlacement.status) >= this.statusList.Placement)
      {
        return true;
      }
      return false;
    }
    }

    checkContractDoc(applicantPlacement:any)
    {
      if(applicantPlacement==null)
      {
        return false;
      }
      else{
      if(parseInt(applicantPlacement.status) >= this.statusList.ContractAgreement)
      {
        return true;
      }
      return false;
    }
    }
}
