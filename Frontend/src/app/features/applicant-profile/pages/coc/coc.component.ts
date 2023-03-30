import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-coc',
  templateUrl: './coc.component.html',
  styleUrls: ['./coc.component.scss']
})
export class CocComponent implements OnInit{

  cocFormGroup:FormGroup;
  formData = new FormData();
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
constructor(
  private _formBuilder:FormBuilder,
  @Inject(MAT_DIALOG_DATA) public id: any,
  private _processManagementService: ProcessManagementService,
  private _httpClient: HttpClient,
   private _dialog : MatDialog,
   private _dialogRef : MatDialogRef<CocComponent>,
  private _snackBar : MatSnackBar

){

}

  ngOnInit(): void {
    this.cocFormGroup = this._formBuilder.group({
      applicantId: ['',[Validators.required]],
      trainedPlaceName: ['',[Validators.required]],
      trainedPlaceAddress: ['',[Validators.required]],
      trainedSkill: ['',[Validators.required]],
      certificateTakenPlaceName: ['',[Validators.required]],
      certificateTakenAddress: ['',[Validators.required]],
      description: [''],
      certificateFile: [''],
    });
  }

    onChangeCoC(event)
    {

        this.formData.append("certificateFile",event.target.files[0]);
      }

      submitCoC()
      {
        this.formData.append("applicantId",this.id);
        this.formData.append("trainedPlaceName",this.cocFormGroup.controls.trainedPlaceName.value);
        this.formData.append("trainedPlaceAddress",this.cocFormGroup.controls.trainedPlaceAddress.value);
        this.formData.append("trainedSkill",this.cocFormGroup.controls.trainedSkill.value);
        this.formData.append("certificateTakenPlaceName",this.cocFormGroup.controls.certificateTakenPlaceName.value);
        this.formData.append("certificateTakenAddress",this.cocFormGroup.controls.certificateTakenAddress.value);
        this.formData.append("description",this.cocFormGroup.controls.description.value);
        console.log(this.cocFormGroup.value);
        this._processManagementService.completeCoC(this.formData)
        .subscribe(data => {

          this._snackBar.open('Coc Document added successfully', 'Undo', {
            duration:10000,
            horizontalPosition: this.horizontalPosition,
            verticalPosition: this.verticalPosition,
          });

          this._dialogRef.close();

        });
      }
    }

