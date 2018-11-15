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

    @Input() sensorId: number;
    @Input() LabfarmId;

    public chart = [];
    public sensorType: SensorType;
    public sensorNotation: string;
    public sensorValues: SensorValue[] = [];

    public sensorDatas: SensorData[];
    public sensorDataTime: string[] = [];
    public sensorDataValue: number[] = [];

    constructor(private labfarmService: LabfarmService) {

    }

    ngOnInit() {
        this.labfarmService.getSensorValues(this.sensorId, 12).subscribe(data => {
            let latestSensorValues: LastSensorValues = data;

            this.setSensorNotation(latestSensorValues.sensorType);
            this.setSensorValues(latestSensorValues);
            this.initSensorGraph();
            
        });
    }
    setSensorNotation(sensorType: SensorType) {

        this.sensorType = sensorType;
        
        let _sensorNotation;
        switch (sensorType.name) {
            case "TemperatureSensor":
                _sensorNotation = "°C";
                break;
            case "DustSensor":
                _sensorNotation = "%";
                break;
            case "LightSensor":
                _sensorNotation = "lux";
                break;
            case "ConductivitySensor":
                _sensorNotation = "%";
                break;
            case "WaterSensor":
                _sensorNotation = "L"
                break;
            default:
                _sensorNotation = "n/a";
                break;
        }
        this.sensorNotation = _sensorNotation;

    }

    setSensorValues(lastSensorValues: LastSensorValues){
        lastSensorValues.sensorValues.forEach(e => {
            let date = new Date(e.timeStamp);
            let dateString = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();

            this.sensorDataTime.push(dateString);
            this.sensorDataValue.push(e.sensorValue);
        });
    }

    initSensorGraph() {

        this.chart = new Chart('sensor-chart-' + this.sensorId, {
            type: 'line',
            data: {
                labels: this.sensorDataTime,
                datasets: [
                    {
                        label: 'value',
                        data: this.sensorDataValue,
                        borderColor: "#3cba9f",
                        fill: false
                    }
                ]
            },
            options: {
                title: {
                    display: true,
                    text: this.sensorType ? this.sensorType.name : "No type specified"
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
                            labelString: "Value in " + this.sensorNotation
                        }
                    }],
                }
            }
        });

    }

}
