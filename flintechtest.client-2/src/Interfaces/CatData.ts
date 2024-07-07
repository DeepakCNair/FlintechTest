import { Breed } from "./Breed";

export interface CatData {
    breeds: Breed[];
    id: string;
    url: string;
    width: number;
    height: number;
}

type CatDataArray = CatData[];