 export  class ApplicantProfile {
  id: number;
  applicantProfileId: number;
  applicantProfilename: string;
  password: string;
  fullName: string;
  applicantDocument: ApplicantDocument;
  applicantPlacement:ApplicantPlaceMent

}

export class ApplicantPlaceMent{
  staus: number;
officeId:number}
export class ApplicantDocument{
  applicantIdFilePath: string;
  applicantPassportFilePath: string;
}
export class ApplicantProfileProfile {
  name: string;
  surname: string;
  birthday: Object;
  gender: string;
  image: string;
}

export class ApplicantProfileWork {
  company: string;
  position: string;
  salary: number;
}

export class ApplicantProfileContacts{
  email: string;
  phone: string;
  address: string;
}

export class ApplicantProfileSocial {
  facebook: string;
  twitter: string;
  google: string;
}

export class ApplicantProfileSettings{
  isActive: boolean;
  isDeleted: boolean;
  registrationDate: string;
  joinedDate: string;
}
