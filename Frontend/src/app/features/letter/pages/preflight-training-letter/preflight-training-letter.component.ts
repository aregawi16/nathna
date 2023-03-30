import { environment } from './../../../../../environments/environment';
import { Component } from '@angular/core';

@Component({
  selector: 'app-preflight-training-letter',
  templateUrl: './preflight-training-letter.component.html',
  styleUrls: ['./preflight-training-letter.component.scss']
})
export class PreflightTrainingLetterComponent {

  readonly viewerContainerStyle = environment.trReportViewerContainerStyle;
  readonly apiUrl = environment.reportingRestUrl;
  readonly reportSource = 'PreflightTraining.trdp'
}
