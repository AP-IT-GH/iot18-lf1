import { Component, OnInit, Input } from '@angular/core';
import { Picture } from 'src/models/Picture';
import { LabFarm } from 'src/models/LabFarm';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-picture-timeline',
    templateUrl: './picture-timeline.component.html',
    styleUrls: ['./picture-timeline.component.scss']
})
export class PictureTimelineComponent implements OnInit {

    @Input() labfarm: LabFarm;
    @Input() modal: NgbModal;


    private pictures: Picture[];

    constructor() {
    }
    ngOnInit() {
        this.pictures = [];

        this.labfarm.plants.forEach(plants => {
            plants.pictures.forEach(picture => {
                this.pictures.push(picture);

            })
        });

        if (this.pictures)
            this.pictures = this.pictures.sort(this.pictureSort);
    }

    pictureSort(p1: Picture, p2: Picture): number {
        if (p1.timeStamp < p2.timeStamp)
            return -1;

        if (p1.timeStamp > p2.timeStamp)
            return 1;

        return 0;
    }

    getTimeString(date: Date): string {
        let d = new Date(date);
        let hours = d.getUTCHours() + 1;
        let mins = d.getUTCMinutes();
        // let secs = d.getUTCSeconds();

        return `${this.timify(hours)}:${this.timify(mins)}`;
        // return `${this.timify(hours)}:${this.timify(mins)}:${this.timify(secs)}`;
    }

    timify(n: number): string {
        let s = n.toString();
        return s.length == 2 ? s : `0${s}`;
    }

}
