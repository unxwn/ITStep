import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProjectItemComponent } from "./project-item/project-item.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ProjectItemComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'ProjectsProfile';
}
