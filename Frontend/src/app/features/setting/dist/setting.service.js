"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.SettingService = void 0;
var operators_1 = require("rxjs/operators");
var http_api_1 = require("src/app/core/interceptor/http-api");
var core_1 = require("@angular/core");
var SettingService = /** @class */ (function () {
    function SettingService(_http) {
        this._http = _http;
    }
    //Common Job API
    SettingService.prototype.getCommonJobList = function () {
        return this._http.get(http_api_1.HttpApi.getJobList)
            .pipe(operators_1.map(function (response) {
            console.log(response);
            return response;
        }));
    };
    SettingService.prototype.createCommonJob = function (data) {
        return this._http.post(http_api_1.HttpApi.getJobList, data)
            .pipe(operators_1.map(function (response) {
            console.log(response);
            return response;
        }));
    };
    SettingService.prototype.deleteCommonJob = function (id) {
        return this._http["delete"](http_api_1.HttpApi.getJobList + '/' + id)
            .pipe(operators_1.map(function (response) {
        }));
    };
    //Country Api
    SettingService.prototype.getCountryList = function () {
        return this._http.get(http_api_1.HttpApi.getCountryList)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.getCountrys = function () {
        return this._http.get(http_api_1.HttpApi.country)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.createCountry = function (data) {
        return this._http.post(http_api_1.HttpApi.country, data)
            .pipe(operators_1.map(function (response) {
            console.log(response);
            return response;
        }));
    };
    SettingService.prototype.deleteCountry = function (id) {
        return this._http["delete"](http_api_1.HttpApi.country + '/' + id)
            .pipe(operators_1.map(function (response) {
        }));
    };
    SettingService.prototype.getAgentList = function () {
        return this._http.get(http_api_1.HttpApi.getAgentList)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.getAgents = function () {
        return this._http.get(http_api_1.HttpApi.agent)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.createAgent = function (data) {
        return this._http.post(http_api_1.HttpApi.agent, data)
            .pipe(operators_1.map(function (response) {
            console.log(response);
            return response;
        }));
    };
    SettingService.prototype.deleteAgent = function (id) {
        return this._http["delete"](http_api_1.HttpApi.agent + '/' + id)
            .pipe(operators_1.map(function (response) {
        }));
    };
    // Office API
    SettingService.prototype.getOfficeList = function () {
        return this._http.get(http_api_1.HttpApi.getOfficeList)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.getOffices = function () {
        return this._http.get(http_api_1.HttpApi.office)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.createOffice = function (data) {
        return this._http.post(http_api_1.HttpApi.office, data)
            .pipe(operators_1.map(function (response) {
            console.log(response);
            return response;
        }));
    };
    SettingService.prototype.deleteOffice = function (id) {
        return this._http["delete"](http_api_1.HttpApi.office + '/' + id)
            .pipe(operators_1.map(function (response) {
        }));
    };
    // Role API
    SettingService.prototype.getRoleList = function () {
        return this._http.get(http_api_1.HttpApi.userRole)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.getRoles = function () {
        return this._http.get(http_api_1.HttpApi.getUserRole)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    SettingService.prototype.createRole = function (data) {
        return this._http.post(http_api_1.HttpApi.userRole, data)
            .pipe(operators_1.map(function (response) {
            console.log(response);
            return response;
        }));
    };
    SettingService.prototype.deleteRole = function (id) {
        return this._http["delete"](http_api_1.HttpApi.userRole + '/' + id)
            .pipe(operators_1.map(function (response) {
        }));
    };
    SettingService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], SettingService);
    return SettingService;
}());
exports.SettingService = SettingService;
