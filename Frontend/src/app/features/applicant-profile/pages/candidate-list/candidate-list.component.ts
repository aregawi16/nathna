import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ApplicantProfileService } from '../../services/applicant-profile.service';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { AuthService } from 'src/app/features/auth/services/auth.service';
import { Status } from '../../model/Status.enum';
import { SettingService } from 'src/app/features/setting/setting.service';
import { DropDownObject } from 'src/app/core/models/dropDownObject';

@Component({
  selector: 'app-candidate-list',
  templateUrl: './candidate-list.component.html',
  styleUrls: ['./candidate-list.component.scss'],
  encapsulation: ViewEncapsulation.None

})
export class CandidateListComponent implements OnInit {

  selectedTab:any=1;
  pageSize = 8;
  pageNumber = 1;
  officeId:any=0;
  isHeadOffice:boolean=true;
  statuses!:number[];
  public searchText!: string;
  public startDate!: string;
    public endDate!: string;
  statusList=Status;
  totalItems = 0;
  offices!:DropDownObject[];

  isLinear = false;

  applicantProfiles:any[]=[];
  constructor(
           public _applicantService: ApplicantProfileService,
           private _authService: AuthService,
           public _settingService: SettingService,

           )
            {
            }

  onChangeTab(event: MatTabChangeEvent) {
    this.pageNumber = 1;
    const tab = event.tab.textLabel;
    console.log(tab);
    this.selectedTab = tab;
    this.getApplicantProfiles(0,this.selectedTab,this.officeId);

    if(tab===" Tab 1")
     {
       console.log("function want to implement");
      }
  }
  public onPageChanged(event){
    this.pageNumber = event;
    this.getApplicantProfiles(this.pageNumber,this.selectedTab,this.officeId);
    window.scrollTo(0,0);
    // if(this.settings.fixedHeader){
    //     document.getElementById('main-content').scrollTop = 0;
    // }
    // else{
    //     document.getElementsByClassName('mat-drawer-content')[0].scrollTop = 0;
    // }
}
 ngOnInit(): void {
  if(this._authService.isHeadOffice())
  {
    this.selectedTab =1
  }
  else
  {
    this.selectedTab =2

  }
  this.getApplicantProfiles(0,this.selectedTab,this.officeId);
  this.isHeadOffice = this._authService.isHeadOffice();

  this.statuses= Object.keys(this.statusList).map(key => parseInt(key)).filter(f => !isNaN(Number(f)));
this.getOffices();
 }
 public getOffices()
 {

   this._settingService.getOfficeList()
     .subscribe(data => {
      this.offices = data;
    });
 }
 onChangeUser(search:any){
  this.getApplicantProfiles(this.pageNumber,this.selectedTab,this.officeId,search);

 }
 onChangeOffice(officeId:any)
 {
  this.officeId = officeId;
this.getApplicantProfiles(this.pageNumber,this.selectedTab, officeId);
 }

 public async getApplicantProfiles(pageNo:any,selectedTab, officeId:any,search:any=null): Promise<void> {
  await this._applicantService.getApplicantRofiles(pageNo,this.pageSize,selectedTab,officeId,search)
  .subscribe(data => {
    this.totalItems =data?.totalItems;
      this.applicantProfiles = data?.content;


    console.log(data);
  });


}


}
