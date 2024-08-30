import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  constructor() { }

  private projects = [
    {
      title: 'Web Development Project 1',
      description: 'Test website.',
      completionDate: new Date('2024-05-01'),
      category: 'Web Development',
      imageUrl: 'https://seeklogo.com/images/A/angular-icon-logo-5FC0C40EAC-seeklogo.com.png'
    },
    {
      title: 'Graphic Design Project 1',
      description: 'My branding.',
      completionDate: new Date('2024-03-15'),
      category: 'Graphic Design',
      imageUrl: 'https://static.vecteezy.com/system/resources/thumbnails/020/933/072/small_2x/abstract-blur-gradient-background-vector.jpg'
    },
    {
      title: 'Graphic Design Project 1',
      description: 'My branding.',
      completionDate: new Date('2024-03-15'),
      category: 'Graphic Design',
      imageUrl: 'https://static.vecteezy.com/system/resources/thumbnails/020/933/072/small_2x/abstract-blur-gradient-background-vector.jpg'
    },
    {
      title: 'Graphic Design Project 1',
      description: 'My branding.',
      completionDate: new Date('2024-03-15'),
      category: 'Graphic Design',
      imageUrl: 'https://static.vecteezy.com/system/resources/thumbnails/020/933/072/small_2x/abstract-blur-gradient-background-vector.jpg'
    },
    {
      title: 'Graphic Design Project 1',
      description: 'My branding.',
      completionDate: new Date('2024-03-15'),
      category: 'Graphic Design',
      imageUrl: 'https://static.vecteezy.com/system/resources/thumbnails/020/933/072/small_2x/abstract-blur-gradient-background-vector.jpg'
    },
    {
      title: 'Graphic Design Project 1',
      description: 'My branding.',
      completionDate: new Date('2024-03-15'),
      category: 'Graphic Design',
      imageUrl: 'https://static.vecteezy.com/system/resources/thumbnails/020/933/072/small_2x/abstract-blur-gradient-background-vector.jpg'
    }
  ];

  getProjects() {
    return this.projects;
  }
}
