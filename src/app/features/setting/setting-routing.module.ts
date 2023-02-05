import { OfficeComponent } from './pages/office/office.component';
import { CountryComponent } from './pages/country/country.component';
import { SettingComponent } from './setting.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobComponent } from './pages/job/job.component';
import { AgentComponent } from './pages/agent/agent.component';

const routes: Routes = [
  {
    path: '',
    component: SettingComponent,
    children: [
      {
        path: 'job',
        component: JobComponent,
        data: { breadcrumb: 'Job' }

      },
      {
        path: 'country',
        component: CountryComponent,
        data: { breadcrumb: 'Country' }

      },
      {
        path: 'agent',
        component: AgentComponent,
        data: { breadcrumb: 'Agent' }

      },
      {
        path: 'office',
        component: OfficeComponent,
        data: { breadcrumb: 'Office' }

      }
    ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingRoutingModule { }
