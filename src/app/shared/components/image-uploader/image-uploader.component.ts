import { Component, EventEmitter, Output, Input } from '@angular/core';
import {HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-image-uploader',
  templateUrl: './image-uploader.component.html',
  styleUrls: ['./image-uploader.component.scss']
})
export class ImageUploaderComponent {

  selectedFile!: File;
  fileName !:string;
  @Input() accept!:string;
  @Output() event = new EventEmitter();
  public image: any;

  constructor(private http: HttpClient) {
  }

  /**
   *  Validate uploader params
   * @param event
   */
  public onFileSelected(event:any) {
    this.selectedFile = <File>event.target.files[0];
    if (this.selectedFile) {
      this.fileName = '....'+this.selectedFile.name.substring(this.selectedFile.name.length-10,this.selectedFile.name.length);
      return this.upload();
    }
  }


  /**
   * Upload image to server and receive image object
   */
  upload() {
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);

  }

}
