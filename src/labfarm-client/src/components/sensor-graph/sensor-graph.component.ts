import { Component, OnInit, Input } from '@angular/core';
import { Chart } from 'chart.js';
import { SensorDataService } from 'src/providers/sensor-data/sensor-data.service';
import { SensorData } from 'src/models/SensorData';
import { SensorType } from 'src/models/SensorType';
import { SensorValue, LastSensorValues } from 'src/models/SensorValue';
import { LabfarmService } from 'src/providers/labfarm/labfarm.service';
import { Sensor } from 'src/models/Sensor';


@Component({
    selector: 'app-sensor-graph',
    templateUrl: './sensor-graph.component.html',
    styleUrls: ['./sensor-graph.component.scss']
})
export class SensorGraphComponent implements OnInit {

    @Input() Sensor: Sensor;
    @Input() LabfarmId;



    public chart = [];
    public sensorType: SensorType;
    public sensorValues: SensorValue[] = [];

    public sensorDatas: SensorData[];
    public sensorDataTime: string[] = [];
    public sensorDataValue: number[] = [];

    constructor(private labfarmService: LabfarmService) {

    }

    ngOnInit() {
        //getSensorValues(this.Sensor.id);

        this.labfarmService.getSensorValues(this.LabfarmId).subscribe(data => {
            let latestSensorValues = data;

            latestSensorValues.forEach(element => {
                element.data.forEach(e => {
                    if (e.sensorId == this.Sensor.id) {
                        console.log("SensorValue: " + e.sensorId + " is the same as " + this.Sensor.id);

                        let date = new Date(e.timeStamp);
                        let dateString = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();

                        this.sensorDataTime.push(dateString);
                        this.sensorDataValue.push(e.sensorValue);
                    }
                });
            });

            this.initSensorGraph();
        });



    }

    initSensorGraph() {

        this.chart = new Chart('sensor-chart-' + this.Sensor.id, {
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
                    text: this.Sensor.sensorType ? this.Sensor.sensorType.name : "No type specified"
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

    }

}
