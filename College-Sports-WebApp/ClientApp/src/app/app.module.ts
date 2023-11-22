import { BrowserModule } from '@angular/platform-browser';
import { APP_ID, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { ApiModule } from '../api/api.module';
import { TimeOrTimeLeftSectionComponent } from './components/time-or-time-left-section/time-or-time-left-section.component';
import { TeamRecordSectionComponent } from './components/team-record-section/team-record-section.component';
import { WatchButtonComponent } from './components/watch-button/watch-button.component';

const routes: Routes = [

];

@NgModule({
  declarations: [
    AppComponent,
    TimeOrTimeLeftSectionComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    ApiModule.forRoot({ rootUrl: '' }),
    TeamRecordSectionComponent,
    WatchButtonComponent
  ],
  providers: [
    { provide: APP_ID, useValue: 'ng-cli-universal' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
