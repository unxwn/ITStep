import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-event-item',
  standalone: true,
  imports: [],
  templateUrl: './event-item.component.html',
  styleUrl: './event-item.component.css'
})
export class EventItemComponent {
  @Input() title: string = '';
  @Input() date: string = '';
  @Input() time: string = '';
  @Input() location: string = '';
  @Input() description: string = '';
  @Input() imageUrl: string = '';
}
