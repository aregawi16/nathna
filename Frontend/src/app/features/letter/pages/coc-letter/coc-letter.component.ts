import { environment } from './../../../../../environments/environment';
import { Component } from '@angular/core';

@Component({
  selector: 'app-coc-letter',
  templateUrl: './coc-letter.component.html',
  styleUrls: ['./coc-letter.component.scss']
})
export class CocLetterComponent {


  readonly viewerContainerStyle = environment.trReportViewerContainerStyle;
  readonly apiUrl = environment.reportingRestUrl;
  readonly reportSource = 'CertificationPaperasking.trdp'
}
