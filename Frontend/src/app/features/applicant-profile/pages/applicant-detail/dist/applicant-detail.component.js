"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.ApplicantDetailComponent = void 0;
var confirm_dialog_component_1 = require("./../../../../shared/components/confirm-dialog/confirm-dialog.component");
var status_enum_1 = require("./../../../../core/constants/status.enum");
var rxjs_1 = require("rxjs");
var religion_enum_1 = require("./../../../../core/constants/religion.enum");
var marital_status_enum_1 = require("./../../../../core/constants/marital-status.enum");
var gender_enum_1 = require("./../../../../core/constants/gender.enum");
var environment_1 = require("./../../../../../environments/environment");
var paginator_1 = require("@angular/material/paginator");
var table_1 = require("@angular/material/table");
var core_1 = require("@angular/core");
var sort_1 = require("@angular/material/sort");
var ApplicantDetailComponent = /** @class */ (function () {
    function ApplicantDetailComponent(_applicantService, _settingService, _processManagementService, _httpClient, _dialog, _snackBar, activatedRoute) {
        this._applicantService = _applicantService;
        this._settingService = _settingService;
        this._processManagementService = _processManagementService;
        this._httpClient = _httpClient;
        this._dialog = _dialog;
        this._snackBar = _snackBar;
        this.activatedRoute = activatedRoute;
        this.horizontalPosition = 'start';
        this.verticalPosition = 'bottom';
        this.name = "Mr";
        this.genderList = gender_enum_1.Gender;
        this.statusList = status_enum_1.Status;
        this.maritalStatusList = marital_status_enum_1.MaritalStatus;
        this.religionList = religion_enum_1.Religion;
        this.base_url = environment_1.environment.backend.base_url;
        this.displayedWorkExperienceColumns = ['startDate', 'endDate', 'duration', 'country', 'jobDescription'];
        this.displayedExperiencedJobsColumns = ['job', 'haveExperience'];
        this.docPreviewConfig = {
            zoomIn: true,
            zoomOut: true,
            rotate: true,
            download: true,
            openModal: true,
            close: false,
            docScreenWidth: '80%',
            modalSize: 'md',
            customStyle: '',
            zoomIndicator: true
        };
    }
    ApplicantDetailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.getJobs();
        this.getAgents();
        this.getOffices();
        this.activatedRoute.params.subscribe(function (params) {
            if (params['id']) {
                _this.getApplicantProfileById(params['id']);
            }
            else {
                _this.getApplicantProfileById(1);
            }
        });
    };
    ApplicantDetailComponent.prototype.getJobs = function () {
        var _this = this;
        this._applicantService.getCommonJobs()
            .subscribe(function (data) {
            _this.jobs = data;
        });
    };
    ApplicantDetailComponent.prototype.getApplicantProfileById = function (id) {
        var _this = this;
        this._applicantService.getApplicantRofileById(id)
            .subscribe(function (data) {
            _this.applicantProfile = data;
            _this.workExperienceDataSource = new table_1.MatTableDataSource(data.workExperiences);
            _this.workExperienceDataSource.paginator = _this.paginator;
            _this.workExperienceDataSource.sort = _this.sort;
            _this.experiencedJobDataSource = new table_1.MatTableDataSource(data.experiencedJobs);
            _this.experiencedJobDataSource.paginator = _this.paginator;
            _this.experiencedJobDataSource.sort = _this.sort;
            console.log(data);
        });
    };
    ApplicantDetailComponent.prototype.downloadImage = function (imageUrl) {
        var _this = this;
        //imageUrl = this._httpClient.get("https://localhost:44374/NathnaDocuments/NIB1020FullPhoto.png");
        // imageUrl =
        //  "http://southparkstudios.mtvnimages.com/shared/characters/celebrities/mr-hankey.png?height=165";
        var documentName = imageUrl.substring(imageUrl.lastIndexOf("\\") + 1);
        this.getBase64ImageFromURL(imageUrl).subscribe(function (base64data) {
            console.log(base64data);
            _this.base64Image = "data:image/jpg;base64," + base64data;
            // save image to disk
            var link = document.createElement("a");
            document.body.appendChild(link); // for Firefox
            link.setAttribute("href", _this.base64Image);
            link.setAttribute("download", documentName);
            link.click();
        });
    };
    ApplicantDetailComponent.prototype.getBase64ImageFromURL = function (url) {
        var _this = this;
        return rxjs_1.Observable.create(function (observer) {
            var img = new Image();
            img.crossOrigin = "Anonymous";
            img.src = url;
            if (!img.complete) {
                img.onload = function () {
                    observer.next(_this.getBase64Image(img));
                    observer.complete();
                };
                img.onerror = function (err) {
                    observer.error(err);
                };
            }
            else {
                observer.next(_this.getBase64Image(img));
                observer.complete();
            }
        });
    };
    ApplicantDetailComponent.prototype.getBase64Image = function (img) {
        var canvas = document.createElement("canvas");
        canvas.width = img.width;
        canvas.height = img.height;
        var ctx = canvas.getContext("2d");
        ctx === null || ctx === void 0 ? void 0 : ctx.drawImage(img, 0, 0);
        var dataURL = canvas.toDataURL("image/png");
        return dataURL.replace(/^data:image\/(png|jpg);base64,/, "");
    };
    ApplicantDetailComponent.prototype.getAgents = function () {
        var _this = this;
        this._settingService.getAgentList()
            .subscribe(function (data) {
            _this.agents = data;
        });
    };
    ApplicantDetailComponent.prototype.getOffices = function () {
        var _this = this;
        this._settingService.getOfficeList()
            .subscribe(function (data) {
            _this.offices = data;
        });
    };
    ApplicantDetailComponent.prototype.selectApplicant = function (applicantId) {
        var _this = this;
        var dialogRef = this._dialog.open(confirm_dialog_component_1.ConfirmDialogComponent, {
            maxWidth: "400px",
            data: {
                title: "Confirm Action",
                message: "Are you sure you want select this Applicant?"
            }
        });
        dialogRef.afterClosed().subscribe(function (dialogResult) {
            if (dialogResult) {
                var data = {
                    "applicantId": applicantId,
                    "status": _this.statusList.Selected
                };
                _this._processManagementService.selectApplicant(data)
                    .subscribe(function (data) {
                    _this._snackBar.open('ApplicantSelected successfully', 'Undo', {
                        duration: 10000,
                        horizontalPosition: _this.horizontalPosition,
                        verticalPosition: _this.verticalPosition
                    });
                });
            }
        });
    };
    ApplicantDetailComponent.prototype.rejectApplicant = function (applicantId) {
    };
    ApplicantDetailComponent.prototype.checkStatus = function (applicantProfile) {
        if (applicantProfile.applicantPlacement.status == this.statusList.Assigned) {
            return true;
        }
        return false;
    };
    __decorate([
        core_1.ViewChild(paginator_1.MatPaginator)
    ], ApplicantDetailComponent.prototype, "paginator");
    __decorate([
        core_1.ViewChild(sort_1.MatSort)
    ], ApplicantDetailComponent.prototype, "sort");
    ApplicantDetailComponent = __decorate([
        core_1.Component({
            selector: 'app-applicant-detail',
            templateUrl: './applicant-detail.component.html',
            styleUrls: ['./applicant-detail.component.scss']
        })
    ], ApplicantDetailComponent);
    return ApplicantDetailComponent;
}());
exports.ApplicantDetailComponent = ApplicantDetailComponent;
