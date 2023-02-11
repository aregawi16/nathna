
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [

  { path: 'auth', loadChildren: () => import('./features/auth/auth.module').then(m => m.AuthModule)},
   { path: '', loadChildren: () => import('./core/core.module').then(m => m.CoreModule) , canActivate:[AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers:[AuthGuard]
})
export class AppRoutingModule { }
