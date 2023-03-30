import { MinistryOfLabourDocumentComponent } from './pages/ministry-of-labour-document/ministry-of-labour-document.component';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LetterRoutingModule } from './letter-routing.module';
import { ContractLetterComponent } from './pages/contract-letter/contract-letter.component';
import { LetterComponent } from './letter.component';
import { TelerikReportingModule } from '@progress/telerik-angular-report-viewer';
import { CocLetterComponent } from './pages/coc-letter/coc-letter.component';
import { PreflightTrainingLetterComponent } from './pages/preflight-training-letter/preflight-training-letter.component';
import { VisaRequestLetterComponent } from './pages/visa-request-letter/visa-request-letter.component';
import { FingerPrintLetterComponent } from './pages/finger-print-letter/finger-print-letter.component';
import { LabourBankLetterComponent } from './pages/labour-bank-letter/labour-bank-letter.component';
import { LabourApprovalLetterComponent } from './pages/labour-approval-letter/labour-approval-letter.component';


@NgModule({
  declarations: [
    ContractLetterComponent,
    LetterComponent,
    CocLetterComponent,
    PreflightTrainingLetterComponent,
    VisaRequestLetterComponent,
    FingerPrintLetterComponent,
    LabourBankLetterComponent,
    MinistryOfLabourDocumentComponent,
    LabourApprovalLetterComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    TelerikReportingModule,
    LetterRoutingModule
  ]
})
export class LetterModule { }
