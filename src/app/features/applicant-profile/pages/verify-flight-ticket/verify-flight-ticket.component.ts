import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';
import { Component, Inject } from '@angular/core';
import { ProcessManagementService } from 'src/app/features/process-management/service/process-management.service';

@Component({
  selector: 'app-verify-flight-ticket',
  templateUrl: './verify-flight-ticket.component.html',
  styleUrls: ['./verify-flight-ticket.component.scss']
})
export class VerifyFlightTicketComponent {
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';
  verticalPosition: MatSnackBarVerticalPosition = 'bottom';
  flightTicketDocumentFormGroup: FormGroup;
  formData = new FormData();
  constructor(
    public dialogRef: MatDialogRef<VerifyFlightTicketComponent>,
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
    this.flightTicketDocumentFormGroup = this._formBuilder.group({
      applicantId: [''],
      price: [''],
      departureDate: ['',[Validators.required]],
      arrivalDate: ['',[Validators.required]],
      FlightTicketDocument: [''],
    });

  }

  uploadDocument()
  {
    this.formData.append("applicantId",this.id);
    this.formData.append("price",this.flightTicketDocumentFormGroup.controls.price.value);
    this.formData.append("arrivalDate",this.flightTicketDocumentFormGroup.controls.arrivalDate.value);
    this.formData.append("departureDate",this.flightTicketDocumentFormGroup.controls.departureDate.value);

    console.log(this.formData);
      console.log(this.flightTicketDocumentFormGroup.value);
      this._processManagementService.verifyFlightTcket(this.formData)
      .subscribe(data => {

        this._snackBar.open('Flght Ticket Uploaded  successfully', 'Undo', {
          duration:10000,
          horizontalPosition: this.horizontalPosition,
          verticalPosition: this.verticalPosition,
        });

        this.dialogRef.close();

      });
  }

  onChangeFlightTicket(event)
{
  console.log(event.target.files[0]);
  this.formData.append("flightTicketDocument",event.target.files[0]);
}

}
