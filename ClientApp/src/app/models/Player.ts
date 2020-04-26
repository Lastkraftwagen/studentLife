import { GenderType, PlaceType } from "../enums";

export class Player {

    public name: string;
    public gender: GenderType;


    public theory: number;
    public practic: number;
    public teacherRaiting: number;
    public money: number;
    public happines: number;
    public power: number;
    public hasFollower: boolean;
    public friendsRaiting: number;
    public followerRaiting: number;
    public isDrunk: number;

    public _power: number;
    public _agility: number;
    public _intelligence: number;
    public _speek: number;
    public _attention: number;
    public _glamor: number;

    public place: PlaceType;
    public labMarks: number;
    public countLabs: number;


    constructor() {
    }

}