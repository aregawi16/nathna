import { MinistryOfLabourDocumentComponent } from './pages/ministry-of-labour-document/ministry-of-labour-document.component';
import { LabourApprovalLetterComponent } from './pages/labour-approval-letter/labour-approval-letter.component';
import { LabourBankLetterComponent } from './pages/labour-bank-letter/labour-bank-letter.component';
import { FingerPrintLetterComponent } from './pages/finger-print-letter/finger-print-letter.component';
import { VisaRequestLetterComponent } from './pages/visa-request-letter/visa-request-letter.component';
import { PreflightTrainingLetterComponent } from './pages/preflight-training-letter/preflight-training-letter.component';
import { CocLetterComponent } from './pages/coc-letter/coc-letter.component';
import { ContractLetterComponent } from './pages/contract-letter/contract-letter.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: ContractLetterComponent,
    children: [
      {
        path: 'contract',
        component: ContractLetterComponent,
        data: { breadcrumb: 'Contract' }
      },
      {
        path: 'finger-print',
        component: FingerPrintLetterComponent,
        data: { breadcrumb: 'Finger Print' }
      },
      {
        path: 'coc',
        component: CocLetterComponent,
        data: { breadcrumb: 'CoC' }
      },
      {
        path: 'mof-labour-document',
        component: MinistryOfLabourDocumentComponent,
        data: { breadcrumb: 'MoL' }
      },
      {
        path: 'preflight',
        component: PreflightTrainingLetterComponent,
        data: { breadcrumb: 'Preflight' }

      },
      {
        path: 'visa',
        component: VisaRequestLetterComponent,
        data: { breadcrumb: 'Visa' }

      },
      {
        path: 'labour-bank',
        component: LabourBankLetterComponent,
        data: { breadcrumb: 'Labour Bank' }
      },
      {
        path: 'labour-approval',
        component: LabourApprovalLetterComponent,
        data: { breadcrumb: 'Labour Approval' }
      }

    ]
    }
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LetterRoutingModule { }
