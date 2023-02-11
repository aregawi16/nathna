import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, Inject } from '@angular/core';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';

@Component({
  selector: 'app-receive-yellow-card',
  templateUrl: './receive-yellow-card.component.html',
  styleUrls: ['./receive-yellow-card.component.scss']
})
export class ReceiveYellowCardComponent {
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  yellowCardDocumentFormGroup: FormGroup;
  formData = new FormData();
  constructor(
    public dialogRef: MatDialogRef<ReceiveYellowCardComponent>,
    @Inject(MAT_DIALOG_DATA) public id: any,
    private _formBuilder:FormBuilder,
    private _processManagementService: ProcessManagementService,
    private _httpClient: HttpClient,
     private _dialog : MatDialog,
    private _snackBar : MatSnackBar
  )
  {
  }
  ngOnInit(): void {
    this.yellowCardDocumentFormGroup = this._formBuilder.group({
      applicantId: [''],
      price: [''],
      yellowCardDocument: [''],
    });

  }

  uploadDocument()
  {
    this.formData.append("applicantId",this.id);
    this.formData.append("price",this.yellowCardDocumentFormGroup.controls.price.value);
    // Object.entries(this.documentFormGroup.value).forEach(([key, value]) => {
    //   this.formData.append(key,JSON.stringify(value));
    // });
    console.log(this.formData);
      console.log(this.yellowCardDocumentFormGroup.value);
      this._processManagementService.receieveYellowRecord(this.formData)
      .subscribe(data => {

        this._snackBar.open('Yellow Card Uploaded  successfully', 'Undo', {
          duration:10000,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });

        this.dialogRef.close();

      });
  }

  onChangeYellowCard(event)
{
  console.log(event.target.files[0]);
  this.formData.append("yellowCardDocument",event.target.files[0]);
}

}
