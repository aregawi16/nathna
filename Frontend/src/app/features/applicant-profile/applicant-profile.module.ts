import { ResumeComponent } from './pages/resume/resume.component';
import { YellowCardRequestComponent } from './pages/yellow-card-request/yellow-card-request.component';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ImgPdfViewerModule } from 'img-pdf-viewer';
import { PipesModule } from './../../shared/pipes/pipes.module';
import { ApplicantProfileRoutingModule } from './applicant-profile-routing.module';
import { ApplicantProfileComponent } from './applicant-profile.component';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VgCoreModule } from '@videogular/ngx-videogular/core';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';

import { SharedModule } from 'src/app/shared/shared.module';

import { AddApplicantComponent } from './pages/add-applicant/add-applicant.component';
import { ApplicantListComponent } from './pages/applicant-list/applicant-list.component';
import { ApplicantDetailComponent } from './pages/applicant-detail/applicant-detail.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgxPrintModule } from 'ngx-print';
import { ShareButtonsModule } from 'ngx-sharebuttons/buttons';
import { ShareIconsModule } from 'ngx-sharebuttons/icons';
import { ApplicantRequiredVerifiedDocumentComponent } from './pages/applicant-required-verified-document/applicant-required-verified-document.component';
import { ApplicantContractAgreementComponent } from './pages/applicant-contract-agreement/applicant-contract-agreement.component';
import { ProcessManagementComponent } from './pages/process-management/process-management.component';
import { VerfContractDocumentComponent } from './pages/verf-contract-document/verf-contract-document.component';
import { CompleteInsuranceDocumentComponent } from './pages/complete-insurance-document/complete-insurance-document.component';
import { ReceiveYellowCardComponent } from './pages/receive-yellow-card/receive-yellow-card.component';
import { VerifyFlightTicketComponent } from './pages/verify-flight-ticket/verify-flight-ticket.component';
import { CocComponent } from './pages/coc/coc.component';
import { PreFlightTrainingComponent } from './pages/pre-flight-training/pre-flight-training.component';
import { PreflightTrainingDialogComponent } from './pages/pre-flight-training/preflight-training-dialog/preflight-training-dialog.component';
import { CompletePreflightTrainingDialogComponent } from './pages/pre-flight-training/complete-preflight-training-dialog/complete-preflight-training-dialog.component';
import { QRCodeModule } from 'angularx-qrcode';
import { NgxBarcodeModule } from 'ngx-barcode';
import { CandidateListComponent } from './pages/candidate-list/candidate-list.component';
import { ApplicantProfileRsolver } from './pages/candidate-list/applicant-profile-resolver';



@NgModule({
  declarations: [
    AddApplicantComponent,
    ApplicantProfileComponent,
    ApplicantListComponent,
    ApplicantDetailComponent,
    ApplicantRequiredVerifiedDocumentComponent,
    ApplicantContractAgreementComponent,
    YellowCardRequestComponent,
    ProcessManagementComponent,
    VerfContractDocumentComponent,
    CompleteInsuranceDocumentComponent,
    ReceiveYellowCardComponent,
    ResumeComponent,
    VerifyFlightTicketComponent,
    CocComponent,
    ResumeComponent,
    PreFlightTrainingComponent,
    PreflightTrainingDialogComponent,
    CompletePreflightTrainingDialogComponent,
    CandidateListComponent
    ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    ShareButtonsModule,
    ShareIconsModule,
    PipesModule,
    NgxPrintModule,
    QRCodeModule,
    NgxPaginationModule,
    ApplicantProfileRoutingModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule,
    ImgPdfViewerModule,
    NgxBarcodeModule

    ],
  exports: [
    SharedModule,
    // FileSaverModule,
    ApplicantProfileRoutingModule
  ],
  providers: [
    { provide: MAT_DIALOG_DATA, useValue: {} },
     { provide: ApplicantProfileRsolver},

    { provide: MatDialogRef, useValue: {} }
  ]
,
  bootstrap: [ApplicantProfileComponent]
})
export class ApplicantProfileModule { }
