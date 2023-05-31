import { map } from 'rxjs/operators';
import { User } from './pages/user/user.component';
import { HttpApi } from 'src/app/core/interceptor/http-api';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

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
    return this._http.delete(HttpApi.userRegister+'/'+id)
    .pipe(
      map((response) => {
        return response;
      })
    );
  }
}
