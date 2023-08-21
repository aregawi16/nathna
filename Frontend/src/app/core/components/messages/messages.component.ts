import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { MatMenuTrigger } from '@angular/material/menu';
import { File } from './file';
import { Meeting } from './meeting';
import { Message } from './message';
import { MessagesService } from './messages.service';
import { Notification } from 'src/app/features/applicant-profile/model/notification';
import { SignalRService } from 'src/app/features/applicant-profile/services/signalr.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [ MessagesService ]
})
export class MessagesComponent implements OnInit {
  @ViewChild(MatMenuTrigger) trigger!: MatMenuTrigger;
  public selectedTab:number=1;
  public notifications: Notification[] = [];

 public files:Array<File>;
  public meetings:Array<Meeting>;
  constructor(private messagesService:MessagesService,
    private signalRService: SignalRService) {

          this.files = messagesService.getFiles();
    this.meetings = messagesService.getMeetings();
  }

  ngOnInit() {
    this.signalRService.startConnection().then(() => {
      this.signalRService.addNotificationListener((notification: Notification) => {
        this.notifications.push(notification);
      });
    });
  }

  openMessagesMenu() {
    this.trigger.openMenu();
    this.selectedTab = 0;
  }

  onMouseLeave(){
    this.trigger.closeMenu();
  }

  stopClickPropagate(event: any){
    event.stopPropagation();
    event.preventDefault();
  }
  ngOnDestroy(): void {
    this.signalRService.stopConnection();
  }

}
