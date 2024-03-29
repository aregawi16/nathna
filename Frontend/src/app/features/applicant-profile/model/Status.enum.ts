export enum Status
{
  UnAssigned,
  Placement = 1,
  ContractAgreement,
  Insurance,
  CoC,
  PreFlightTraining,
  MinistryOfLabor,
  Ticket
}

export enum ApplicantPlacementStatus
{
  Assigned = 1,
  Selected,
  DocumentVerified,
  Accepted,
  Rejected,

}
export enum ApplicantContractStatus
{
    Ready = 1,
    Received,
    Verified,
    Rejected,

}
export enum ApplicantInsuranceStatus
{
    Requested = 1,
    Completed,
    Rejected,

}
export enum ApplicantCocStatus
{
    Requested = 1,
    Completed,
    Rejected,

}
export enum ApplicantPreFlightTrainingStatus
{
    Requested = 1,
    Completed,
    Rejected,

}
export enum ApplicantLabourStatus
{
    Requested = 1,
    YellowCardReceived,
    Rejected,

}
export enum ApplicantTicketStatus
{
    Requested = 1,
    Verified,
    Flighted,
    Arrived
}

export enum CoCAndTrainingStatus
{
    Progress = 1,
    Taken
}
