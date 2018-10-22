import { Component, OnInit, Input } from '@angular/core';
import { Chart } from 'chart.js';
import { SensorDataService } from 'src/providers/sensor-data/sensor-data.service';
import { SensorData } from 'src/models/SensorData';


@Component({
    selector: 'app-sensor-graph',
    templateUrl: './sensor-graph.component.html',
    styleUrls: ['./sensor-graph.component.scss']
})
export class SensorGraphComponent implements OnInit {

    @Input() SensorId;

    public chart = [];
    public sensorDatas: SensorData[];
    public sensorDataTime: string[] = [];
    public sensorDataValue: number[] = [];

    constructor(private sensorDataService: SensorDataService) {

    }

    ngOnInit() {
        this.sensorDatas = this.sensorDataService.getSensorDatas();
        this.sensorDatas.forEach(e => {
            if (e.SensorId == this.SensorId) {
                this.sensorDataTime.push(e.Timestamp);
                this.sensorDataValue.push(e.SensorValue);
            }
        });
    }

    ngAfterViewInit() {
        setTimeout(() => {

            this.chart = new Chart('sensor-chart-' + this.SensorId, {
                type: 'line',
                data: {
                    labels: this.sensorDataTime,
                    datasets: [
                        {
                            data: this.sensorDataValue,
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

        }, 100 * this.SensorId);
    }

}
