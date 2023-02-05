"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.UserComponent = void 0;
var user_dialog_component_1 = require("./../user-dialog/user-dialog.component");
var table_1 = require("@angular/material/table");
var collections_1 = require("@angular/cdk/collections");
var core_1 = require("@angular/core");
var UserComponent = /** @class */ (function () {
    function UserComponent(_identityService, dialog, _settingService) {
        this._identityService = _identityService;
        this.dialog = dialog;
        this._settingService = _settingService;
        this.displayedColumns = ['select', 'userName', 'email', 'fullName', 'officeId'];
        this.dataSource = new table_1.MatTableDataSource();
        this.selection = new collections_1.SelectionModel(true, []);
    }
    UserComponent.prototype.ngOnInit = function () {
        this.getUsers();
        this.getOffices();
    };
    /** Whether the number of selected elements matches the total number of rows. */
    UserComponent.prototype.isAllSelected = function () {
        var numSelected = this.selection.selected.length;
        var numRows = this.dataSource.data.length;
        return numSelected === numRows;
    };
    /** Selects all rows if they are not all selected; otherwise clear selection. */
    UserComponent.prototype.masterToggle = function () {
        var _this = this;
        this.isAllSelected() ?
            this.selection.clear() :
            this.dataSource.data.forEach(function (row) { return _this.selection.select(row); });
    };
    UserComponent.prototype.getUsers = function () {
        var _this = this;
        this._identityService.getUserList()
            .subscribe(function (data) {
            _this.dataSource = new table_1.MatTableDataSource(data);
        });
    };
    UserComponent.prototype.getOffices = function () {
        var _this = this;
        this._settingService.getOfficeList()
            .subscribe(function (data) {
            _this.offices = data;
        });
    };
    UserComponent.prototype.openUserDialog = function (user) {
        var _this = this;
        var dialogRef = this.dialog.open(user_dialog_component_1.UserDialogComponent, {
            data: user
        });
        dialogRef.afterClosed().subscribe(function (user) {
            if (user) {
                // this.get;
            }
            _this.getOffices();
        });
    };
    UserComponent = __decorate([
        core_1.Component({
            selector: 'app-user',
            templateUrl: './user.component.html',
            styleUrls: ['./user.component.scss']
        })
    ], UserComponent);
    return UserComponent;
}());
exports.UserComponent = UserComponent;
