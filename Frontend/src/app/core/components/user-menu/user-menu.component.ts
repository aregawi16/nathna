import { AuthService } from 'src/app/features/auth/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.scss']
})
export class UserMenuComponent implements OnInit {
  public userImage = 'assets/images/others/user3.jpg';
  constructor(
    private _authService:AuthService
  ) { }

  ngOnInit(): void {
  }

  logout()
  {

    this._authService.logout();

  }
}
