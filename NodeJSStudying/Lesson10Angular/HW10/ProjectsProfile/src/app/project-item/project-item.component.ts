import { Component } from '@angular/core';
import { ProjectsService } from '../projects.service';
import { UpperCasePipe, NgFor, DatePipe } from '@angular/common';

@Component({
  selector: 'app-project-item',
  standalone: true,
  imports: [UpperCasePipe, NgFor, DatePipe],
  templateUrl: './project-item.component.html',
  styleUrl: './project-item.component.css'
})
export class ProjectItemComponent {
  projects: any[];

  constructor(private projectsService: ProjectsService) {
    this.projects = this.projectsService.getProjects();
  }
}
