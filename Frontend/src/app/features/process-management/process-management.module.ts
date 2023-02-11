import { SharedModule } from 'src/app/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProcessManagementRoutingModule } from './process-management-routing.module';
import { ApplicantContractAgreementComponent } from '../applicant-profile/pages/applicant-contract-agreement/applicant-contract-agreement.component';
import { ApplicantRequiredVerifiedDocumentComponent } from '../applicant-profile/pages/applicant-required-verified-document/applicant-required-verified-document.component';
import { YellowCardRequestComponent } from '../applicant-profile/pages/yellow-card-request/yellow-card-request.component';


@NgModule({
  declarations: [


  ],
  imports: [
    CommonModule,
    SharedModule,
    ProcessManagementRoutingModule
  ]
})
export class ProcessManagementModule { }
