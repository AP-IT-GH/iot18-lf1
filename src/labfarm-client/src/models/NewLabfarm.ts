import { Plant } from "./Plant";
import { Sensor } from "./Sensor";

export interface NewLabfarm {
    Name: string;
    AuthId: string;
    PlantSpecies: string;
    DustLevelHigh: number;
    DustLevelLow: number;
    LightLevelHigh: number;
    LightLevelLow: number;
    TemperatureLevelHigh: number;
    TemperatureLevelLow: number;
    ConductivityLevelHigh: number;
    ConductivityLevelLow: number;
    MinimumReservoirLevel: number;
    MaximumReservoirLevel: number;
    autoMode: boolean;
    plants: Plant[];
    sensors: Sensor[];
}
