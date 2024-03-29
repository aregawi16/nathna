// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  url: '',
  domain: 'https://localhost:7224/#/',
    backend: {
    host: 'https://localhost:7224/api/',
    base_url: 'https://localhost:7224\\',

  },
  reportingRestUrl:'https://localhost:7224/api/reports',

  oauth: {
    host: 'https://localhost:7224/api/',
    client_id: '2',
    client_secret: 'tsN80QNwTawD3WZSX2uziOFI6HstTEs2bXBqsCyv',
    scope: '*',
  },
  trReportViewerContainerStyle : {
    position: 'relative',
    width: '100%',
    height: '800px',
    ['font-family']: 'ms sans serif'
  }


};


/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
