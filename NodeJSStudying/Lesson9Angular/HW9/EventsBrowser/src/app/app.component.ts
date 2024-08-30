import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EventItemComponent } from './event-item/event-item.component';
import { NgForOf } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, EventItemComponent, NgForOf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  events = [
    {
      title: 'Angular Workshop',
      date: '2024-09-10',
      time: '10:00 AM',
      location: 'Kyiv, Ukraine',
      description: 'A workshop for beginners to learn the basics of Angular.',
      imageUrl: 'https://angular.io/assets/images/logos/angular/angular.png'
    },
    {
      title: 'React Conference',
      date: '2024-10-05',
      time: '9:00 AM',
      location: 'Lviv, Ukraine',
      description: 'Join us for a day of talks and workshops on React.js.',
      imageUrl: 'https://upload.wikimedia.org/wikipedia/commons/a/a7/React-icon.svg'
    },
    {
      title: 'Vue.js Meetup',
      date: '2024-11-15',
      time: '6:00 PM',
      location: 'Odessa, Ukraine',
      description: 'An evening of discussions on Vue.js and its ecosystem.',
      imageUrl: 'https://vuejs.org/images/logo.png'
    }
  ];
}
