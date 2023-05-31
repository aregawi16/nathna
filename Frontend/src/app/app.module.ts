import { environment } from 'src/environments/environment';
import { AppSettings } from 'src/app/app.settings';
import { Oauth2Interceptor } from './core/interceptor/oauth2.interceptor';
import { AppInterceptor } from './core/interceptor/http.interceptor';
import { SharedModule } from './shared/shared.module';
import { NgModule,NO_ERRORS_SCHEMA } from '@angular/core';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserModule } from '@angular/platform-browser';

import { OverlayContainer, Overlay } from '@angular/cdk/overlay';
import { MAT_MENU_SCROLL_STRATEGY } from '@angular/material/menu';
import { CustomOverlayContainer } from './core/utils/custom-overlay-container';
import { menuScrollStrategy } from './core/utils/scroll-strategy';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
export function HttpLoaderFactory(httpClient: HttpClient) {
  return new TranslateHttpLoader(httpClient, environment.url +'/assets/i18n/', '.json');
}

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { NgxPrintModule } from 'ngx-print';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
      ],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    NgxSpinnerModule,
    NgxPrintModule,
    BrowserAnimationsModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
  ],
  providers: [
    AppSettings,
    {provide: LocationStrategy, useClass: HashLocationStrategy},
    { provide: OverlayContainer, useClass: CustomOverlayContainer },
    { provide: MAT_MENU_SCROLL_STRATEGY, useFactory: menuScrollStrategy, deps: [Overlay] },
      { provide: HTTP_INTERCEPTORS, useClass: AppInterceptor, multi: true },
      { provide: HTTP_INTERCEPTORS, useClass: Oauth2Interceptor, multi: true }
      ],
      schemas: [
        NO_ERRORS_SCHEMA
      ],
        bootstrap: [AppComponent]
})
export class AppModule { }
