import { Component, OnInit, Input } from '@angular/core';
import { Chart } from 'chart.js';
import { SensorDataService } from 'src/providers/sensor-data/sensor-data.service';
import { SensorData } from 'src/models/SensorData';
import { SensorType } from 'src/models/SensorType';


@Component({
    selector: 'app-sensor-graph',
    templateUrl: './sensor-graph.component.html',
    styleUrls: ['./sensor-graph.component.scss']
})
export class SensorGraphComponent implements OnInit {

    @Input() SensorId;

    public chart = [];
    public sensorType: SensorType;
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
        this.sensorType = this.sensorDatas[0].SensorType;
    }

    ngAfterViewInit() {
        setTimeout(() => {

            this.chart = new Chart('sensor-chart-' + this.SensorId, {
                type: 'line',
                data: {
                    labels: this.sensorDataTime,
                    datasets: [
                        {
                            label: 'label',
                            data: this.sensorDataValue,
                            borderColor: "#3cba9f",
                            fill: false
                        }
                    ]
                },
                options: {
                    title: {
                        display: true,
                        text: this.sensorDatas[0].SensorType ? this.sensorDatas[0].SensorType.TypeName : "No type specified"
                    },
                    legend: {
                        display: false
                    },
                    scales: {
                        xAxes: [{
                            display: true,

                            scaleLabel: {
                                display: true,
                                labelString: "Time"
                              }
                        }],
                        yAxes: [{
                            display: true,
                            scaleLabel: {
                                display: true,
                                labelString: "Value in %"
                              }
                        }],
                    }
                }
            });

        }, 100 * this.SensorId);
    }

}
