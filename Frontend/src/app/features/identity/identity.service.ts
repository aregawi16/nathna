import { map } from 'rxjs/operators';
import { User } from './pages/user/user.component';
import { HttpApi } from 'src/app/core/interceptor/http-api';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Role } from './pages/role/role.component';
import { DropDownObject } from 'src/app/core/models/dropDownObject';

@Injectable({
  providedIn: 'root'
})
export class IdentityService {
constructor(
  private _http:HttpClient
){

}

  public getUserList()
  {
    return this._http.get<User[]>(HttpApi.userList)
    .pipe(
      map((response: User[]) => {
        return response;
      })
    );
  }

  public createUser(data:any)
  {
    return this._http.post(HttpApi.userRegister, data)
    .pipe(
      map((response) => {
        return response;
      })
    );
  }
  public deleteUser(id:any)
  {
    return this._http.delete(HttpApi.userDelete+id)
    .pipe(
      map((response) => {
        return response;
      })
    );
  }
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
