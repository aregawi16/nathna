"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.SharedModule = void 0;
var confirm_dialog_component_1 = require("./components/confirm-dialog/confirm-dialog.component");
var pipes_module_1 = require("./pipes/pipes.module");
var router_1 = require("@angular/router");
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var forms_1 = require("@angular/forms");
var toolbar_1 = require("@angular/material/toolbar");
var card_1 = require("@angular/material/card");
var menu_1 = require("@angular/material/menu");
var icon_1 = require("@angular/material/icon");
var button_1 = require("@angular/material/button");
var button_toggle_1 = require("@angular/material/button-toggle");
var table_1 = require("@angular/material/table");
var select_1 = require("@angular/material/select");
var progress_bar_1 = require("@angular/material/progress-bar");
var progress_spinner_1 = require("@angular/material/progress-spinner");
var tabs_1 = require("@angular/material/tabs");
var checkbox_1 = require("@angular/material/checkbox");
var input_1 = require("@angular/material/input");
var form_field_1 = require("@angular/material/form-field");
var http_1 = require("@angular/common/http");
var core_2 = require("@ngx-translate/core");
var flex_layout_1 = require("@angular/flex-layout");
var sidenav_1 = require("@angular/material/sidenav");
var slide_toggle_1 = require("@angular/material/slide-toggle");
var slider_1 = require("@angular/material/slider");
var core_3 = require("@angular/material/core");
var list_1 = require("@angular/material/list");
var datepicker_1 = require("@angular/material/datepicker");
var grid_list_1 = require("@angular/material/grid-list");
var tooltip_1 = require("@angular/material/tooltip");
var paginator_1 = require("@angular/material/paginator");
var snack_bar_1 = require("@angular/material/snack-bar");
var sort_1 = require("@angular/material/sort");
var a11y_1 = require("@angular/cdk/a11y");
var clipboard_1 = require("@angular/cdk/clipboard");
var drag_drop_1 = require("@angular/cdk/drag-drop");
var portal_1 = require("@angular/cdk/portal");
var scrolling_1 = require("@angular/cdk/scrolling");
var stepper_1 = require("@angular/cdk/stepper");
var table_2 = require("@angular/cdk/table");
var tree_1 = require("@angular/cdk/tree");
var autocomplete_1 = require("@angular/material/autocomplete");
var badge_1 = require("@angular/material/badge");
var bottom_sheet_1 = require("@angular/material/bottom-sheet");
var chips_1 = require("@angular/material/chips");
var dialog_1 = require("@angular/material/dialog");
var divider_1 = require("@angular/material/divider");
var expansion_1 = require("@angular/material/expansion");
var radio_1 = require("@angular/material/radio");
var tree_2 = require("@angular/material/tree");
var overlay_1 = require("@angular/cdk/overlay");
var ngx_perfect_scrollbar_1 = require("ngx-perfect-scrollbar");
var ngx_perfect_scrollbar_2 = require("ngx-perfect-scrollbar");
var stepper_2 = require("@angular/material/stepper");
var image_uploader_component_1 = require("./components/image-uploader/image-uploader.component");
var report_header_component_1 = require("./components/report-header/report-header.component");
var DEFAULT_PERFECT_SCROLLBAR_CONFIG = {
    wheelPropagation: true,
    suppressScrollX: true
};
var SharedModule = /** @class */ (function () {
    function SharedModule() {
    }
    SharedModule = __decorate([
        core_1.NgModule({
            declarations: [
                image_uploader_component_1.ImageUploaderComponent,
                confirm_dialog_component_1.ConfirmDialogComponent,
                report_header_component_1.ReportHeaderComponent
            ],
            imports: [
                common_1.CommonModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                card_1.MatCardModule,
                list_1.MatListModule,
                core_2.TranslateModule,
                form_field_1.MatFormFieldModule,
                checkbox_1.MatCheckboxModule,
                input_1.MatInputModule,
                menu_1.MatMenuModule,
                http_1.HttpClientModule,
                router_1.RouterModule,
                button_1.MatButtonModule,
                table_1.MatTableModule,
                progress_spinner_1.MatProgressSpinnerModule,
                progress_bar_1.MatProgressBarModule,
                paginator_1.MatPaginatorModule,
                core_3.MatRippleModule,
                toolbar_1.MatToolbarModule,
                tabs_1.MatTabsModule,
                icon_1.MatIconModule,
                progress_bar_1.MatProgressBarModule,
                progress_spinner_1.MatProgressSpinnerModule,
                pipes_module_1.PipesModule,
                flex_layout_1.FlexLayoutModule,
                ngx_perfect_scrollbar_1.PerfectScrollbarModule,
                sidenav_1.MatSidenavModule,
                slide_toggle_1.MatSlideToggleModule,
                slider_1.MatSliderModule,
                stepper_2.MatStepperModule,
                datepicker_1.MatDatepickerModule,
                core_3.MatNativeDateModule,
                grid_list_1.MatGridListModule,
                tooltip_1.MatTooltipModule,
                sort_1.MatSortModule,
                snack_bar_1.MatSnackBarModule
            ],
            exports: [
                card_1.MatCardModule,
                forms_1.FormsModule,
                tabs_1.MatTabsModule,
                toolbar_1.MatToolbarModule,
                form_field_1.MatFormFieldModule,
                forms_1.ReactiveFormsModule,
                input_1.MatInputModule,
                list_1.MatListModule,
                button_1.MatButtonModule,
                button_toggle_1.MatButtonToggleModule,
                core_2.TranslateModule,
                menu_1.MatMenuModule,
                menu_1.MatMenuTrigger,
                progress_spinner_1.MatProgressSpinnerModule,
                progress_bar_1.MatProgressBarModule,
                paginator_1.MatPaginatorModule,
                tooltip_1.MatTooltipModule,
                http_1.HttpClientModule,
                router_1.RouterModule,
                checkbox_1.MatCheckboxModule,
                core_3.MatRippleModule,
                icon_1.MatIconModule,
                progress_bar_1.MatProgressBarModule,
                progress_spinner_1.MatProgressSpinnerModule,
                pipes_module_1.PipesModule,
                flex_layout_1.FlexLayoutModule,
                ngx_perfect_scrollbar_1.PerfectScrollbarModule,
                sidenav_1.MatSidenavModule,
                slide_toggle_1.MatSlideToggleModule,
                slider_1.MatSliderModule,
                stepper_2.MatStepperModule,
                datepicker_1.MatDatepickerModule,
                core_3.MatNativeDateModule,
                grid_list_1.MatGridListModule,
                sort_1.MatSortModule,
                snack_bar_1.MatSnackBarModule,
                table_1.MatTableModule,
                image_uploader_component_1.ImageUploaderComponent,
                report_header_component_1.ReportHeaderComponent,
                a11y_1.A11yModule,
                clipboard_1.ClipboardModule,
                stepper_1.CdkStepperModule,
                table_2.CdkTableModule,
                tree_1.CdkTreeModule,
                drag_drop_1.DragDropModule,
                autocomplete_1.MatAutocompleteModule,
                badge_1.MatBadgeModule,
                bottom_sheet_1.MatBottomSheetModule,
                button_1.MatButtonModule,
                button_toggle_1.MatButtonToggleModule,
                card_1.MatCardModule,
                checkbox_1.MatCheckboxModule,
                chips_1.MatChipsModule,
                stepper_2.MatStepperModule,
                datepicker_1.MatDatepickerModule,
                dialog_1.MatDialogModule,
                divider_1.MatDividerModule,
                expansion_1.MatExpansionModule,
                grid_list_1.MatGridListModule,
                icon_1.MatIconModule,
                input_1.MatInputModule,
                list_1.MatListModule,
                menu_1.MatMenuModule,
                core_3.MatNativeDateModule,
                paginator_1.MatPaginatorModule,
                progress_bar_1.MatProgressBarModule,
                progress_spinner_1.MatProgressSpinnerModule,
                radio_1.MatRadioModule,
                core_3.MatRippleModule,
                select_1.MatSelectModule,
                sidenav_1.MatSidenavModule,
                slider_1.MatSliderModule,
                slide_toggle_1.MatSlideToggleModule,
                snack_bar_1.MatSnackBarModule,
                sort_1.MatSortModule,
                table_1.MatTableModule,
                tabs_1.MatTabsModule,
                toolbar_1.MatToolbarModule,
                tooltip_1.MatTooltipModule,
                tree_2.MatTreeModule,
                overlay_1.OverlayModule,
                portal_1.PortalModule,
                scrolling_1.ScrollingModule
            ],
            providers: [
                { provide: ngx_perfect_scrollbar_2.PERFECT_SCROLLBAR_CONFIG, useValue: DEFAULT_PERFECT_SCROLLBAR_CONFIG }
            ]
        })
    ], SharedModule);
    return SharedModule;
}());
exports.SharedModule = SharedModule;
