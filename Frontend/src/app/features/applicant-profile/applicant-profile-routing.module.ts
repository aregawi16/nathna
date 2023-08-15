import { PreFlightTrainingComponent } from './pages/pre-flight-training/pre-flight-training.component';
import { ApplicantDetailComponent } from './pages/applicant-detail/applicant-detail.component';
import { ApplicantProfileComponent } from './applicant-profile.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddApplicantComponent } from './pages/add-applicant/add-applicant.component';
import { ApplicantListComponent } from './pages/applicant-list/applicant-list.component';
import { ProcessManagementComponent } from './pages/process-management/process-management.component';
import { CandidateListComponent } from './pages/candidate-list/candidate-list.component';
import { ApplicantProfileRsolver } from './pages/candidate-list/applicant-profile-resolver';

const routes: Routes = [
  {
    path: '',
    component: ApplicantProfileComponent,
    children: [
      {
        path: 'create-new',
        component: AddApplicantComponent,
        data: { breadcrumb: 'Add' }
      },
      {
        path: 'list',
        component: CandidateListComponent,
        resolve: {
          data: ApplicantProfileRsolver, // Resolver service
        },


        data: { breadcrumb: 'List' }
      },
      {
        path: 'detail/:id',
        component: ApplicantDetailComponent,
        data: { breadcrumb: 'Detail' }
      }
      ,
      {
        path: 'process/:id',
        component: ProcessManagementComponent,
        data: { breadcrumb: 'Detail' }
      }
      ,
      {
        path: 'preflight-training',
        component: PreFlightTrainingComponent,
        data: { breadcrumb: 'Pre Flight Training' }
      }
    ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ApplicantProfileRoutingModule { }
