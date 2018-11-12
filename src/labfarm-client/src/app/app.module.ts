import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { LfNavbarComponent } from '../components/lf-navbar/lf-navbar.component';
import { HomeComponent } from '../pages/home/home.component';
import { FarmComponent } from '../pages/farm/farm.component';
import { OptionsComponent } from '../pages/options/options.component';
import { PageNotFoundComponent } from '../pages/page-not-found/page-not-found.component';
import { LabFarmOverviewComponent } from '../components/lab-farm-overview/lab-farm-overview.component';
import { SensorGraphComponent } from '../components/sensor-graph/sensor-graph.component';
import { UiSwitchModule } from 'ngx-toggle-switch';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatSliderModule } from '@angular/material';
import 'hammerjs';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { SensorDataService } from 'src/providers/sensor-data/sensor-data.service';
import { CookieService } from 'ngx-cookie-service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';
import { HttpClientModule } from '@angular/common/http';
import { ErrorComponent } from '../components/error/error.component';
import { LoadingComponent } from '../components/loading/loading.component';

@NgModule({
    declarations: [
        AppComponent,
        LfNavbarComponent,
        HomeComponent,
        FarmComponent,
        OptionsComponent,
        PageNotFoundComponent,
        LabFarmOverviewComponent,
        SensorGraphComponent,
        ErrorComponent,
        LoadingComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: 'home', component: HomeComponent },
            { path: 'farm/:id', component: FarmComponent },
            { path: 'options', component: OptionsComponent },
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: "**", component: PageNotFoundComponent }
        ], { useHash: true }),
        BrowserModule,
        UiSwitchModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatSliderModule,
        HttpClientModule,
        NgbModule
    ],
    providers: [
        LabfarmService,
        SensorDataService,
        CookieService,
        AuthenticationService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
