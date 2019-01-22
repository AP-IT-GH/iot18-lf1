import { Component, OnInit } from '@angular/core';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

@Component({
    selector: 'app-picture-gallery',
    templateUrl: './picture-gallery.component.html',
    styleUrls: ['./picture-gallery.component.scss']
})
export class PictureGalleryComponent implements OnInit {

    private galleryOptions: NgxGalleryOptions[];
    private galleryImages: NgxGalleryImage[];

    constructor() { }

    ngOnInit() {

        this.galleryOptions = [
            {
                "image": false,
                "thumbnailsRemainingCount": true,
                "height": "100px"
            },
            {
                "breakpoint": 500,
                "width": "100%",
                "thumbnailsColumns": 2
            }
        ];

        this.galleryImages = [
            {
                small: 'assets/images/leaf.png',
                big: 'assets/images/leaf.png'
            },
            {
                small: 'assets/images/plant.jpg',
                big: 'assets/images/plant.jpg'
            }, 
            {
                small: 'assets/images/leaf.png',
                big: 'assets/images/leaf.png'
            },
            {
                small: 'assets/images/plant.jpg',
                big: 'assets/images/plant.jpg'
            }, 
            {
                small: 'assets/images/leaf.png',
                big: 'assets/images/leaf.png'
            },
            {
                small: 'assets/images/plant.jpg',
                big: 'assets/images/plant.jpg'
            }, 
            {
                small: 'assets/images/leaf.png',
                big: 'assets/images/leaf.png'
            },
            {
                small: 'assets/images/plant.jpg',
                big: 'assets/images/plant.jpg'
            }, 
            {
                small: 'assets/images/leaf.png',
                big: 'assets/images/leaf.png'
            },
            {
                small: 'assets/images/plant.jpg',
                big: 'assets/images/plant.jpg'
            }, 
            {
                small: 'assets/images/leaf.png',
                big: 'assets/images/leaf.png'
            },
            {
                small: 'assets/images/plant.jpg',
                big: 'assets/images/plant.jpg'
            }
        ];
    }

}
