"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
exports.__esModule = true;
exports.UserDialogComponent = void 0;
var core_1 = require("@angular/core");
var dialog_1 = require("@angular/material/dialog");
var forms_1 = require("@angular/forms");
var user_model_1 = require("../user/user.model");
var UserDialogComponent = /** @class */ (function () {
    function UserDialogComponent(dialogRef, user, _identityService, _settingService, fb) {
        this.dialogRef = dialogRef;
        this.user = user;
        this._identityService = _identityService;
        this._settingService = _settingService;
        this.fb = fb;
        this.passwordHide = true;
        this.userSignupform = this.fb.group({
            id: null,
            firstName: [null, forms_1.Validators.compose([forms_1.Validators.required])],
            middleName: [null, forms_1.Validators.compose([forms_1.Validators.required])],
            lastName: [null, forms_1.Validators.compose([forms_1.Validators.required])],
            email: [null, forms_1.Validators.compose([forms_1.Validators.required])],
            officeId: [null, forms_1.Validators.compose([forms_1.Validators.required])],
            userName: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(5)])],
            password: [null, forms_1.Validators.compose([forms_1.Validators.required, forms_1.Validators.minLength(6)])]
        });
    }
    UserDialogComponent.prototype.ngOnInit = function () {
        if (this.user) {
            this.userSignupform.setValue(this.user);
        }
        else {
            this.user = new user_model_1.User();
        }
        this.getOffices();
    };
    UserDialogComponent.prototype.getOffices = function () {
        var _this = this;
        this._settingService.getOfficeList()
            .subscribe(function (data) {
            _this.offices = data;
        });
    };
    UserDialogComponent.prototype.createUser = function () {
        this._identityService.createUser(this.userSignupform.value)
            .subscribe(function (data) {
            // this.offices = data;
        });
    };
    UserDialogComponent.prototype.close = function () {
        this.dialogRef.close();
    };
    UserDialogComponent = __decorate([
        core_1.Component({
            selector: 'app-user-dialog',
            templateUrl: './user-dialog.component.html',
            styleUrls: ['./user-dialog.component.scss']
        }),
        __param(1, core_1.Inject(dialog_1.MAT_DIALOG_DATA))
    ], UserDialogComponent);
    return UserDialogComponent;
}());
exports.UserDialogComponent = UserDialogComponent;
