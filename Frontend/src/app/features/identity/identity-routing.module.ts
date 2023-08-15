import { RoleComponent } from './pages/role/role.component';
import { UserComponent } from './pages/user/user.component';
import { IdentityComponent } from './identity.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserRsolver } from './pages/user/user-resolver';
import { RoleRsolver } from './pages/role/role-resolver';

const routes: Routes = [
  {
    path: '',
    component: IdentityComponent,
    children: [
      {
        path: 'user',
        component: UserComponent,
        resolve: {
          data: UserRsolver, // Resolver service
        },
        data: { breadcrumb: 'User' }

      },
      {
        path: 'role',
        component: RoleComponent,
        resolve: {
          data: RoleRsolver, // Resolver service
        },
        data: { breadcrumb: 'Role' }

      }
    ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
     { provide: UserRsolver},
     { provide: RoleRsolver},

  ]
})
export class IdentityRoutingModule { }
