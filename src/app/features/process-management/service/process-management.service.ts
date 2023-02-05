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
uplodContractApplicantDocument(data)
{
  return this._http.post(HttpApi.uploadContractDocumentApplicant,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
}
