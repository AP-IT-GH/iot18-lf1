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
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatSliderModule} from '@angular/material';
import 'hammerjs';

@NgModule({
  declarations: [
    AppComponent,
    LfNavbarComponent,
    HomeComponent,
    FarmComponent,
    OptionsComponent,
    PageNotFoundComponent,
    LabFarmOverviewComponent,
    SensorGraphComponent
  ],
  imports: [
    RouterModule.forRoot([
        { path: 'home', component: HomeComponent},
        { path: 'farm/:id', component: FarmComponent},
        { path: 'options', component: OptionsComponent},
        { path: '', redirectTo: 'home', pathMatch: 'full'},
        { path: "**", component: PageNotFoundComponent}
      ], { useHash: true }),
    BrowserModule,
    UiSwitchModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatSliderModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
