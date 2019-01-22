import { Component, OnInit, Input } from '@angular/core';
import { Picture } from 'src/models/Picture';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PicturePreviewComponent } from '../picture-preview/picture-preview.component';

@Component({
    selector: 'app-picture-thumbnail',
    templateUrl: './picture-thumbnail.component.html',
    styleUrls: ['./picture-thumbnail.component.scss']
})
export class PictureThumbnailComponent implements OnInit {

    @Input() picture: Picture;
    @Input() modal: NgbModal;

    private modalCloseResult: string;

    constructor(
        private modalService: NgbModal
    ) { }

    ngOnInit() {
    }

    openPictureDetail(content: PictureThumbnailComponent) {
        let modal = this.modalService.open(content, {
            'size': 'sm',
            'centered': true
        }).result.then((result) => {
            this.modalCloseResult = `Closed with: ${result}`;
        }, (reason) => {
            this.modalCloseResult = `Dismissed ${this.getDismissReason(reason)}`;
        });
    }

    private getDismissReason(reason: any): string {
        if (reason === ModalDismissReasons.ESC) {
            return 'by pressing ESC';
        } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
            return 'by clicking on a backdrop';
        } else {
            return `with: ${reason}`;
        }
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
