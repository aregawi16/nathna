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
exports.AddApplicantComponent = void 0;
var dialog_1 = require("@angular/material/dialog");
var marital_status_enum_1 = require("./../../../../core/constants/marital-status.enum");
var common_1 = require("@angular/common");
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var stepper_1 = require("@angular/cdk/stepper");
var gender_enum_1 = require("src/app/core/constants/gender.enum");
var religion_enum_1 = require("src/app/core/constants/religion.enum");
var priority_enum_1 = require("src/app/core/constants/priority.enum");
/**
 * @title Stepper with customized states
**/
var AddApplicantComponent = /** @class */ (function () {
    function AddApplicantComponent(_formBuilder, _snackBar, applicantProfileEditData, _settingService, _applicantProfileService) {
        this._formBuilder = _formBuilder;
        this._snackBar = _snackBar;
        this.applicantProfileEditData = applicantProfileEditData;
        this._settingService = _settingService;
        this._applicantProfileService = _applicantProfileService;
        this.horizontalPosition = 'start';
        this.verticalPosition = 'bottom';
        this.model = {
            userName: '',
            password: '',
            rememberMe: false
        };
        this.disabled = false;
        this.priorityList = priority_enum_1.Priority;
        this.genderList = gender_enum_1.Gender;
        this.maritalStatusList = marital_status_enum_1.MaritalStatus;
        this.refNo = "nnn";
        this.hidden = false;
        this.religionList = religion_enum_1.Religion;
        this.locale = 'en-US';
        this.format = 'MM-dd-yyyy';
        this.formData = new FormData();
        this.isEditable = false;
        this.commonJobs = [];
        this.countrys = [];
        this.agents = [];
        this.workExperienceForm = this._formBuilder.group({
            rows: this._formBuilder.array([])
        });
        this.experiencedJobFormGroup = this._formBuilder.group({
            jobs: this._formBuilder.array([])
        });
        //Personal Info
        this.personalInfoFormGroup = this._formBuilder.group({
            applicantProfileId: [''],
            firstName: ['', [forms_1.Validators.required]],
            firstNameAm: ['', [forms_1.Validators.required]],
            lastName: ['', [forms_1.Validators.required]],
            lastNameAm: ['', [forms_1.Validators.required]],
            middleName: ['', [forms_1.Validators.required]],
            middleNameAm: ['', [forms_1.Validators.required]],
            phoneNumber: ['', [forms_1.Validators.required, forms_1.Validators.maxLength(10)]],
            passportNo: ['', [forms_1.Validators.required, forms_1.Validators.maxLength(10)]],
            passportIssueDate: ['', [forms_1.Validators.required]],
            passportExpiryDate: ['', [forms_1.Validators.required]],
            referenceNo: ['', [forms_1.Validators.required]],
            doB: ['', [forms_1.Validators.required]],
            nationality: ['', [forms_1.Validators.required]],
            maritalStatus: ['', [forms_1.Validators.required]],
            gender: ['', [forms_1.Validators.required]],
            noOfChildren: ['', [forms_1.Validators.required]],
            religion: ['', [forms_1.Validators.required]],
            agentId: ['', [forms_1.Validators.required]],
            priority: ['', [forms_1.Validators.required]],
            height: ['', [forms_1.Validators.required]],
            weight: ['', [forms_1.Validators.required]],
            city: ['', [forms_1.Validators.required]],
            wereda: ['', [forms_1.Validators.required]],
            kebelle: ['', [forms_1.Validators.required]],
            isDeleted: [false],
            workExperiences: [],
            contactPerson: {},
            experiencedJobs: [],
            applicantDocument: {}
        });
        // this.workExperienceFormGroup = this._formBuilder.group({
        //   startDate: ['', Validators.required],
        //   endDate: ['', Validators.required],
        //   country: ['', Validators.required],
        //   jobDescription: ['', Validators.required],
        // });
        this.contactPersonFormGroup = this._formBuilder.group({
            fullName: ['', forms_1.Validators.required],
            phoneNumber: ['', forms_1.Validators.required],
            email: ['', forms_1.Validators.required],
            city: ['', forms_1.Validators.required],
            wereda: ['', forms_1.Validators.required],
            kebelle: ['', forms_1.Validators.required]
        });
        this.initGroup();
        this.initCommonJobs();
        this.getAgents();
        this.documentFormGroup = this._formBuilder.group({
            applicantPassport: [''],
            applicantId: [''],
            contactDocument: [''],
            applicantVideo: [''],
            applicantShortPhoto: [''],
            applicantFullPhoto: ['']
        });
        this.countries = _applicantProfileService.getCountries();
        this.getCountrys();
        this.genders = Object.keys(this.genderList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
        this.maritalStatuses = Object.keys(this.maritalStatusList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
        console.log(this.maritalStatuses);
        this.religions = Object.keys(this.religionList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
        this.priorities = Object.keys(this.priorityList).map(function (key) { return parseInt(key); }).filter(function (f) { return !isNaN(Number(f)); });
    }
    AddApplicantComponent.prototype.ngOnInit = function () {
        console.log(this.applicantProfileEditData);
        if (this.applicantProfileEditData) {
            this.personalInfoFormGroup.patchValue(this.applicantProfileEditData);
        }
    };
    AddApplicantComponent.prototype.initGroup = function () {
        var rows = this.workExperienceForm.get('rows');
        rows.push(this._formBuilder.group({
            ApplicantProfileId: [1],
            startDate: ['', forms_1.Validators.required],
            endDate: ['', forms_1.Validators.required],
            country: ['', forms_1.Validators.required],
            jobDescription: ['', forms_1.Validators.required]
        }));
    };
    AddApplicantComponent.prototype.transformDate = function (date) {
        console.log(common_1.formatDate(date, this.format, this.locale));
        return common_1.formatDate(date, this.format, this.locale);
    };
    AddApplicantComponent.prototype.initCommonJobs = function () {
        var _this = this;
        this._applicantProfileService.getCommonJobs()
            .subscribe(function (data) {
            _this.commonJobs = data;
            _this.commonJobs.forEach(function (item) {
                var jobs = _this.experiencedJobFormGroup.get('jobs');
                jobs.push(_this._formBuilder.group({
                    commonJobId: item.id,
                    commonJobName: item.name,
                    haveExperience: false
                }));
            });
            console.log(_this.commonJobs);
            console.log(_this.experiencedJobFormGroup['controls']['jobs']['controls']);
        });
    };
    AddApplicantComponent.prototype.getAgents = function () {
        var _this = this;
        this._settingService.getAgentList()
            .subscribe(function (data) {
            _this.agents = data;
        });
    };
    AddApplicantComponent.prototype.generateRefNo = function () {
        var _a;
        this.refNo = (_a = this.personalInfoFormGroup['controls']['firstName'].value) === null || _a === void 0 ? void 0 : _a.charAt(0);
        ;
    };
    AddApplicantComponent.prototype.onDeleteRow = function (rowIndex) {
        var rows = this.workExperienceForm.get('rows');
        rows.removeAt(rowIndex);
    };
    AddApplicantComponent.prototype.giveImage = function (event) {
        console.log(event.target.files[0]);
    };
    AddApplicantComponent.prototype.checkExp = function (row) {
        //row.value.haveExperience.setValue(true);
    };
    AddApplicantComponent.prototype.getJobs = function () {
        var _this = this;
        this._applicantProfileService.getCommonJobs()
            .subscribe(function (data) {
            _this.commonJobs = data;
        });
    };
    AddApplicantComponent.prototype.getCountrys = function () {
        var _this = this;
        this._settingService.getCountryList()
            .subscribe(function (data) {
            _this.countrys = data;
            console.log(_this.countrys);
            ;
        });
    };
    AddApplicantComponent.prototype.submitApplicantProfile = function () {
        var _this = this;
        this.personalInfoFormGroup.controls['workExperiences'].setValue(this.workExperienceForm.value.rows);
        this.personalInfoFormGroup.controls['contactPerson'].setValue(this.contactPersonFormGroup.value);
        this.personalInfoFormGroup.controls['experiencedJobs'].setValue(this.experiencedJobFormGroup.value.jobs);
        console.log(this.formData);
        console.log(this.personalInfoFormGroup.value);
        this._applicantProfileService.createApplicantProfile(this.personalInfoFormGroup.value)
            .subscribe(function (data) {
            _this.appProfileId = data.applicantProfileId;
            _this._snackBar.open('Applicant Detail added successfully', 'Undo', {
                duration: 10000,
                horizontalPosition: _this.horizontalPosition,
                verticalPosition: _this.verticalPosition
            });
        });
    };
    AddApplicantComponent.prototype.onSubmit = function (id) {
        var _this = this;
        this.formData.append("ApplicantProfileId", id);
        // Object.entries(this.documentFormGroup.value).forEach(([key, value]) => {
        //   this.formData.append(key,JSON.stringify(value));
        // });
        console.log(this.formData);
        console.log(this.personalInfoFormGroup.value);
        this._applicantProfileService.uplodApplicantDocument(this.formData)
            .subscribe(function (data) {
            _this._snackBar.open('Job added successfully', 'Undo', {
                duration: 10000,
                horizontalPosition: _this.horizontalPosition,
                verticalPosition: _this.verticalPosition
            });
        });
    };
    AddApplicantComponent.prototype.onChangeApplicantPassport = function (event) {
        this.documentFormGroup.controls['applicantPassport'].setValue(event.target.files[0]);
        this.formData.append("applicantPassport", event.target.files[0]);
    };
    AddApplicantComponent.prototype.onChangeApplicantId = function (event) {
        this.documentFormGroup.controls['applicantId'].setValue(event.target.files[0]);
        this.formData.append("applicantId", event.target.files[0]);
    };
    AddApplicantComponent.prototype.onChangeContactId = function (event) {
        this.documentFormGroup.controls['contactDocument'].setValue(event.target.files[0]);
        this.formData.append("contactDocument", event.target.files[0]);
    };
    AddApplicantComponent.prototype.onChangeApplicantShortPhoto = function (event) {
        this.documentFormGroup.controls['applicantShortPhoto'].setValue(event.target.files[0]);
        this.formData.append("applicantShortPhoto", event.target.files[0]);
    };
    AddApplicantComponent.prototype.onChangeApplicantFullPhoto = function (event) {
        this.documentFormGroup.controls['applicantFullPhoto'].setValue(event.target.files[0]);
        this.formData.append("applicantFullPhoto", event.target.files[0]);
    };
    AddApplicantComponent.prototype.onChangeApplicantVideo = function (event) {
        this.documentFormGroup.controls['applicantVideo'].setValue(event.target.files[0]);
        this.formData.append("applicantVideo", event.target.files[0]);
    };
    AddApplicantComponent = __decorate([
        core_1.Component({
            selector: 'add-applicant',
            templateUrl: 'add-applicant.component.html',
            styleUrls: ['add-applicant.component.scss'],
            providers: [
                {
                    provide: stepper_1.STEPPER_GLOBAL_OPTIONS,
                    useValue: { displayDefaultIndicatorType: false }
                },
            ]
        }),
        __param(2, core_1.Inject(dialog_1.MAT_DIALOG_DATA))
    ], AddApplicantComponent);
    return AddApplicantComponent;
}());
exports.AddApplicantComponent = AddApplicantComponent;
