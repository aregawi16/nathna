import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-labour-approval-letter',
  templateUrl: './labour-approval-letter.component.html',
  styleUrls: ['./labour-approval-letter.component.scss']
})
export class LabourApprovalLetterComponent {
  readonly viewerContainerStyle = environment.trReportViewerContainerStyle;
  readonly apiUrl = environment.reportingRestUrl;
  readonly reportSource = 'LabourApprovalLetter.trdp'
}
