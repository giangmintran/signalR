import { Component, OnInit } from '@angular/core';
import { Message } from 'src/Models/Message';
import { HubConnection, HubConnectionBuilder  } from '@aspnet/signalr';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {

  title = 'sample-signalr-client';

  private _hubConnection: HubConnection;
  msgs: Message[] = [];

  constructor() {
}

  ngOnInit(): void {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl('http://localhost:5198/Chat')
      .build();
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

      this._hubConnection.on('ReceiveMessage', (from: any, message: string) => {
        console.log(`Message from ${from}: ${message}`);
    });
  }
}
