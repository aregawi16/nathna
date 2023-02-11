"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.UserMenuComponent = void 0;
var core_1 = require("@angular/core");
var UserMenuComponent = /** @class */ (function () {
    function UserMenuComponent(_authService) {
        this._authService = _authService;
        this.userImage = 'assets/images/others/user3.jpg';
    }
    UserMenuComponent.prototype.ngOnInit = function () {
    };
    UserMenuComponent.prototype.logout = function () {
        this._authService.logout();
    };
    UserMenuComponent = __decorate([
        core_1.Component({
            selector: 'app-user-menu',
            templateUrl: './user-menu.component.html',
            styleUrls: ['./user-menu.component.scss']
        })
    ], UserMenuComponent);
    return UserMenuComponent;
}());
exports.UserMenuComponent = UserMenuComponent;
