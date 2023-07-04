import { DropDownObject } from './../../../core/models/dropDownObject';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { HttpApi } from 'src/app/core/interceptor/http-api';
import { Country } from 'src/app/core/constants/country';
import { Observable } from 'rxjs';

const PARAMS = new HttpParams();

@Injectable({
  providedIn: 'root'
})
export class ApplicantProfileService {

constructor(
private _http:HttpClient
) { }

 getCommonJobs()
{
  return this._http.get<DropDownObject[]>(HttpApi.getJobs)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
getApplicantsForTraining()
{
  return this._http.get<DropDownObject[]>(HttpApi.getApplicantsForTraining)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
getPreFlightTrainingSchedules()
{
  return this._http.get<any[]>(HttpApi.getPreFlightTrainingSchedules)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}

createApplicantProfile(data): Observable<any>
{
  return this._http.post(HttpApi.createApplicantProfile,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
updateApplicantProfile(data)
{
  return this._http.put(HttpApi.createApplicantProfile+"/"+data.applicantProfileId,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
uplodApplicantDocument(data)
{
  return this._http.post(HttpApi.createApplicantProfile+"/upload",data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}
placeApplicant(data)
{return this._http.post(HttpApi.placeApplicant,data)
  .pipe(
    map((response: any) => {
      return response;
    })
  );

}
public getApplicantRofiles(pageNo:any,pageSize:any, candidateType:any): Observable<any>
{
  let page = {
  "pageNumber": pageNo,'pageSize':pageSize
}
  return this._http.post(HttpApi.listApplicantProfile+'?id='+candidateType,page)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}

public getApplicantRofileById(id:any)
{
  return this._http.get(HttpApi.createApplicantProfile+'/'+id)
  .pipe(
    map((response: any) => {
      return response;
    })
  );
}

deleteApplicantRofile(id:any)
{
  return this._http.delete(HttpApi.createApplicantProfile+'/'+id)
  .pipe(
    map(() => {
return "Deleted";
    })
  );
}
rejectApplicantRofile(id:any)
{
  return this._http.delete(HttpApi.createApplicantProfile+'/reject/'+id)
  .pipe(
    map(() => {
return "Deleted";
    })
  );
}
public getCountries(){
  return Country;
}
}
