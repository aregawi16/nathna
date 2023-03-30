import { DropDownObject } from 'src/app/core/models/dropDownObject';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';
import { SettingService } from 'src/app/features/setting/setting.service';
import { ApplicantProfileService } from './../../../services/applicant-profile.service';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { MatOption } from '@angular/material/core';
@Component({
  selector: 'app-complete-preflight-training-dialog',
  templateUrl: './complete-preflight-training-dialog.component.html',
  styleUrls: ['./complete-preflight-training-dialog.component.scss']
})
export class CompletePreflightTrainingDialogComponent  implements OnInit{
  @ViewChild('allSelected') private allSelected: MatOption;
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  trainees:DropDownObject[];
  preflightTrainingFormGroup:FormGroup;

  constructor(
    private _formBuilder:FormBuilder,
    public _dialogRef: MatDialogRef<any>,
    private _snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public _applicantService: ApplicantProfileService,
    public _settingService: SettingService,
    public _processManagementService: ProcessManagementService,
  )
  {

  }
  ngOnInit(): void {

 this.getApplicantsForTraining();
    this.preflightTrainingFormGroup = this._formBuilder.group({
      applicantIds: ['',[Validators.required]],
      preFlightTrainingId: [''],
      scheduledDate: ['',[Validators.required]],
      place: ['',[Validators.required]],
      description: [''],
  });
  let applicantIds : any[] = [];
   this.data.preFlightTrainingPeople.forEach(element => {
    applicantIds.push(element.applicantProfileId);
  }); ;
  if(this.data){
    this.preflightTrainingFormGroup.patchValue(this.data);
    this.preflightTrainingFormGroup.controls.applicantIds.patchValue(applicantIds);
  };

  }

  getApplicantsForTraining()
  {
    this._applicantService.getApplicantsForTraining()
    .subscribe(data => {
      this.trainees = data;
    });

  }

  tosslePerOne(all){
    if (this.allSelected.selected) {
     this.allSelected.deselect();
     return false;
 }

   if(this.preflightTrainingFormGroup.controls.applicantIds.value.length==this.trainees.length)
     this.allSelected.select();

     return true;

}
toggleAllSelection() {
  if (this.allSelected.selected) {
    this.preflightTrainingFormGroup.controls.applicantIds
      .setValue([...this.trainees.map(item => item.id), 0]);
  } else {
    this.preflightTrainingFormGroup.controls.applicantIds.patchValue([]);
  }
}

submitPreflightTraining()
{
  console.log(this.preflightTrainingFormGroup.value);
  this._processManagementService.completeSchedulePreflightTraining(this.preflightTrainingFormGroup.value)
  .subscribe(data => {

    this._snackBar.open('Training Schedule Approved successfully successfully', 'Undo', {
      duration:10000,
      horizontalPosition: this.horizontalPosition,
      verticalPosition: this.verticalPosition,
    });

    this._dialogRef.close();

  });
}
}
