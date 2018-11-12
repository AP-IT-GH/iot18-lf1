import { Plant } from "./Plant";
import { Sensor } from "./Sensor";

export interface LabFarmDto {
    id: number;
    name: string;
    authId: string;
    plantSpecies: string;
    dustLevelHigh: number;
    dusLevelLow: number;
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
}
