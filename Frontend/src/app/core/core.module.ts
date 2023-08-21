import { CoreComponent } from './core.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreRoutingModule } from './core-routing.module';
import { FullScreenComponent } from './components/fullscreen/fullscreen.component';
import { MessagesComponent } from './components/messages/messages.component';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { UserMenuComponent } from './components/user-menu/user-menu.component';
import { MenuComponent } from './components/menu/menu.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatIconModule } from '@angular/material/icon';
import { SignalRService } from '../features/applicant-profile/services/signalr.service';




@NgModule({
  declarations: [
    CoreComponent,
    MenuComponent,
    UserMenuComponent,
    BreadcrumbComponent,
    MessagesComponent,
    FullScreenComponent

  ],
  imports: [
    CommonModule,
    CoreRoutingModule,
    MatIconModule,
    SharedModule
  ],
  bootstrap: [CoreComponent],
  providers:[ SignalRService  ]

})
export class CoreModule { }
