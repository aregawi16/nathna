import { QualificationType, LevelOfQualification } from './../../model/education-level.enum';
import { Route, Router } from '@angular/router';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LoginForm } from './../../../auth/models/LoginForm';
import { ApplicantProfile } from './../applicant-list/applicant-list.component';
import { SettingService } from './../../../setting/setting.service';
import { MaritalStatus } from './../../../../core/constants/marital-status.enum';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { ApplicantProfileService } from './../../services/applicant-profile.service';
import { DropDownObject } from './../../../../core/models/dropDownObject';
import { formatDate } from '@angular/common';


import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, FormGroupDirective } from '@angular/forms'
import {STEPPER_GLOBAL_OPTIONS} from '@angular/cdk/stepper';
import { Gender } from 'src/app/core/constants/gender.enum';
import { Religion } from 'src/app/core/constants/religion.enum';
import { Priority } from 'src/app/core/constants/priority.enum';
import { Relationship } from '../../model/Relationship.enum';

/**
 * @title Stepper with customized states
**/
@Component({
  selector: 'add-applicant',
  templateUrl: 'add-applicant.component.html',
  styleUrls: ['add-applicant.component.scss'],
  providers: [
    {
      provide: STEPPER_GLOBAL_OPTIONS,
      useValue: {displayDefaultIndicatorType: false},
    },
  ],
})
export class AddApplicantComponent {

  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
verticalPosition: MatSnackBarVerticalPosition = 'bottom';
model : LoginForm={
  userName:'',
  password:'',
  rememberMe:false
};
  workExperienceForm!: FormGroup;
  personalInfoFormGroup!: FormGroup;
  workExperienceFormGroup!: FormGroup;
  contactPersonFormGroup!: FormGroup;
  experiencedJobFormGroup!: FormGroup;
  documentFormGroup!: FormGroup;
  disabled:boolean=false;
  countries!:{name:string,code:string}[];
  genders!:number[];
  priorities!:number[];
  priorityList=Priority;
  genderList=Gender;
  maritalStatuses!:number[];
  maritalStatusList=MaritalStatus;
  relationships!:number[];
  relationshipList=Relationship;
  religions!:number[];
  qualificationTypes!:number[];
  qualificationTypeList=QualificationType;
  levelOfQualifications!:number[];
  levelOfQualificationList=LevelOfQualification;
  refNo:string="nnn";
  hidden = false;
  religionList=Religion;
  locale: string = 'en-US';
  format: string = 'MM-dd-yyyy';
  formData = new FormData();
  isEditable = false;
  appProfileId:any;
   commonJobs: DropDownObject[] = [
  ];

   countrys: DropDownObject[] = [
  ];

  agents: DropDownObject[] = [
  ];


  constructor(public _formBuilder: FormBuilder,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public applicantProfileEditData: any,
    private _settingService: SettingService,
    private _router: Router,
    private _applicantProfileService:ApplicantProfileService
    ) {


    //Personal Info
    this.personalInfoFormGroup = this._formBuilder.group({
      applicantProfileId: [''],
      firstName: ['',[ Validators.required] ],
      firstNameAm: ['',[ Validators.required]],
      lastName: ['',[ Validators.required]],
      lastNameAm: ['',[ Validators.required]],
      middleName: ['',[ Validators.required]],
      middleNameAm: ['',[ Validators.required]],
      phoneNumber: ['',[ Validators.required,Validators.maxLength(9)]],
      passportNo: ['',[ Validators.required,Validators.maxLength(8)]],
      passportIssueDate: ['',[ Validators.required]],
      passportExpiryDate: ['',[ Validators.required]],
      referenceNo: ['',[ Validators.required]],
      doB: ['',[ Validators.required]],
      nationality: ['',[ Validators.required]],
      maritalStatus: ['',[ Validators.required]],
      gender: ['',[ Validators.required]],
      noOfChildren: ['',[ Validators.required]],
      religion: ['',[ Validators.required]],
      agentId: ['',[ Validators.required]],
      priority: ['',[ Validators.required]],
      height: [0],
      weight: [0],
      city: ['',[ Validators.required]],
      wereda: ['',[ Validators.required]],
      kebelle: ['',[ Validators.required]],
      isDeleted: [false ],
      workExperiences: this._formBuilder.array([]),
      insuranceBeneficiaries: this._formBuilder.array([]),
      contactPerson:this._formBuilder.group({
        fullName: ['', Validators.required],
        phoneNumber: ['', Validators.required],
        email: [''],
        city: ['', Validators.required],
        wereda: ['', Validators.required],
        kebelle: ['', Validators.required],
        }),
        educationData:this._formBuilder.group({
          qualificationType: [''],
          levelOfQualification: [''],
          yearCompleted: [''],
          award: [''],
          professionalSkill: ['']
                }),
      experiencedJobs: this._formBuilder.array([]),
      applicantDocument:{}

    });

      this.initGroup();
      this.initCommonJobs();
      this.getAgents();
this.initInsuranceGroup();

    this.documentFormGroup = this._formBuilder.group({
      applicantPassport: [''],
      applicantId: [''],
      contactDocument: [''],
      applicantVideo: [''],
      applicantShortPhoto: [''],
      applicantFullPhoto: [''],
    });


  this.countries = _applicantProfileService.getCountries();

  this.getCountrys();
  this.genders= Object.keys(this.genderList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
  this.maritalStatuses= Object.keys(this.maritalStatusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
  console.log(this.maritalStatuses);
  this.religions= Object.keys(this.religionList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
  this.priorities= Object.keys(this.priorityList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
  this.relationships= Object.keys(this.relationshipList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
  this.qualificationTypes= Object.keys(this.qualificationTypeList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
  this.levelOfQualifications= Object.keys(this.levelOfQualificationList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));


  }
  ngOnInit() {

  if(this.applicantProfileEditData){
    this.personalInfoFormGroup.patchValue(this.applicantProfileEditData);
  }
}
  initGroup() {
    let date = new Date();
    let workExperiences = this.personalInfoFormGroup.get('workExperiences') as FormArray;
    workExperiences.push(this._formBuilder.group({
      ApplicantProfileId: [1],
      duration: [''],
      startDate: [date],
      endDate: [date],
      country: [''],
      jobs: [''],
      jobDescription: [''],
    }))
  }

  initInsuranceGroup() {
    let insuranceBeneficiaries = this.personalInfoFormGroup.get('insuranceBeneficiaries') as FormArray;
    insuranceBeneficiaries.push(this._formBuilder.group({
      ApplicantProfileId: [1],
    fullName: ['', Validators.required],
    relationship: ['', Validators.required],
    address: ['', Validators.required],
    percent: ['', Validators.required],
    }))
  }

  transformDate(date) {
    console.log(formatDate(date, this.format, this.locale));
    return formatDate(date, this.format, this.locale);
  }

  initCommonJobs(){

this._applicantProfileService.getCommonJobs()
    .subscribe(data => {
      this.commonJobs = data;
      // this.commonJobs.forEach(item =>{
  // let experiencedJobs = this.personalInfoFormGroup.get('experiencedJobs') as FormArray;
  // experiencedJobs.push(this._formBuilder.group({
  //   commonJobId: item.id,
  //   commonJobName: item.name,
  // haveExperience: false,
  // }))

  // console.log(this.commonJobs);

    // });

     console.log(this.commonJobs);
  //  console.log(this.experiencedJobFormGroup['controls']['jobs']['controls']);


   });

}

 getAgents(){

this._settingService.getAgentList()
    .subscribe(data => {
      this.agents = data;
   });

}
onChangeJob(i:number,event:any)
{

  console.log(event.value.toString());
  console.log(this.personalInfoFormGroup['controls']['workExperiences']['controls'][i].controls.jobDescription.setValue(event.value.toString()));
  console.log(this.personalInfoFormGroup['controls']['workExperiences']['controls'][i].controls.jobDescription.value);
}
generateRefNo()
{
  this.refNo = this.personalInfoFormGroup['controls']['firstName'].value?.charAt(0);;
}
onDeleteRow(rowIndex) {
    let rows = this.personalInfoFormGroup.get('workExperiences') as FormArray;
    rows.removeAt(rowIndex)
  }
  onDeleteInsuranceRow(rowIndex) {
    let rows = this.personalInfoFormGroup.get('insuranceBeneficiaries') as FormArray;
    rows.removeAt(rowIndex)
  }

  public giveImage(event)
{
  console.log(event.target.files[0]);
}

checkExp(row)
{

  //row.value.haveExperience.setValue(true);
}

getJobs()
{

  this._applicantProfileService.getCommonJobs()
    .subscribe(data => {
      this.commonJobs = data;



    });
}
getCountrys()
{

  this._settingService.getCountryList()
    .subscribe(data => {
      this.countrys = data;
      console.log(this.countrys);
;


    });
}
submitApplicantProfile()
{


  console.log(this.formData);
  console.log(this.personalInfoFormGroup.value);
  this._applicantProfileService.createApplicantProfile(this.personalInfoFormGroup.value)
  .subscribe(data => {

    this._applicantProfileService.uplodApplicantDocument(this.formData)
    .subscribe(data => {


          this._snackBar.open('Applicant added successfully', 'Undo', {
            duration:10000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });


    });


  });
}
onSubmit(formItemDirective:FormGroupDirective)
{



  console.log(this.formData);
  console.log(this.personalInfoFormGroup.value);
  // if(this.personalInfoFormGroup.valid && this.documentFormGroup)
  // {
    this._applicantProfileService.createApplicantProfile(this.personalInfoFormGroup.value)
    .subscribe(data => {
      this.formData.append("ApplicantProfileId",data.applicantProfileId);
      this._applicantProfileService.uplodApplicantDocument(this.formData)
      .subscribe(data => {


            this._snackBar.open('Applicant added successfully', 'Undo', {
              duration:10000,
              horizontalPosition: this.horizontalPosition,
              verticalPosition: this.verticalPosition,
            });
            formItemDirective.resetForm();
            this.personalInfoFormGroup.reset();

            this._router.navigateByUrl('/applicant-profile/list');

      });


    });
  }
  // else
  // {

  //   this._snackBar.open('Please insert the required fields', 'cancel', {
  //     duration:10000,
  //     panelClass: ['mat-toolbar', 'mat-primary'],
  //     horizontalPosition: "end",
  //     verticalPosition: "top",
  //   });
  // }

// }

onChangeApplicantPassport(event)
{
  this.documentFormGroup.controls['applicantPassport'].setValue(event.target.files[0]);
  this.formData.append("applicantPassport",event.target.files[0]);
}
onChangeApplicantId(event)
{
  this.documentFormGroup.controls['applicantId'].setValue(event.target.files[0]);
  this.formData.append("applicantId",event.target.files[0]);

}

onChangeContactId(event)
{
  this.documentFormGroup.controls['contactDocument'].setValue(event.target.files[0]);
  this.formData.append("contactDocument",event.target.files[0]);

}
onChangeApplicantShortPhoto(event)
{
  this.documentFormGroup.controls['applicantShortPhoto'].setValue(event.target.files[0]);
  this.formData.append("applicantShortPhoto",event.target.files[0]);

}
onChangeApplicantFullPhoto(event)
{
  this.documentFormGroup.controls['applicantFullPhoto'].setValue(event.target.files[0]);
  this.formData.append("applicantFullPhoto",event.target.files[0]);

}
onChangeApplicantVideo(event)
{
  this.documentFormGroup.controls['applicantVideo'].setValue(event.target.files[0]);
  this.formData.append("applicantVideo",event.target.files[0]);

}
}
