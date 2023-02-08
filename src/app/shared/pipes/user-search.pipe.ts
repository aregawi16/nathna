import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'UserSearchPipe', pure: false })
export class UserSearchPipe implements PipeTransform {
  transform(value, args?): Array<any> {
    let searchText = new RegExp(args, 'ig');
    if (value) {
      return value.filter(user => {
        if (user.fullName) {
          console.log((user.applicantPlacement));
          console.log(String(searchText).indexOf("0"));
          if(String(searchText).indexOf("0")==1)
          {
             return user.applicantPlacement==null;
          }
          return              user.fullName.search(searchText) !== -1 ||String(user.applicantPlacement?.status).search(searchText) !== -1 ;
        }
        else{
          return user.fullNameAm.search(searchText) !== -1;
        }

      });
    }
    else
    {
      return [];
    }
  }
}
