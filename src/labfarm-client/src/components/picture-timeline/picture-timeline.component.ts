import { Component, OnInit, Input } from '@angular/core';
import { Picture } from 'src/models/Picture';
import { LabFarm } from 'src/models/LabFarm';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';

@Component({
    selector: 'app-picture-timeline',
    templateUrl: './picture-timeline.component.html',
    styleUrls: ['./picture-timeline.component.scss']
})
export class PictureTimelineComponent implements OnInit {

    @Input() labfarm: LabFarm;
    @Input() modal: NgbModal;


    private pictures: Picture[];

    private pictureCount = 24;
    private pageSize = 24;
    private pageCount = 1;


    private date: Date = new Date();

    settings = {
        bigBanner: true,
        timePicker: true,
        format: 'dd-MM-yyyy HH:mm',
        defaultOpen: false
    }


    constructor(
        private labfarmService: LabfarmService
    ) {
    }
    ngOnInit() {
        this.pictures = [];

        this.date.setDate(this.date.getDate() - 1);
        // this.date.setHours(0);
        // this.date.setMinutes(0);

        if (!this.labfarm)
            return;


        this.labfarm.plants.forEach(plant => {
            this.labfarmService.getPictures(plant.id, this.pictureCount, this.pageSize, this.pageCount).subscribe(data => {
                data.forEach(picture => {
                    this.pictures.push(picture);
                });
            })
        });

        this.pictures = this.pictures.sort(this.pictureSort);
    }

    pictureSort(p1: Picture, p2: Picture): number {
        if (p1.timeStamp < p2.timeStamp)
            return -1;

        if (p1.timeStamp > p2.timeStamp)
            return 1;

        return 0;
    }

}
