import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { LfNavbarComponent } from './components/lf-navbar/lf-navbar.component';
import { HomeComponent } from './pages/home/home.component';
import { FarmComponent } from './pages/farm/farm.component';
import { OptionsComponent } from './pages/options/options.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { LabFarmOverviewComponent } from './components/lab-farm-overview/lab-farm-overview.component';

@NgModule({
  declarations: [
    AppComponent,
    LfNavbarComponent,
    HomeComponent,
    FarmComponent,
    OptionsComponent,
    PageNotFoundComponent,
    LabFarmOverviewComponent
  ],
  imports: [
    RouterModule.forRoot([
        { path: 'home', component: HomeComponent},
        { path: 'farm/:id', component: FarmComponent},
        { path: 'options', component: OptionsComponent},
        { path: '', redirectTo: 'home', pathMatch: 'full'},
        { path: "**", component: PageNotFoundComponent}
      ], { useHash: true }),
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
