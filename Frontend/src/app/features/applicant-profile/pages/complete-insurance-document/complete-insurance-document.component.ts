import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, Inject } from '@angular/core';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';

@Component({
  selector: 'app-complete-insurance-document',
  templateUrl: './complete-insurance-document.component.html',
  styleUrls: ['./complete-insurance-document.component.scss']
})
export class CompleteInsuranceDocumentComponent {
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  insuranceDocumentFormGroup: FormGroup;
  formData = new FormData();
  constructor(
    public dialogRef: MatDialogRef<CompleteInsuranceDocumentComponent>,
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
    this.insuranceDocumentFormGroup = this._formBuilder.group({
      applicantId: [''],
      price: [''],
      insuranceDocument: [''],
    });

  }

  uploadDocument()
  {
    this.formData.append("applicantId",this.id);
    // Object.entries(this.documentFormGroup.value).forEach(([key, value]) => {
    //   this.formData.append(key,JSON.stringify(value));
    // });
    console.log(this.formData);
      console.log(this.insuranceDocumentFormGroup.value);
      this._processManagementService.completeInsurance(this.formData)
      .subscribe(data => {

        this._snackBar.open('Insurance Document completed successfully', 'Undo', {
          duration:10000,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });

        this.dialogRef.close();

      });
  }

  onChangeContractAgreement(event)
{
  this.insuranceDocumentFormGroup.controls.insuranceDocument.setValue(event.target.files[0]);
  console.log(event.target.files[0]);
  this.formData.append("insuranceDocument",event.target.files[0]);
}

}
