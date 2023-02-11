"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.ApplicantProfileModule = void 0;
var dialog_1 = require("@angular/material/dialog");
var img_pdf_viewer_1 = require("img-pdf-viewer");
var pipes_module_1 = require("./../../shared/pipes/pipes.module");
var applicant_profile_routing_module_1 = require("./applicant-profile-routing.module");
var applicant_profile_component_1 = require("./applicant-profile.component");
var router_1 = require("@angular/router");
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var core_2 = require("@videogular/ngx-videogular/core");
var controls_1 = require("@videogular/ngx-videogular/controls");
var overlay_play_1 = require("@videogular/ngx-videogular/overlay-play");
var buffering_1 = require("@videogular/ngx-videogular/buffering");
var shared_module_1 = require("src/app/shared/shared.module");
var add_applicant_component_1 = require("./pages/add-applicant/add-applicant.component");
var applicant_list_component_1 = require("./pages/applicant-list/applicant-list.component");
var applicant_detail_component_1 = require("./pages/applicant-detail/applicant-detail.component");
var ngx_pagination_1 = require("ngx-pagination");
var ngx_print_1 = require("ngx-print");
var buttons_1 = require("ngx-sharebuttons/buttons");
var icons_1 = require("ngx-sharebuttons/icons");
var ApplicantProfileModule = /** @class */ (function () {
    function ApplicantProfileModule() {
    }
    ApplicantProfileModule = __decorate([
        core_1.NgModule({
            declarations: [
                add_applicant_component_1.AddApplicantComponent,
                applicant_profile_component_1.ApplicantProfileComponent,
                applicant_list_component_1.ApplicantListComponent,
                applicant_detail_component_1.ApplicantDetailComponent,
            ],
            imports: [
                common_1.CommonModule,
                shared_module_1.SharedModule,
                router_1.RouterModule,
                buttons_1.ShareButtonsModule,
                icons_1.ShareIconsModule,
                pipes_module_1.PipesModule,
                ngx_print_1.NgxPrintModule,
                ngx_pagination_1.NgxPaginationModule,
                applicant_profile_routing_module_1.ApplicantProfileRoutingModule,
                core_2.VgCoreModule,
                controls_1.VgControlsModule,
                overlay_play_1.VgOverlayPlayModule,
                buffering_1.VgBufferingModule,
                img_pdf_viewer_1.ImgPdfViewerModule
            ],
            exports: [
                shared_module_1.SharedModule,
                applicant_profile_routing_module_1.ApplicantProfileRoutingModule
            ],
            providers: [
                { provide: dialog_1.MAT_DIALOG_DATA, useValue: {} },
                { provide: dialog_1.MatDialogRef, useValue: {} }
            ],
            bootstrap: [applicant_profile_component_1.ApplicantProfileComponent]
        })
    ], ApplicantProfileModule);
    return ApplicantProfileModule;
}());
exports.ApplicantProfileModule = ApplicantProfileModule;
