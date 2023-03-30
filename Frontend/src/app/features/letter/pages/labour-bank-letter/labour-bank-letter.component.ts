import { environment } from './../../../../../environments/environment';
import { Component } from '@angular/core';

@Component({
  selector: 'app-labour-bank-letter',
  templateUrl: './labour-bank-letter.component.html',
  styleUrls: ['./labour-bank-letter.component.scss']
})
export class LabourBankLetterComponent {

  readonly viewerContainerStyle = environment.trReportViewerContainerStyle;
  readonly apiUrl = environment.reportingRestUrl;
  readonly reportSource = 'LabourBankLetterReciept.trdp'
}
