import { environment } from './../../../../../environments/environment';
import { Religion } from './../../../../core/constants/religion.enum';
import { MaritalStatus } from './../../../../core/constants/marital-status.enum';
import { Status, ApplicantPlacementStatus } from './../../model/Status.enum';
import { Gender } from './../../../../core/constants/gender.enum';
import { Component, Input, ViewEncapsulation, OnInit } from '@angular/core';
import { ApplicantProfileService } from '../../services/applicant-profile.service';
import { AuthService } from 'src/app/features/auth/services/auth.service';

@Component({
  selector: 'app-resume',
  templateUrl: './resume.component.html',
  styleUrls: ['./resume.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ResumeComponent implements OnInit{

  @Input() applicantProfile :any;
  base_url = environment.backend.base_url;

  resume:any;
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
  heightl = 72;
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

  get values(): string[] {
    return this.applicantProfile?.passportNo.split('\n');
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

getJobs(){
  this._applicantProfileService.getCommonJobs()
    .subscribe(data => {
      this.jobs = data;
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
