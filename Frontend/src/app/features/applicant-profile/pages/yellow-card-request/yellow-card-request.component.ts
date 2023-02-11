import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, Inject } from '@angular/core';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';


@Component({
  selector: 'app-yellow-card-request',
  templateUrl: './yellow-card-request.component.html',
  styleUrls: ['./yellow-card-request.component.scss']
})
export class YellowCardRequestComponent {
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  yellowCardFormGroup: FormGroup;
  formData = new FormData();
  constructor(
    public dialogRef: MatDialogRef<YellowCardRequestComponent>,
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
    this.yellowCardFormGroup = this._formBuilder.group({
      applicantId: [''],
      labourDocument: [''],
    });

  }

  submitYellowCardRequest()
  {
    this.formData.append("applicantId",this.id);
    console.log(this.formData);
      console.log(this.yellowCardFormGroup.value);
      this._processManagementService.requestYellowRecord(this.formData)
      .subscribe(data => {

        this._snackBar.open('Labour Document uploaded successfully', 'Undo', {
          duration:10000,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });

        this.dialogRef.close();

      });
  }

  onChangeLabourDocument(event)
{
  this.yellowCardFormGroup.controls.labourDocument.setValue(event.target.files[0]);
  console.log(event.target.files[0]);
  this.formData.append("labourDocument",event.target.files[0]);
}

}
