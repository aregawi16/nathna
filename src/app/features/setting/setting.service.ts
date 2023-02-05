import { Role } from './../identity/pages/role/role.component';
import { Office } from './pages/office/office.component';
import { Agent } from './pages/agent/agent.component';
import { DropDownObject } from './../../core/models/dropDownObject';
import { map } from 'rxjs/operators';
import { HttpApi } from 'src/app/core/interceptor/http-api';
import { CommonJob } from './pages/job/job.component';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Country } from './pages/country/country.component';

@Injectable({
  providedIn: 'root'
})
export class SettingService {

  constructor(
    private _http:HttpClient
  ) { }

  //Common Job API
  public getCommonJobList()
  {
    return this._http.get<CommonJob[]>(HttpApi.getJobList)
    .pipe(
      map((response: CommonJob[]) => {
        console.log(response);
        return response;
      })
    );
  }

  public createCommonJob(data:CommonJob)
  {
    return this._http.post<CommonJob>(HttpApi.getJobList,data)
    .pipe(
      map((response: CommonJob) => {
        console.log(response);
        return response;
      })
    );
  }

  public deleteCommonJob(id:any)
  {
    return this._http.delete<CommonJob>(HttpApi.getJobList+'/'+id)
    .pipe(
      map((response: CommonJob) => {

      })
    );
  }

  //Country Api
  public getCountryList()
  {
    return this._http.get<DropDownObject[]>(HttpApi.getCountryList)
    .pipe(
      map((response: DropDownObject[]) => {
        return response;
      })
    );
  }
  public getCountrys()
  {
    return this._http.get<Country[]>(HttpApi.country)
    .pipe(
      map((response: Country[]) => {
        return response;
      })
    );
  }

  public createCountry(data:Country)
  {
    return this._http.post<Country>(HttpApi.country,data)
    .pipe(
      map((response: Country) => {
        console.log(response);
        return response;
      })
    );
  }

  public deleteCountry(id:any)
  {
    return this._http.delete<Country>(HttpApi.country+'/'+id)
    .pipe(
      map((response: Country) => {

      })
    );
  }


  public getAgentList()
  {
    return this._http.get<DropDownObject[]>(HttpApi.getAgentList)
    .pipe(
      map((response: DropDownObject[]) => {
        return response;
      })
    );
  }
  public getAgents()
  {
    return this._http.get<Agent[]>(HttpApi.agent)
    .pipe(
      map((response: Agent[]) => {
        return response;
      })
    );
  }

  public createAgent(data:Agent)
  {
    return this._http.post<Agent>(HttpApi.agent,data)
    .pipe(
      map((response: Agent) => {
        console.log(response);
        return response;
      })
    );
  }

  public deleteAgent(id:any)
  {
    return this._http.delete<Agent>(HttpApi.agent+'/'+id)
    .pipe(
      map((response: Agent) => {

      })
    );
  }



// Office API

  public getOfficeList()
  {
    return this._http.get<DropDownObject[]>(HttpApi.getOfficeList)
    .pipe(
      map((response: DropDownObject[]) => {
        return response;
      })
    );
  }
  public getOffices()
  {
    return this._http.get<Office[]>(HttpApi.office)
    .pipe(
      map((response: Office[]) => {
        return response;
      })
    );
  }
  public createOffice(data:Office)
  {
    return this._http.post<Office>(HttpApi.office,data)
    .pipe(
      map((response: Office) => {
        console.log(response);
        return response;
      })
    );
  }
  public deleteOffice(id:any)
  {
    return this._http.delete<Office>(HttpApi.office+'/'+id)
    .pipe(
      map((response: Office) => {

      })
    );
  }


// Role API

public getRoleList()
{
  return this._http.get<DropDownObject[]>(HttpApi.userRole)
  .pipe(
    map((response: DropDownObject[]) => {
      return response;
    })
  );
}
public getRoles()
{
  return this._http.get<Role[]>(HttpApi.getUserRole)
  .pipe(
    map((response: Role[]) => {
      return response;
    })
  );
}
public createRole(data:Role)
{
  return this._http.post<Role>(HttpApi.userRole,data)
  .pipe(
    map((response: Role) => {
      console.log(response);
      return response;
    })
  );
}
public deleteRole(id:any)
{
  return this._http.delete<Role>(HttpApi.userRole+'/'+id)
  .pipe(
    map((response: Role) => {

    })
  );
}

}
