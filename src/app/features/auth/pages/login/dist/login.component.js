"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.LoginComponent = void 0;
var core_1 = require("@angular/core");
var rxjs_1 = require("rxjs");
var forms_1 = require("@angular/forms");
var LoginComponent = /** @class */ (function () {
    function LoginComponent(_route, _router, _authService) {
        this._route = _route;
        this._router = _router;
        this._authService = _authService;
        this.loginValid = true;
        this.isLoggedInClick = false;
        this.hide = true;
        this.checked = false;
        this.disabled = false;
        this.login = {
            userName: '',
            password: '',
            rememberMe: false
        };
        this.loginForm = new forms_1.FormGroup({
            userName: new forms_1.FormControl(this.login.userName, [
                forms_1.Validators.required,
                forms_1.Validators.minLength(5)
            ]),
            password: new forms_1.FormControl(this.login.password, [
                forms_1.Validators.required,
                forms_1.Validators.minLength(8)
            ]),
            rememberMe: new forms_1.FormControl(false)
        });
        this.required = true;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this._authService.isLogged();
        {
            this._router.navigateByUrl('/');
        }
    };
    LoginComponent.prototype.onLogin = function () {
        var _this = this;
        this.isLoggedInClick = true;
        this.loginValid = true;
        console.log(this.loginForm.value);
        this._authService.loginWithUserCredentials(this.login)
            .pipe(rxjs_1.take(1)).subscribe({
            next: function (_) {
                _this.isLoggedInClick = false;
                _this.loginValid = true;
                _this._router.navigateByUrl('/');
            },
            error: function (_) { return _this.loginValid = false; }
        });
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'app-login',
            templateUrl: './login.component.html',
            styleUrls: ['./login.component.scss']
        })
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
