import { CompletePreflightTrainingDialogComponent } from './complete-preflight-training-dialog/complete-preflight-training-dialog.component';
import { ApplicantPreFlightTrainingStatus } from './../../model/Status.enum';
import { ConfirmDialogComponent } from './../../../../shared/components/confirm-dialog/confirm-dialog.component';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';
import { SettingService } from 'src/app/features/setting/setting.service';
import { ApplicantProfileService } from './../../services/applicant-profile.service';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { PreflightTrainingDialogComponent } from './preflight-training-dialog/preflight-training-dialog.component';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { Component, ViewChild, OnInit } from '@angular/core';

@Component({
  selector: 'app-pre-flight-training',
  templateUrl: './pre-flight-training.component.html',
  styleUrls: ['./pre-flight-training.component.scss']
})
export class PreFlightTrainingComponent implements OnInit {

  displayedColumns: string[] = ['preFlightTrainingId', 'scheduledDate', 'place', 'description','action'];
  dataSource = new MatTableDataSource<any>();
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  applicanPreflightTrainingStatusList=ApplicantPreFlightTrainingStatus;

  @ViewChild(MatTable) table: MatTable<any>;
  constructor(
    public dialog: MatDialog,
    public _dialogRef: MatDialogRef<any>,
    private _snackBar: MatSnackBar,
    public _applicantService: ApplicantProfileService,
    public _settingService: SettingService,
    public _processManagementService: ProcessManagementService,
  )
  {

  }

  ngOnInit(): void {

this.getPreflightTrainings();

  }
  getPreflightTrainings()
  {
    this._applicantService.getPreFlightTrainingSchedules()
    .subscribe(data => {
      console.log(data);
      this.dataSource = new MatTableDataSource(data);
    });
  }

  addData() {
    const dialogRef = this.dialog.open(PreflightTrainingDialogComponent, {
      maxWidth: "400"
        });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if(dialogResult){

      }
    });


  }

  removeData() {

  }
  edit(data:any)
  {

    const dialogRef = this.dialog.open(PreflightTrainingDialogComponent, {
      maxWidth: "400",
      data:data
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if(dialogResult){

      }
    });

  }
  completeTraining(data:any)
  {

    const dialogRef = this.dialog.open(CompletePreflightTrainingDialogComponent, {
      maxWidth: "400",
      data:data
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      if(dialogResult){

      }
    });
  }
  remove(data:any)
  {

  }
}
