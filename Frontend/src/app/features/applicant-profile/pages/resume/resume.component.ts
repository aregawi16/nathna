import { environment } from './../../../../../environments/environment';
import { Religion } from './../../../../core/constants/religion.enum';
import { MaritalStatus } from './../../../../core/constants/marital-status.enum';
import { Status, ApplicantPlacementStatus } from './../../model/Status.enum';
import { Gender } from './../../../../core/constants/gender.enum';
import { Component, Input, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-resume',
  templateUrl: './resume.component.html',
  styleUrls: ['./resume.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class ResumeComponent {

  @Input() applicantProfile :any;
  base_url = environment.backend.base_url;
  genders!:number[];
  genderList=Gender;
  statuses!:number[];
  statusList=Status;
  applicationStatusList=ApplicantPlacementStatus;
  maritalStatuses!:number[];
  maritalStatusList=MaritalStatus;
  religions!:number[];
  religionList=Religion;
}
