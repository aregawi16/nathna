import { Injectable } from '@angular/core';
import {  ResolveFn } from '@angular/router';
import { Observable } from 'rxjs';
import { IdentityService } from '../../identity.service';

@Injectable()
export class RoleRsolver  {
  constructor(private dataService: IdentityService) {}

  resolve(): Observable<any> {
    return this.dataService.getRoles(); // Fetch data from a service
  }
}
