import { Component, OnInit, Input } from '@angular/core';
import { Chart } from 'chart.js';


@Component({
    selector: 'app-sensor-graph',
    templateUrl: './sensor-graph.component.html',
    styleUrls: ['./sensor-graph.component.scss']
})
export class SensorGraphComponent implements OnInit {

    @Input() SensorId;

    public chart = [];

    constructor() {

    }

    ngOnInit() {

    }

    ngAfterViewInit() {
        setTimeout(() => {

            this.chart = new Chart('sensor-chart-' + this.SensorId, {
                type: 'line',
                data: {
                    labels: ['a', 'b', 'c', 'a' ,'b','c','d','s','s','s','s'],
                    datasets: [
                        {
                            data: [1, 2, 3,5,6,7,8,7,5,9,10,7,4,4],
                            borderColor: "#3cba9f",
                            fill: false
                        }
                    ]
                },
                options: {
                    legend: {
                        display: false
                    },
                    scales: {
                        xAxes: [{
                            display: true
                        }],
                        yAxes: [{
                            display: true
                        }],
                    }
                }
            });
           
        }, 100*this.SensorId);
    }

}
