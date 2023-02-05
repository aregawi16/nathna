"use strict";
exports.__esModule = true;
exports.HttpApi = void 0;
var HttpApi = /** @class */ (function () {
    function HttpApi() {
    }
    // OAuth
    HttpApi.oauthLogin = 'Auth/SignIn';
    HttpApi.userRegister = 'Auth/SignUp';
    HttpApi.userList = 'Auth/List';
    HttpApi.userRole = 'Auth/Roles';
    HttpApi.getUserRole = 'Auth/GetRoles';
    // Get Applicant Profile
    HttpApi.getApplicantProfiles = 'ApplicantProfile';
    HttpApi.createApplicantProfile = 'ApplicantProfile';
    HttpApi.getApplicantProfileList = 'ApplicantProfile';
    HttpApi.placeApplicant = 'ApplicantProfile/placement';
    // Get Jobs
    HttpApi.getJobs = 'CommonJob/list';
    HttpApi.createJob = 'CommonJob';
    HttpApi.getJobList = 'CommonJob';
    // Get Jobs
    HttpApi.getCountryList = 'Country/list';
    HttpApi.country = 'Country';
    HttpApi.agent = 'Agent';
    HttpApi.getAgentList = 'Agent/list';
    //office API
    HttpApi.office = "office";
    HttpApi.getOfficeList = 'Office/list';
    //Process Management
    HttpApi.selectApplicant = "ProcessManagement/selectApplicant";
    HttpApi.rejectApplicant = 'ProcessManagement/rejectApplicant';
    HttpApi.uploadVerifiedDocumentApplicant = 'ProcessManagement/uploadVerifiedDocument';
    return HttpApi;
}());
exports.HttpApi = HttpApi;
