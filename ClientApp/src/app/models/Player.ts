import { GenderType, PlaceType, DistanceType, CompanyType } from "../enums";
import { Laba } from "./Laba";

export class Player {

    public Name: string;
    public Gender: GenderType;


    public Theory: number;
    public Practic: number;
    public TeacherRaiting: number;
    public Money: number;
    public Happines: number;
    public Power: number;
    public hasFollower: boolean;
    public hasJob: boolean;
    public WorkTiles: number;
    public AssignedWork: number;

    public FriendsRaiting: number;
    public FollowerRaiting: number;
    public isDrunk: number;

    public _power: number;
    public _agility: number;
    public _intelligence: number;
    public _speek: number;
    public _attention: number;
    public _glamor: number;

    public Place: PlaceType;
    public labMarks: number;

    public Labs: Laba[];

    public CurrentLaba: Laba; 


    public distanceFromHome: DistanceType;
    public Company: CompanyType;

    public DrunkLevel: number;


    constructor() {
    }

}