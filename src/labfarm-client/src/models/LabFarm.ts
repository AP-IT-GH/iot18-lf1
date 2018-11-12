
export interface LabFarm {
    LabFarmId: number;
    AuthId: string;
    PlantSpecies: string;
    DustLevelHigh: number;
    DustLevelLow: number;
    LightLevelHigh: number
    LightLevelLow: number;
    HumidityLevelHigh: number;
    HumidityLevelLow: number;
    ConductivityLevelHigh: number;
    ConductivityLevelLow: number;
    MinimumReservoirLevel: number;
    MaximumReservoirLevel: number;
}