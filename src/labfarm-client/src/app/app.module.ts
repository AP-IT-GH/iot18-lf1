/* MODULES */
import { MatButtonModule, MatCheckboxModule, MatSliderModule, MatDialogModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { VerticalTimelineModule } from 'angular-vertical-timeline';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgxGalleryModule } from 'ngx-gallery';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgModule } from '@angular/core';

/* 3RD PARTY LIBRARIES */
import { UiSwitchModule } from 'ngx-toggle-switch';
import { CookieService } from 'ngx-cookie-service';
import { AppComponent } from './app.component';
import 'hammerjs';

/* SERVICES */
import { AuthenticationService } from 'src/providers/authentication/authentication.service';
import { SensorDataService } from 'src/providers/sensor-data/sensor-data.service';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';

/* COMPONENTS */
import { EditLabfarmComponent, DeleteDialog } from '../pages//edit-labfarm/edit-labfarm.component';
import { LabFarmOverviewComponent } from '../components/lab-farm-overview/lab-farm-overview.component';
import { PictureTimelineComponent } from '../components/picture-timeline/picture-timeline.component';
import { PictureGalleryComponent } from '../components/picture-gallery/picture-gallery.component';
import { SensorGraphComponent } from '../components/sensor-graph/sensor-graph.component';
import { LfNavbarComponent } from '../components/lf-navbar/lf-navbar.component';
import { LoadingComponent } from '../components/loading/loading.component';
import { ErrorComponent } from '../components/error/error.component';

/* PAGES */
import { PictureviewerComponent } from '../pages/pictureviewer/pictureviewer.component';
import { PageNotFoundComponent } from '../pages/page-not-found/page-not-found.component';
import { NewLabfarmComponent } from '../pages/new-labfarm/new-labfarm.component';
import { CallbackComponent } from '../pages/callback/callback.component';
import { OptionsComponent } from '../pages/options/options.component';
import { HomeComponent } from '../pages/home/home.component';
import { FarmComponent } from '../pages/farm/farm.component';




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
        LoadingComponent,
        NewLabfarmComponent,
        EditLabfarmComponent,
        DeleteDialog,
        PictureviewerComponent,
        PictureGalleryComponent,
        PictureTimelineComponent,
        CallbackComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: 'home', component: HomeComponent },
            { path: 'farm/:id', component: FarmComponent },
            { path: 'farm/:id/edit', component: EditLabfarmComponent},
            { path: 'options', component: OptionsComponent },
            { path: 'pictureviewer', component: PictureviewerComponent },
            { path: 'callback', component: CallbackComponent },
            { path: 'new', component: NewLabfarmComponent },
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: "**", component: PageNotFoundComponent }
        ], { useHash: false }),
        BrowserModule,
        UiSwitchModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatCheckboxModule,
        MatSliderModule,
        HttpClientModule,
        NgbModule,
        MatDialogModule,
        NgxGalleryModule,
        VerticalTimelineModule
    ],
    providers: [
        LabfarmService,
        SensorDataService,
        CookieService,
        AuthenticationService
    ],
    entryComponents: [
        DeleteDialog
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
