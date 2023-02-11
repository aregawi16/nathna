import { map } from 'rxjs/operators';
import { HttpApi } from 'src/app/core/interceptor/http-api';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProcessManagementService {

  constructor(
    private _http:HttpClient
  ) { }

  selectApplicant(data)
{
  return this._http.post(HttpApi.selectApplicant,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
updateContractStatus(data)
{
  return this._http.post(HttpApi.receiveContractAgreement,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}


rejectApplicant(data)
{
  return this._http.post(HttpApi.selectApplicant,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
uplodVerifiedApplicantDocument(data)
{
  return this._http.post(HttpApi.uploadVerifiedDocumentApplicant,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
completeInsurance(data)
{
  return this._http.post(HttpApi.completeInsurance,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
uplodContractApplicantDocument(data)
{
  return this._http.post(HttpApi.uploadContractDocumentApplicant,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
verifyContractApplicantDocument(data)
{
  return this._http.post(HttpApi.verifyContractAgreement,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
requestInsurance(data)
{
  return this._http.post(HttpApi.requestInsurance,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
requestYellowRecord(data)
{
  return this._http.post(HttpApi.requestYellowRecord,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
receieveYellowRecord(data)
{
  return this._http.post(HttpApi.receivetYellowRecord,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
verifyFlightTcket(data)
{
  return this._http.post(HttpApi.verifyFlightTcket,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
followFlight(data)
{
  return this._http.post(HttpApi.followFlight,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
}
