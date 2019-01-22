import { Component, OnInit, Input } from '@angular/core';
import { Picture } from 'src/models/Picture';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-picture-preview',
    templateUrl: './picture-preview.component.html',
    styleUrls: ['./picture-preview.component.scss']
})
export class PicturePreviewComponent implements OnInit {

    @Input() picture: Picture;
    @Input() modal: NgbModal;


    constructor() {

    }

    ngOnInit() {
    }

}
