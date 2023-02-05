"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.IdentityService = void 0;
var operators_1 = require("rxjs/operators");
var http_api_1 = require("src/app/core/interceptor/http-api");
var core_1 = require("@angular/core");
var IdentityService = /** @class */ (function () {
    function IdentityService(_http) {
        this._http = _http;
    }
    IdentityService.prototype.getUserList = function () {
        return this._http.get(http_api_1.HttpApi.userList)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    IdentityService.prototype.createUser = function (data) {
        return this._http.post(http_api_1.HttpApi.userRegister, data)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    IdentityService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], IdentityService);
    return IdentityService;
}());
exports.IdentityService = IdentityService;
