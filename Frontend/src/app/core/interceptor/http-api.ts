import { environment } from "src/environments/environment";

export class HttpApi {
  // OAuth
  static oauthLogin = 'Auth/SignIn';
  static userRegister = 'Auth/SignUp';
  static userList = 'Auth/List';
  static userRole = 'Auth/Roles';
  static getUserRole = 'Auth/GetRoles';

// Get Applicant Profile
static getApplicantProfiles = 'ApplicantProfile';
static createApplicantProfile = 'ApplicantProfile';
static getApplicantProfileList = 'ApplicantProfile';
static placeApplicant = 'ProcessManagement/placement';
static getApplicantsForTraining = 'ApplicantProfile/getApplicantsForTraining';


// Get Jobs
static getJobs = 'CommonJob/list';
static createJob = 'CommonJob';
static getJobList = 'CommonJob';
// Get Jobs
static getCountryList = 'Country/list';
static country = 'Country';

static agent = 'Agent';
static getAgentList = 'Agent/list';

//office API
static office = "office";
static getOfficeList = 'Office/list';

//Process Management

static selectApplicant = "ProcessManagement/selectApplicant";
static rejectApplicant = 'ProcessManagement/rejectApplicant';
static uploadVerifiedDocumentApplicant = 'ProcessManagement/uploadVerifiedDocument';
static uploadContractDocumentApplicant = 'ProcessManagement/uploadContractDocument';
static receiveContractAgreement = 'ProcessManagement/receiveContractAgreement';
static verifyContractAgreement = 'ProcessManagement/verifyContractAgreement';
static requestInsurance = 'ProcessManagement/requestInsurance';
static completeInsurance = 'ProcessManagement/completeInsurance';
static requestCoc = 'ProcessManagement/requestCoc';
static completeCoC = 'ProcessManagement/completeCoC';
static schedulePreflightTraining = 'SchedulePreflightTraining/schedulePreflightTraining';
static getPreFlightTrainingSchedules = 'SchedulePreflightTraining/getPreflightTrainingScheduless';
static completeSchedulePreflightTraining = 'SchedulePreflightTraining/completeSchedulePreflightTraining';


static requestYellowRecord = 'ProcessManagement/requestYellowRecord';
static receivetYellowRecord = 'ProcessManagement/receiveYellowRecord';
static verifyFlightTcket = 'ProcessManagement/verifyFlightTcket';
static followFlight = 'ProcessManagement/followFlight';
}
