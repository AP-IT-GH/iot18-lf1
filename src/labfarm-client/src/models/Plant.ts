import { Picture } from "./Picture";

export interface Plant {
    id: number;
    name: string;
    labfarmId: number;
    column: number;
    row: number;
    pictures: Picture[];
}