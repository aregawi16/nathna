import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-contract-letter',
  templateUrl: './contract-letter.component.html',
  styleUrls: ['./contract-letter.component.scss']
})
export class ContractLetterComponent {
  readonly viewerContainerStyle = environment.trReportViewerContainerStyle;
  readonly apiUrl = environment.reportingRestUrl;
  readonly reportSource = 'LabourContractApproval.trdp'
}
