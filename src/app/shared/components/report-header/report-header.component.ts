import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-report-header',
  templateUrl: './report-header.component.html',
  styleUrls: ['./report-header.component.scss']
})
export class ReportHeaderComponent {
  @Input() office: string;
  @Input() agent: string;

  constructor() {
}

ngOnInit() {
}
}
