import { provideQueryDevTools } from '@ngneat/query-devtools';
import { BrowserModule } from '@angular/platform-browser';
import { APP_ID, NgModule, isDevMode } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { TimeOrTimeLeftSectionComponent } from './components/time-or-time-left-section/time-or-time-left-section.component';
import { TeamRecordSectionComponent } from './components/team-record-section/team-record-section.component';
import { WatchButtonComponent } from './components/watch-button/watch-button.component';
import { DatePipe, NgOptimizedImage } from '@angular/common';
import { GameCardComponent } from './components/game-card/game-card.component';
import { BasketballConferencesDropdownComponent } from './components/basketball-conferences-dropdown/basketball-conferences-dropdown.component';
import { DateDropdownComponent } from './components/date-dropdown/date-dropdown.component';
import { provideQueryClientOptions } from '@ngneat/query';
import { OrderByPipe } from "./pipes/order-by.pipe";
import { ServiceWorkerModule } from '@angular/service-worker';
import { GameDetailComponent } from './components/game-details/game-details.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'game/:id', component: GameDetailComponent },
];

@NgModule({
    declarations: [
        AppComponent,
    ],
    providers: [
        { provide: APP_ID, useValue: 'ng-cli-universal' },
        isDevMode() ? provideQueryDevTools({
            initialIsOpen: true
        }) : [],
        provideQueryClientOptions({
            defaultOptions: {
                queries: {
                    staleTime: Infinity,
                    refetchOnWindowFocus: true,
                    refetchOnReconnect: true,
                    refetchOnMount: true,
                    retryDelay: (attemptIndex) => Math.min(1000 * 2 ** attemptIndex, 10000),
                },
            },
        }),
        DatePipe,
    ],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot(routes),
        TeamRecordSectionComponent,
        WatchButtonComponent,
        NgOptimizedImage,
        OrderByPipe,
        GameDetailComponent,
        GameCardComponent,
        BasketballConferencesDropdownComponent,
        DateDropdownComponent,
        TimeOrTimeLeftSectionComponent,
        ServiceWorkerModule.register('ngsw-worker.js', {
          enabled: !isDevMode(),
          // Register the ServiceWorker as soon as the application is stable
          // or after 30 seconds (whichever comes first).
          registrationStrategy: 'registerWhenStable:30000'
        })
    ]
})
export class AppModule { }

