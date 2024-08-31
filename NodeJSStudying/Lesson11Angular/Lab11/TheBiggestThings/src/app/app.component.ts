import { NgIf, UpperCasePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FormsModule, UpperCasePipe, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  selectedObject: keyof typeof this.vehicleData = 'car';

  vehicleData = {
    car: {
      name: 'Hummer H1 X3',
      description: 'A powerful and rugged off-road vehicle.',
      country: 'USA',
      capacity: '6 passengers',
      imageUrl: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOZ3j-IT65jqLxSCCh0ynDCR6NQ9qh4LodPw&s'
    },
    plane: {
      name: 'Antonov An-225',
      description: 'The world’s largest airplane.',
      country: 'Ukraine',
      capacity: '250,000 kg',
      imageUrl: 'https://upload.wikimedia.org/wikipedia/commons/thumb/c/cc/Antonov_An-225_Beltyukov-1.jpg/1200px-Antonov_An-225_Beltyukov-1.jpg'
    },
    ship: {
      name: 'Seawise Giant',
      description: 'The largest ship ever constructed.',
      country: 'Norway',
      capacity: '564,763 tons',
      imageUrl: 'https://upload.wikimedia.org/wikipedia/en/thumb/d/da/Knock_Nevis.jpg/300px-Knock_Nevis.jpg'
    }
  };
}
