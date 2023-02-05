"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.RoleComponent = exports.Role = void 0;
var confirm_dialog_component_1 = require("./../../../../shared/components/confirm-dialog/confirm-dialog.component");
var paginator_1 = require("@angular/material/paginator");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var table_1 = require("@angular/material/table");
var Role = /** @class */ (function () {
    function Role() {
    }
    return Role;
}());
exports.Role = Role;
var RoleComponent = /** @class */ (function () {
    function RoleComponent(fb, dialog, _snackBar, _settingService, _formBuilder) {
        this.fb = fb;
        this.dialog = dialog;
        this._snackBar = _snackBar;
        this._settingService = _settingService;
        this._formBuilder = _formBuilder;
        this.displayedColumns = ['id', 'name', 'description', 'action'];
        this.dataSource = new table_1.MatTableDataSource();
        this.checkeditable = true;
        this.isLoading = true;
        this.horizontalPosition = 'start';
        this.verticalPosition = 'bottom';
        this.pageNumber = 1;
        this.isEditableNew = true;
    }
    RoleComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.RoleForm = this._formBuilder.group({
            RoleFormRows: this._formBuilder.array([])
        });
        this._settingService.getRoles()
            .subscribe(function (data) {
            _this.roles = data;
            _this.RoleForm = _this.fb.group({
                RoleFormRows: _this.fb.array(_this.roles.map(function (val) { return _this.fb.group({
                    id: new forms_1.FormControl(val.id),
                    name: new forms_1.FormControl(val.name),
                    description: new forms_1.FormControl(val.description),
                    action: new forms_1.FormControl('existingRecord'),
                    isEditable: new forms_1.FormControl(true),
                    isNewRow: new forms_1.FormControl(false)
                }); })) //end of fb array
            }); // end of form group cretation
            _this.isLoading = false;
            _this.dataSource = new table_1.MatTableDataSource(_this.RoleForm.get('RoleFormRows').controls);
            _this.dataSource.paginator = _this.paginator;
            var filterPredicate = _this.dataSource.filterPredicate;
            _this.dataSource.filterPredicate = function (data, filter) {
                return filterPredicate.call(_this.dataSource, data.value, filter);
            };
            //Custom filter according to name column
        });
    };
    RoleComponent.prototype.goToPage = function () {
        this.paginator.pageIndex = this.pageNumber - 1;
        this.paginator.page.next({
            pageIndex: this.paginator.pageIndex,
            pageSize: this.paginator.pageSize,
            length: this.paginator.length
        });
    };
    RoleComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        this.dataSource.paginator = this.paginator;
        this.paginatorList = document.getElementsByClassName('mat-paginator-range-label');
        this.onPaginateChange(this.paginator, this.paginatorList);
        this.paginator.page.subscribe(function () {
            _this.onPaginateChange(_this.paginator, _this.paginatorList);
        });
    };
    RoleComponent.prototype.applyFilter = function (event) {
        //  debugger;
        var filterValue = event.target.value;
        this.dataSource.filter = filterValue.trim().toLowerCase();
    };
    // @ViewChild('table') table: MatTable<PeriodicElement>;
    RoleComponent.prototype.AddNewRow = function () {
        // this.getBasicDetails();
        var control = this.RoleForm.get('RoleFormRows');
        control.insert(0, this.initiateRoleForm());
        this.dataSource = new table_1.MatTableDataSource(control.controls);
        // control.controls.unshift(this.initiateRoleForm());
        // this.openPanel(panel);
        // this.table.renderRows();
        // this.dataSource.data = this.dataSource.data;
    };
    // this function will enabled the select field for editd
    RoleComponent.prototype.EditRoleForm = function (RoleFormElement, i) {
        // RoleFormElement.get('RoleFormRows').at(i).get('name').disabled(false)
        RoleFormElement.get('RoleFormRows').at(i).get('isEditable').patchValue(false);
        // this.isEditableNew = true;
    };
    // On click of correct button in table (after click on edit) this method will call
    RoleComponent.prototype.SaveRoleForm = function (RoleFormElement, i) {
        var _this = this;
        this._settingService.createRole(RoleFormElement.get('RoleFormRows').at(i).value)
            .subscribe(function (data) {
            RoleFormElement.get('RoleFormRows').at(i).controls.id.setValue(data.id);
            console.log(data);
            RoleFormElement.get('RoleFormRows').at(i).get('isEditable').patchValue(true);
            _this._snackBar.open('Role added successfully', 'Undo', {
                duration: 10000,
                horizontalPosition: _this.horizontalPosition,
                verticalPosition: _this.verticalPosition
            });
        });
    };
    RoleComponent.prototype.deleteRole = function (RoleFormElement, i) {
        var _this = this;
        var dialogRef = this.dialog.open(confirm_dialog_component_1.ConfirmDialogComponent, {
            maxWidth: "400px",
            data: {
                title: "Confirm Action",
                message: "Are you sure you want remove this job?"
            }
        });
        dialogRef.afterClosed().subscribe(function (dialogResult) {
            if (dialogResult) {
                _this._settingService.deleteRole(RoleFormElement.get('RoleFormRows').at(i).controls.id.value)
                    .subscribe(function () {
                    console.log(_this.roles);
                    var index = _this.roles.findIndex(function (x) { return x.id == RoleFormElement.get('RoleFormRows').at(i).controls.id.value; });
                    if (index !== -1) {
                        _this.roles = _this.roles.splice(index, 1);
                        _this._snackBar.open('Role delted successfully', 'Undo', {
                            duration: 10000,
                            horizontalPosition: _this.horizontalPosition,
                            verticalPosition: _this.verticalPosition
                        });
                    }
                    _this.ngOnInit();
                });
            }
        });
    };
    // On click of cancel button in the table (after click on edit) this method will call and reset the previous data
    RoleComponent.prototype.CancelRoleForm = function (RoleFormElement, i) {
        RoleFormElement.get('RoleFormRows').at(i).get('isEditable').patchValue(true);
    };
    RoleComponent.prototype.onPaginateChange = function (paginator, list) {
        setTimeout(function (idx) {
            var from = (paginator.pageSize * paginator.pageIndex) + 1;
            var to = (paginator.length < paginator.pageSize * (paginator.pageIndex + 1))
                ? paginator.length
                : paginator.pageSize * (paginator.pageIndex + 1);
            var toFrom = (paginator.length == 0) ? 0 : from + " - " + to;
            var pageNumber = (paginator.length == 0) ? "0 of 0" : paginator.pageIndex + 1 + " of " + paginator.getNumberOfPages();
            var rows = "Page " + pageNumber + " (" + toFrom + " of " + paginator.length + ")";
            if (list.length >= 1)
                list[0].innerHTML = rows;
        }, 0, paginator.pageIndex);
    };
    RoleComponent.prototype.initiateRoleForm = function () {
        return this.fb.group({
            id: new forms_1.FormControl(""),
            name: new forms_1.FormControl(''),
            description: new forms_1.FormControl(''),
            action: new forms_1.FormControl('newRecord'),
            isEditable: new forms_1.FormControl(false),
            isNewRow: new forms_1.FormControl(true)
        });
    };
    __decorate([
        core_1.ViewChild(paginator_1.MatPaginator)
    ], RoleComponent.prototype, "paginator");
    RoleComponent = __decorate([
        core_1.Component({
            selector: 'app-role',
            templateUrl: './role.component.html',
            styleUrls: ['./role.component.scss']
        })
    ], RoleComponent);
    return RoleComponent;
}());
exports.RoleComponent = RoleComponent;
