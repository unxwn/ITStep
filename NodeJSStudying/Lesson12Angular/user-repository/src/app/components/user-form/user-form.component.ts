import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [NgIf, FormsModule],
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {
  user: User = new User();

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      const existingUser = this.userService.getUser(+id);
      if (existingUser) {
        this.user = existingUser;
      }
    }
  }

  onSave(): void {
    if (this.user.id) {
      this.userService.updateUser(this.user);
    } else {
      const newId = this.userService.getUsers().length + 1;
      this.user.id = newId;
      this.userService.addUser(this.user);
    }
    this.router.navigate(['/users']);
  }
}