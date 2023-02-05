import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { ProcessManagementService } from '../../../process-management/service/process-management.service';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Component, CUSTOM_ELEMENTS_SCHEMA, Inject } from '@angular/core';

@Component({
  selector: 'app-applicant-required-verified-document',
  templateUrl: './applicant-required-verified-document.component.html',
  styleUrls: ['./applicant-required-verified-document.component.scss'],

})
export class ApplicantRequiredVerifiedDocumentComponent {

  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  verifiedDocumentFormGroup: FormGroup;
  formData = new FormData();
  constructor(
    public dialogRef: MatDialogRef<ApplicantRequiredVerifiedDocumentComponent>,
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
    this.verifiedDocumentFormGroup = this._formBuilder.group({
      applicantId: [''],
      medicalDocument: [''],
      crimeFreeDocument: ['']
    });

  }

  uploadDocument()
  {
    this.formData.append("applicantId",this.id);

    // Object.entries(this.documentFormGroup.value).forEach(([key, value]) => {
    //   this.formData.append(key,JSON.stringify(value));
    // });
    console.log(this.formData);
      console.log(this.verifiedDocumentFormGroup.value);
      this._processManagementService.uplodVerifiedApplicantDocument(this.formData)
      .subscribe(data => {


            this._snackBar.open('Verified Document uploaded successfully', 'Undo', {
              duration:10000,
              horizontalPosition: this.horizontalPosition,
              verticalPosition: this.verticalPosition,
            });
            this.dialogRef.close();



      });
  }

  onChangeMedical(event)
{
  this.verifiedDocumentFormGroup.controls.medicalDocument.setValue(event.target.files[0]);
  console.log(event.target.files[0]);
  this.formData.append("medicalDocument",event.target.files[0]);
}
onChangeCrime(event)
{
  this.verifiedDocumentFormGroup.controls.crimeFreeDocument.setValue(event.target.files[0]);
  this.formData.append("crimeFreeDocument",event.target.files[0]);

}

}
