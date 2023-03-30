import { environment } from './../../../../../environments/environment';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ministry-of-labour-document',
  templateUrl: './ministry-of-labour-document.component.html',
  styleUrls: ['./ministry-of-labour-document.component.css']
})
export class MinistryOfLabourDocumentComponent implements OnInit {

  readonly viewerContainerStyle = environment.trReportViewerContainerStyle;
  readonly apiUrl = environment.reportingRestUrl;
  readonly reportSource = 'LabourBankLetterReciept.trdp'
  constructor() { }

  ngOnInit() {
  }

}
