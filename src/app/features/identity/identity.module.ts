import { UserDialogComponent } from './pages/user-dialog/user-dialog.component';
import { IdentityComponent } from './identity.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IdentityRoutingModule } from './identity-routing.module';
import { UserComponent } from './pages/user/user.component';
import { RoleComponent } from './pages/role/role.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    UserComponent,
    RoleComponent,
    UserDialogComponent,
    IdentityComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    IdentityRoutingModule
  ]
})
export class IdentityModule { }
