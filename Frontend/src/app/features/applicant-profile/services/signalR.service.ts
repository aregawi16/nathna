import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Notification } from '../model/notification';

@Injectable()
export class SignalRService {
  private connection: signalR.HubConnection;

  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7224/notificationHub') // Replace with your API URL
      .build();
  }

  public startConnection(): Promise<void> {
    return this.connection.start();
  }

  public stopConnection(): Promise<void> {
    return this.connection.stop();
  }

  public addNotificationListener(callback: (notification: Notification) => void): void {
    this.connection.on('ReceiveNotification', (notification: Notification) => {
      callback(notification);
    });
  }

  public sendNotification(notification: Notification): Promise<void> {
    return this.connection.invoke('SendNotification', notification);
  }
}
