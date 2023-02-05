import { FilterByIdPipe } from './filter-by-id.pipe';
import { UserSearchPipe } from './user-search.pipe';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfilePicturePipe } from './profilePicture.pipe';
import { CustomDatePipe } from './custom-date.pipe';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [	
    ProfilePicturePipe,
    FilterByIdPipe,
    UserSearchPipe,
      CustomDatePipe
   ],
  exports: [
    ProfilePicturePipe,
    FilterByIdPipe,
    UserSearchPipe
  ]
})
export class PipesModule { }
