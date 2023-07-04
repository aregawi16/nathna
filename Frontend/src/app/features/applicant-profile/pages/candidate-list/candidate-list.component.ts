import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ApplicantProfileService } from '../../services/applicant-profile.service';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.scss']
})
export class CandidateListComponent implements OnInit {

  applicant  = 1;
  candidate  = 2;
  qualified  = 3;
  processing  = 4;
  applicantProfiles:any[]=[];
  constructor(
           public _applicantService: ApplicantProfileService,
    )
  {

  }
 ngOnInit(): void {

 }


}
