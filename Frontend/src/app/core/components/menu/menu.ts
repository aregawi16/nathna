import { Menu } from './menu.model';

export const menuItems = [
    new Menu (10, 'ADMIN_NAV.DASHBOARD', '/', null, 'bi bi-house-heart-fill', null, false, 0),
     new Menu (20, 'ADMIN_NAV.APPLICANT_PROFILE', "auth/login", null, 'bi bi-person-add', null, true, 0,false),
     new Menu (30, 'ADMIN_NAV.CREATE_APPLICANT_PROFILE', "applicant-profile/create-new", null, 'bi bi-person-add', null, false, 20),
     new Menu (40, 'ADMIN_NAV.LIST_APPLICANT_PROFILE', "applicant-profile/list", null, 'bi bi-person-lines-fill', null, false, 20,false),
    //  new Menu (140, 'ADMIN_NAV.PRE_FLIGHT_TRAINING', "applicant-profile/preflight-training", null, 'list', null, false, 20),
     new Menu (50, 'ADMIN_NAV.APPLICANT_PROFILE_PROCESS', "applicant-profile/process/:id", null, 'bi bi-graph-up-arrow', null, false, 20),
    //  new Menu (51, 'ADMIN_NAV.LETTER', "applicant-profile/process/:id", null, 'report', null, true, 0),
    //  new Menu (52, 'ADMIN_NAV.FINGERPRINT_LETTER', "letter/finger-print", null, 'report', null, false, 51),
    //  new Menu (53, 'ADMIN_NAV.CONTRACT_LETTER', "letter/contract", null, 'report', null, false, 51),
    //  new Menu (54, 'ADMIN_NAV.COC_LETTER', "letter/coc", null, 'report', null, false, 51),
    //  new Menu (55, 'ADMIN_NAV.PRE_FLIGHT_TRAINING_LETTER', "letter/preflight", null, 'report', null, false, 51),
    //  new Menu (56, 'ADMIN_NAV.VISA_CONFIRMATION_LETTER', "letter/visa", null, 'report', null, false, 51),
    //  new Menu (57, 'ADMIN_NAV.RECEIPT_REQUEST_LETTER', "letter/labour-bank", null, 'report', null, false, 51),
    //  new Menu (58, 'ADMIN_NAV.MINISTRY_SKILL_APLICANT_DETAIL', "letter/mof-labour-document", null, 'report', null, false, 51),
    //  new Menu (59, 'ADMIN_NAV.LABOUR_APPROVAL_LETTER', "letter/labour-approval", null, 'report', null, false, 51),
     new Menu (599, 'ADMIN_NAV.USER', "", null, 'bi bi-person-circle', null, true, 0),
     new Menu (510, 'ADMIN_NAV.USER', "/identity/user", null, 'bi bi-person-fill-lock', null, false, 599),
     new Menu (520, 'ADMIN_NAV.ROLE', "/identity/role", null, 'bi bi-person-check', null, false, 599),
    new Menu (70, 'ADMIN_NAV.SETTING', '', null, 'bi bi-gear-fill', null, true, 0),
    new Menu (710, 'ADMIN_NAV.OFFICE', '/setting/office', null, 'bi bi-buildings-fill', null, false, 70),
    new Menu (720, 'ADMIN_NAV.COUNTRY', '/setting/country', null, 'bi bi-geo-alt-fill', null, false, 70),
    new Menu (730, 'ADMIN_NAV.AGENT', '/setting/agent', null, 'bi bi-person', null, false, 70),
    new Menu (740, 'ADMIN_NAV.JOB', '/setting/job', null, 'bi bi-person-workspace', null, false, 70),
    new Menu (740, 'ADMIN_NAV.COMPANY_PROFILE', '/setting/company-profile', null, 'bi bi-person-circle', null, false, 70),

]
