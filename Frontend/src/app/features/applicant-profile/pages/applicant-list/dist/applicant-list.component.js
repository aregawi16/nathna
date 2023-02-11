"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.ApplicantListComponent = void 0;
var applicant_required_verified_document_component_1 = require("./../../../process-management/pages/applicant-required-verified-document/applicant-required-verified-document.component");
var status_enum_1 = require("./../../../../core/constants/status.enum");
var confirm_dialog_component_1 = require("./../../../../shared/components/confirm-dialog/confirm-dialog.component");
var forms_1 = require("@angular/forms");
var collections_1 = require("@angular/cdk/collections");
var table_1 = require("@angular/material/table");
var environment_1 = require("./../../../../../environments/environment");
var religion_enum_1 = require("./../../../../core/constants/religion.enum");
var marital_status_enum_1 = require("./../../../../core/constants/marital-status.enum");
var add_applicant_component_1 = require("./../add-applicant/add-applicant.component");
var core_1 = require("@angular/core");
var gender_enum_1 = require("src/app/core/constants/gender.enum");
var ApplicantListComponent = /** @class */ (function () {
    function ApplicantListComponent(_formBuilder, dialog, _snackBar, _applicantService, _settingService) {
        this._formBuilder = _formBuilder;
        this.dialog = dialog;
        this._snackBar = _snackBar;
        this._applicantService = _applicantService;
        this._settingService = _settingService;
        this.displayedColumns = ['select', 'id', 'fullName', 'phoneNumber', 'passportNumber', 'agentId', 'status', 'action'];
        this.dataSource = new table_1.MatTableDataSource();
        this.selection = new collections_1.SelectionModel(true, []);
        this.horizontalPosition = 'start';
        this.verticalPosition = 'bottom';
        this.base_url = environment_1.environment.backend.base_url;
        this.isAnySelected = false;
        this.genderList = gender_enum_1.Gender;
        this.maritalStatusList = marital_status_enum_1.MaritalStatus;
        this.religionList = religion_enum_1.Religion;
        this.statusList = status_enum_1.Status;
        this.host = environment_1.environment.backend.base_url;
    }
    ApplicantListComponent.prototype.ngOnInit = function () {
        this.getApplicantProfiles();
        this.genders = Object.keys(this.genderList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
        this.maritalStatuses = Object.keys(this.maritalStatusList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
        this.statuses = Object.keys(this.statusList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
        this.religions = Object.keys(this.religionList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
        this.getAgents();
        this.getOffices();
        this.placementFormGroup = this._formBuilder.group({
            officeId: ['', forms_1.Validators.required],
            applicantIds: []
        });
    };
    ApplicantListComponent.prototype.getApplicantProfiles = function () {
        var _this = this;
        this._applicantService.getApplicantRofiles()
            .subscribe(function (data) {
            _this.applicantProfiles = data;
            _this.dataSource = new table_1.MatTableDataSource(data);
            console.log(data);
        });
    };
    ApplicantListComponent.prototype.checkDeleteStatus = function (applicantPlacement) {
        if (applicantPlacement == null) {
            return true;
        }
        else {
            return false;
        }
    };
    ApplicantListComponent.prototype.checkUploadStatus = function (applicantPlacement) {
        if (applicantPlacement == null) {
            return false;
        }
        else {
            if (applicantPlacement.status == this.statusList.Selected) {
                return true;
            }
            return false;
        }
    };
    ApplicantListComponent.prototype.placeApplicant = function () {
        var _this = this;
        if (this.placementFormGroup.valid) {
            var dialogRef = this.dialog.open(confirm_dialog_component_1.ConfirmDialogComponent, {
                maxWidth: "400px",
                data: {
                    title: "Confirm Placement",
                    message: "Are you sure to assign offices?"
                }
            });
            dialogRef.afterClosed().subscribe(function (customer) {
                var ids = _this.selection.selected.map(function (obj) { return obj.applicantProfileId; });
                _this.placementFormGroup.controls['applicantIds'].setValue(ids);
                console.log(_this.placementFormGroup.value);
                _this._applicantService.placeApplicant(_this.placementFormGroup.value)
                    .subscribe(function (data) {
                    _this._snackBar.open('Job added successfully', 'Undo', {
                        duration: 10000,
                        horizontalPosition: _this.horizontalPosition,
                        verticalPosition: _this.verticalPosition
                    });
                    _this.selection.clear();
                    _this.isAnySelected = false;
                });
            });
        }
    };
    ApplicantListComponent.prototype.addApplicantProfile = function (applicantProfile) {
    };
    ApplicantListComponent.prototype.updateApplicantProfile = function (applicantProfile) {
    };
    ApplicantListComponent.prototype.deleteApplicantProfile = function (id) {
        var _this = this;
        var dialogRef = this.dialog.open(confirm_dialog_component_1.ConfirmDialogComponent, {
            maxWidth: "400px",
            data: {
                title: "Confirm Action",
                message: "Are you sure you want remove this Applicant?"
            }
        });
        dialogRef.afterClosed().subscribe(function (dialogResult) {
            if (dialogResult) {
                _this._applicantService.deleteApplicantRofile(id)
                    .subscribe(function () {
                    var index = _this.applicantProfiles.findIndex(function (x) { return x.applicantProfileId == id; });
                    if (index !== -1) {
                        _this.applicantProfiles = _this.applicantProfiles.splice(index, 1);
                    }
                    // this.applicantProfiles = data;
                    // console.log(data);
                });
            }
        });
    };
    ApplicantListComponent.prototype.detailApplicantProfile = function (applicantProfile) {
        var _this = this;
        this._applicantService.getApplicantRofileById(applicantProfile.applicantProfileId)
            .subscribe(function (data) {
            _this.applicantProfiles = data;
            console.log(data);
        });
    };
    ApplicantListComponent.prototype.uploadVerifiedDocument = function (id) {
        var dialogRef = this.dialog.open(applicant_required_verified_document_component_1.ApplicantRequiredVerifiedDocumentComponent, {
            maxWidth: "400px"
        });
        dialogRef.afterClosed().subscribe(function (dialogResult) {
            if (dialogResult) {
            }
        });
    };
    /** Whether the number of selected elements matches the total number of rows. */
    ApplicantListComponent.prototype.isAllSelected = function () {
        var numSelected = this.selection.selected.length;
        var numRows = this.dataSource.data.length;
        return numSelected === numRows;
    };
    /** Selects all rows if they are not all selected; otherwise clear selection. */
    ApplicantListComponent.prototype.masterToggle = function () {
        var _this = this;
        this.isAllSelected() ?
            this.selection.clear() :
            this.dataSource.data.forEach(function (row) { return _this.selection.select(row); });
        if (this.selection.selected.length > 0) {
            this.isAnySelected = true;
        }
        else {
            this.isAnySelected = false;
        }
    };
    ApplicantListComponent.prototype.selectRow = function (row) {
        this.selection.toggle(row);
        this.isAnySelected = true;
        if (this.selection.selected.length > 0) {
            this.isAnySelected = true;
        }
        else {
            this.isAnySelected = false;
        }
        console.log(this.selection.selected);
    };
    /** The label for the checkbox on the passed row */
    ApplicantListComponent.prototype.checkboxLabel = function (row) {
        console.log(row);
        if (!row) {
            return (this.isAllSelected() ? 'deselect' : 'select') + " all";
        }
        return (this.selection.isSelected(row) ? 'deselect' : 'select') + " row " + (row.id + 1);
    };
    ApplicantListComponent.prototype.getAgents = function () {
        var _this = this;
        this._settingService.getAgentList()
            .subscribe(function (data) {
            _this.agents = data;
        });
    };
    ApplicantListComponent.prototype.getOffices = function () {
        var _this = this;
        this._settingService.getOfficeList()
            .subscribe(function (data) {
            _this.offices = data;
        });
    };
    ApplicantListComponent.prototype.onPageChanged = function (event) {
        this.page = event;
        this.getApplicantProfiles();
        window.scrollTo(0, 0);
        // if(this.settings.fixedHeader){
        //     document.getElementById('main-content').scrollTop = 0;
        // }
        // else{
        //     document.getElementsByClassName('mat-drawer-content')[0].scrollTop = 0;
        // }
    };
    ApplicantListComponent.prototype.openApplicantProfileDialog = function (applicantProfile) {
        var _this = this;
        var dialogRef = this.dialog.open(add_applicant_component_1.AddApplicantComponent, {
            data: applicantProfile
        });
        dialogRef.afterClosed().subscribe(function (applicantProfile) {
            if (applicantProfile) {
                (applicantProfile.id) ? _this.updateApplicantProfile(applicantProfile) : _this.addApplicantProfile(applicantProfile);
            }
        });
    };
    ApplicantListComponent = __decorate([
        core_1.Component({
            selector: 'app-applicant-list',
            templateUrl: './applicant-list.component.html',
            styleUrls: ['./applicant-list.component.scss']
        }),
        core_1.Injectable({ providedIn: 'root' })
    ], ApplicantListComponent);
    return ApplicantListComponent;
}());
exports.ApplicantListComponent = ApplicantListComponent;
