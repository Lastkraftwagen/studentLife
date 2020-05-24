export  class EventModel
{
    public id: number;
    public isMulti: boolean;
    public submodels: EventModel[];
    public name: string;
    public description: string;
}