import {Component, OnInit} from '@angular/core';
import {HubConnection, HubConnectionBuilder, LogLevel} from '@microsoft/signalr';

interface Message {
user: string;
message: string;
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
    title = 'app';
    private connection: HubConnection;
    name = "Wouter";
    message = "Test message";
    allMessages = new Array<Message>();
    isConnected = false;
    

    constructor() {
        this.connection = new HubConnectionBuilder()
            .withUrl("https://localhost:7044/hubs/set")
            .configureLogging(LogLevel.Information)
            .build();

        this.connection.onclose(() => {
            console.log("Connection closed!");
            this.isConnected = false;
        });
        
        
        this.connection.on("ReceiveMessage", (user, message) => {
            console.log("Received message from " + user + ": " + message);
            this.allMessages.push({user: user, message: message});
        });
    }
    
    ngOnInit() {
        this.connection.start().then(() => {
            console.log("Connected!");
            this.isConnected = true;
            this.connection.invoke("Recall");
        }).catch(err => {
            console.log("Error while starting connection: " + err);
        });
    }
    
    public async send() {
        await this.connection.invoke("SendMessage", this.name, this.message);
    }
}
