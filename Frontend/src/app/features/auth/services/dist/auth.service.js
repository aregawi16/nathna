"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.AuthService = void 0;
var http_api_1 = require("./../../../core/interceptor/http-api");
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var operators_1 = require("rxjs/operators");
var environment_1 = require("src/environments/environment");
var OAUTH_DATA = environment_1.environment.oauth;
var AuthService = /** @class */ (function () {
    function AuthService(http) {
        this.http = http;
        this.incorrectCredential = false;
    }
    AuthService.prototype.register = function (userRequest) {
        var data = {
            code: userRequest.codigo,
            email: userRequest.email,
            password: userRequest.password
        };
        return this.http.post(http_api_1.HttpApi.userRegister, data)
            .pipe(operators_1.map(function (response) {
            return response;
        }));
    };
    AuthService.prototype.loginWithUserCredentials = function (loginInfo) {
        var headers = new http_1.HttpHeaders();
        headers = headers.set('Content-Type', 'application/x-www-form-urlencoded');
        var body = new URLSearchParams();
        // body.set('grant_type', 'password');
        // body.set('client_id', OAUTH_DATA.client_id);
        // body.set('client_secret', OAUTH_DATA.client_secret);
        // body.set('UserName', username);
        // body.set('Password', password);
        // body.set('scope', OAUTH_DATA.scope);
        return this.http.post(http_api_1.HttpApi.oauthLogin, loginInfo, { headers: headers })
            .pipe(operators_1.map(function (response) {
            localStorage.setItem('access_token', JSON.stringify(response));
            return response;
        }));
    };
    AuthService.prototype.loginWithRefreshToken = function () {
        var headers = new http_1.HttpHeaders();
        headers = headers.set('Content-Type', 'application/x-www-form-urlencoded');
        var body = new URLSearchParams();
        body.set('grant_type', 'refresh_token');
        body.set('client_id', OAUTH_DATA.client_id);
        body.set('client_secret', OAUTH_DATA.client_secret);
        body.set('refresh_token', this.refreshToken);
        body.set('scope', OAUTH_DATA.scope);
        return this.http.post(http_api_1.HttpApi.oauthLogin, { headers: headers })
            .pipe(operators_1.map(function (response) {
            localStorage.setItem('access_token', JSON.stringify(response.token));
            return response;
        }));
    };
    AuthService.prototype.isLogged = function () {
        return localStorage.getItem('access_token') ? true : false;
    };
    AuthService.prototype.logout = function () {
        localStorage.clear();
        window.location.reload();
    };
    Object.defineProperty(AuthService.prototype, "accessToken", {
        get: function () {
            return localStorage['access_token'] ? JSON.parse(localStorage['access_token']) : null;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(AuthService.prototype, "refreshToken", {
        get: function () {
            return localStorage['access_token'] ? JSON.parse(localStorage['access_token']).refresh_token : null;
        },
        enumerable: false,
        configurable: true
    });
    AuthService = __decorate([
        core_1.Injectable({
            providedIn: 'root'
        })
    ], AuthService);
    return AuthService;
}());
exports.AuthService = AuthService;
