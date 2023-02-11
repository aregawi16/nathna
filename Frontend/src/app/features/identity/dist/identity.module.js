"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.IdentityModule = void 0;
var user_dialog_component_1 = require("./pages/user-dialog/user-dialog.component");
var identity_component_1 = require("./identity.component");
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var identity_routing_module_1 = require("./identity-routing.module");
var user_component_1 = require("./pages/user/user.component");
var role_component_1 = require("./pages/role/role.component");
var shared_module_1 = require("src/app/shared/shared.module");
var IdentityModule = /** @class */ (function () {
    function IdentityModule() {
    }
    IdentityModule = __decorate([
        core_1.NgModule({
            declarations: [
                user_component_1.UserComponent,
                role_component_1.RoleComponent,
                user_dialog_component_1.UserDialogComponent,
                identity_component_1.IdentityComponent
            ],
            imports: [
                common_1.CommonModule,
                shared_module_1.SharedModule,
                identity_routing_module_1.IdentityRoutingModule
            ]
        })
    ], IdentityModule);
    return IdentityModule;
}());
exports.IdentityModule = IdentityModule;
