import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, Inject } from '@angular/core';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';

@Component({
  selector: 'app-applicant-contract-agreement',
  templateUrl: './applicant-contract-agreement.component.html',
  styleUrls: ['./applicant-contract-agreement.component.scss']
})
export class ApplicantContractAgreementComponent {
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  contractAgreementDocumentFormGroup: FormGroup;
  formData = new FormData();
  constructor(
    public dialogRef: MatDialogRef<ApplicantContractAgreementComponent>,
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
    this.contractAgreementDocumentFormGroup = this._formBuilder.group({
      applicantId: [''],
      contractDocument: [''],
    });

  }

  uploadDocument()
  {
    this.formData.append("applicantId",this.id);

    // Object.entries(this.documentFormGroup.value).forEach(([key, value]) => {
    //   this.formData.append(key,JSON.stringify(value));
    // });
    console.log(this.formData);
      console.log(this.contractAgreementDocumentFormGroup.value);
      this._processManagementService.uplodContractApplicantDocument(this.formData)
      .subscribe(data => {

        this._snackBar.open('Contract Agreement Document uploaded successfully', 'Undo', {
          duration:10000,
          horizontalPosition: this.horizontalPosition, 
          verticalPosition: this.verticalPosition,
        });

        this.dialogRef.close();

      });
  }

  onChangeContractAgreement(event)
{
  this.contractAgreementDocumentFormGroup.controls.contractDocument.setValue(event.target.files[0]);
  console.log(event.target.files[0]);
  this.formData.append("contractDocument",event.target.files[0]);
}

}
