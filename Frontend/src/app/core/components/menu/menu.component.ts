import { Component, OnInit, Input, ViewEncapsulation } from '@angular/core';
import { AppSettings, Settings } from '../../../app.settings';
import { MenuService } from './menu.service';
import { AuthService } from 'src/app/features/auth/services/auth.service';

@Component({
  selector: 'app-admin-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [ MenuService ]
})
export class MenuComponent implements OnInit {
  @Input('menuItems') menuItems;
  @Input('menuParentId') menuParentId;
  parentMenu!:Array<any>;
  public settings: Settings;
  constructor(public appSettings:AppSettings,
    private _authService:AuthService,
    public menuService:MenuService) {
    this.settings = this.appSettings.settings;
  }

  ngOnInit() {
    this.parentMenu = this.menuItems.filter(item => item.parentId == this.menuParentId);
    let isHeadOffice = this._authService.isHeadOffice();
    if(!isHeadOffice)
    {
      this.parentMenu = this.parentMenu.filter(q=>q.isHeadOffice==false)
    }
  }

 onClick(menuId){
    this.menuService.toggleMenuItem(menuId);
    this.menuService.closeOtherSubMenus(this.menuItems, menuId);
  }

}
