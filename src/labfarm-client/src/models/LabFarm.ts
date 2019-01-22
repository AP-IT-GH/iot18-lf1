import { Plant } from "./Plant";
import { Sensor } from "./Sensor";

export interface LabFarm {
    id: number;
    name: string;
    authId: string;
    plantSpecies: string;
    dustLevelHigh: number;
    dustLevelLow: number;
    lightLevelHigh: number;
    lightLevelLow: number;
    temperatureLevelHigh: number;
    temperatureLevelLow: number;
    conductivityLevelHigh: number;
    conductivityLevelLow: number;
    minimumReservoirLevel: number;
    maximumReservoirLevel: number;
    autoMode: boolean;
    plants: Plant[];
    sensors: Sensor[];
    config: any;
}
