import { AuthService } from 'src/app/features/auth/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-menu',
  templateUrl: './user-menu.component.html',
  styleUrls: ['./user-menu.component.scss']
})
export class UserMenuComponent implements OnInit {
  public userImage = 'assets/images/others/user3.jpg';
  userFullName :any = null;
  constructor(
    private _authService:AuthService
  ) { }

  ngOnInit(): void {
    this.userFullName = this._authService.getFullName();

  }

  logout()
  {

    this._authService.logout();

  }
}
