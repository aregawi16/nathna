import { Injectable } from '@angular/core';
import {  ResolveFn } from '@angular/router';
import { Observable } from 'rxjs';
import { IdentityService } from '../../identity.service';

@Injectable()
export class UserRsolver  {
  constructor(private dataService: IdentityService) {}

  resolve(): Observable<any> {
    return this.dataService.getUserList(); // Fetch data from a service
  }
}
