"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.ProcessManagementService = void 0;
var operators_1 = require("rxjs/operators");
var http_api_1 = require("src/app/core/interceptor/http-api");
var core_1 = require("@angular/core");
var ProcessManagementService = /** @class */ (function () {
    function ProcessManagementService(_http) {
        this._http = _http;
    }
    ProcessManagementService.prototype.selectApplicant = function (data) {
        return this._http.post(http_api_1.HttpApi.selectApplicant, data)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    ProcessManagementService.prototype.rejectApplicant = function (data) {
        return this._http.post(http_api_1.HttpApi.rejectApplicant, data)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    ProcessManagementService.prototype.uplodVerifiedApplicantDocument = function (data) {
        return this._http.post(http_api_1.HttpApi.uploadVerifiedDocumentApplicant, data)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    ProcessManagementService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], ProcessManagementService);
    return ProcessManagementService;
}());
exports.ProcessManagementService = ProcessManagementService;
