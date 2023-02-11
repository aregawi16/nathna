import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'custom-date'
})
export class CustomDatePipe implements PipeTransform {

  transform(value: any, args?: any): any {
     return 'shortDate';
  }

}
