import { Injectable } from '@angular/core';
import {  ResolveFn } from '@angular/router';
import { Observable } from 'rxjs';
import { ApplicantProfileService } from '../../services/applicant-profile.service';

@Injectable()
export class ApplicantProfileRsolver  {
  constructor(private dataService: ApplicantProfileService) {}

  resolve(): Observable<any> {
    return this.dataService.getApplicantRofiles(1,8, 1,0,null); // Fetch data from a service
  }
}
