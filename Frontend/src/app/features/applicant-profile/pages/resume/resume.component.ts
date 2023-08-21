import { environment } from './../../../../../environments/environment';
import { Religion } from './../../../../core/constants/religion.enum';
import { MaritalStatus } from './../../../../core/constants/marital-status.enum';
import { Status, ApplicantPlacementStatus } from './../../model/Status.enum';
import { Gender } from './../../../../core/constants/gender.enum';
import { Component, Input, ViewEncapsulation, OnInit, SimpleChange } from '@angular/core';
import { ApplicantProfileService } from '../../services/applicant-profile.service';
import { AuthService } from 'src/app/features/auth/services/auth.service';
import * as QRCode from 'qrcode';


@Component({
  selector: 'app-resume',
  templateUrl: './resume.component.html',
  styleUrls: ['./resume.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ResumeComponent implements OnInit{

  @Input() applicantProfile :any;
  base_url = environment.backend.base_url;
  domain_base_url = environment.domain+"applicant-profile/detail/";
  candidate: any;
  resume:any;
  prinEelemet:HTMLElement;
  genders!:number[];
  jobs:any[]=[];
  jobListForCvs :any[]=[];
  genderList=Gender;
  statuses!:number[];
  statusList=Status;
  applicationStatusList=ApplicantPlacementStatus;
  maritalStatuses!:number[];
  maritalStatusList=MaritalStatus;
  religions!:number[];
  religionList=Religion;
  elementType = 'svg';
  value ="";
  format = 'CODE128';
  lineColor = '#000000';
  width = 2;
  widthone = 1;
  height = 20;
  heightl = 15;
  displayValue = false;
  displayValueT = true;
  fontOptions = '';
  font = 'monospace';
  textAlign = 'center';
  textPosition = 'bottom';
  textMargin = 0;
  fontSize = 20;
  background = '#ffffff';
  margin = 0;
  marginTop = 10;
  marginBottom = 0;
  marginLeft = -5;
  marginRight = 0;
  qrCodeDataUrl:any;
  shareUrl :any = null;
  get values(): string[] {
    return this.applicantProfile?.passportNo.split('\n');
  }
  get ()
  {

  }
  codeList: string[] = [
    '', 'CODE128',
    'CODE128A', 'CODE128B', 'CODE128C',
    'UPC', 'EAN8', 'EAN5', 'EAN2',
    'CODE39',
    'ITF14',
    'MSI', 'MSI10', 'MSI11', 'MSI1010', 'MSI1110',
    'pharmacode',
    'codabar'
  ];


  constructor(
    private _applicantProfileService:ApplicantProfileService,
    private _authService:AuthService
    ) {

    }
    ngOnChanges(changes: SimpleChange) {
      console.log(this.applicantProfile);
this.generateQRCode();

    }

    generateQRCode() {
      this.shareUrl = "https://nathanjobs.com/#/applicant-profile/detail/"+this.applicantProfile?.applicantProfileId;

      QRCode.toDataURL(this.shareUrl , (err, url) => {
        if (err) {
          console.error(err);
        } else {
          this.qrCodeDataUrl = url;
        }
      });
    }



ngOnInit(): void
{
  this.value = this.applicantProfile?.passportNo;
  this.resume = "<html><h5>Hello</h5></html>";

  this.getJobs();

}


ngAfterContentInit(): void {
  //Called after ngOnInit when the component's or directive's content has been initialized.
  //Add 'implements AfterContentInit' to the class.
  this.getSkills(this.applicantProfile);


}
downloadCV()
{

}

getJobs(){
  this._applicantProfileService.getCommonJobs()
    .subscribe({
      next:(data)=>{
        this.jobs = data;

      },
      error:(err)=>{
        console.log();
      }

    }
);
}
  getJobDescription(jobList:any)
  {
    let jobNames : string[] = [];
let jobArrays = jobList.split('');
jobArrays.forEach(element => {
 let namee =  this.jobs.find(x=>x.id==element);
 if(namee!=null)
 jobNames.push(namee.name);
});
return jobNames.toString();
  }

  getSkills(applicantProfile:any)
  {
    this.jobListForCvs = [];
    this.applicantProfile?.workExperiences?.forEach(element => {
      let jobArrays = element.jobDescription.split('');
      jobArrays.forEach(element => {
        let namee =  this.jobs.find(x=>x.id==element);
        if(namee!=null &&!this.jobListForCvs.includes(namee?.name))
        this.jobListForCvs.push(namee.name);

      });


     });
     return this.jobListForCvs;
  }
}
