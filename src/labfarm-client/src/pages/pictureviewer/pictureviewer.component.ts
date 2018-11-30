import { Component, OnInit } from '@angular/core';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { Picture } from 'src/models/Picture';
import { AuthenticationService } from 'src/providers/authentication/authentication.service';

@Component({
    selector: 'app-pictureviewer',
    templateUrl: './pictureviewer.component.html',
    styleUrls: ['./pictureviewer.component.scss']
})
export class PictureviewerComponent implements OnInit {

    public pictures: Picture[];

    public error: boolean = false;

    constructor(private labfarmService: LabfarmService, private authService: AuthenticationService) {
        // this.authService.login();

        labfarmService.getPictures().subscribe(data => {
            this.pictures = data;
        }, error => {
            this.error = true;
            console.log(error);
        });
    }

    ngOnInit() {
    }

    savePicture(p: Picture) {
        console.log("Edit picture is currently not working.");
    }

    deletePicture(p: Picture) {
        this.labfarmService.deletePicture(p).subscribe(data => {
            console.log(data);
            let index = this.pictures.indexOf(p);
            this.pictures.splice(index, 1);
        }, failed => {
            console.log(failed);
        })

    }

    login() {
        this.authService.login();
    }

}
