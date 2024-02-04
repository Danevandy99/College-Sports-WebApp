import { BrowserModule } from '@angular/platform-browser';
import { APP_ID, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { TimeOrTimeLeftSectionComponent } from './components/time-or-time-left-section/time-or-time-left-section.component';
import { TeamRecordSectionComponent } from './components/team-record-section/team-record-section.component';
import { WatchButtonComponent } from './components/watch-button/watch-button.component';
import { NgOptimizedImage } from '@angular/common';
import { GameCardComponent } from './components/game-card/game-card.component';
import { BasketballConferencesDropdownComponent } from './components/basketball-conferences-dropdown/basketball-conferences-dropdown.component';
import { DateDropdownComponent } from './components/date-dropdown/date-dropdown.component';

const routes: Routes = [

];

@NgModule({
  declarations: [
    AppComponent,
    TimeOrTimeLeftSectionComponent,
    GameCardComponent,
    BasketballConferencesDropdownComponent,
    DateDropdownComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes),
    TeamRecordSectionComponent,
    WatchButtonComponent,
    NgOptimizedImage,
  ],
  providers: [
    { provide: APP_ID, useValue: 'ng-cli-universal' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
