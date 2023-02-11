"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
exports.__esModule = true;
exports.ImageUploaderComponent = void 0;
var core_1 = require("@angular/core");
var ImageUploaderComponent = /** @class */ (function () {
    function ImageUploaderComponent(http) {
        this.http = http;
        this.event = new core_1.EventEmitter();
    }
    /**
     *  Validate uploader params
     * @param event
     */
    ImageUploaderComponent.prototype.onFileSelected = function (event) {
        this.selectedFile = event.target.files[0];
        if (this.selectedFile) {
            this.fileName = '....' + this.selectedFile.name.substring(this.selectedFile.name.length - 10, this.selectedFile.name.length);
            return this.upload();
        }
    };
    /**
     * Upload image to server and receive image object
     */
    ImageUploaderComponent.prototype.upload = function () {
        var fd = new FormData();
        fd.append('image', this.selectedFile, this.selectedFile.name);
    };
    __decorate([
        core_1.Input()
    ], ImageUploaderComponent.prototype, "accept");
    __decorate([
        core_1.Output()
    ], ImageUploaderComponent.prototype, "event");
    ImageUploaderComponent = __decorate([
        core_1.Component({
            selector: 'app-image-uploader',
            templateUrl: './image-uploader.component.html',
            styleUrls: ['./image-uploader.component.scss']
        })
    ], ImageUploaderComponent);
    return ImageUploaderComponent;
}());
exports.ImageUploaderComponent = ImageUploaderComponent;
