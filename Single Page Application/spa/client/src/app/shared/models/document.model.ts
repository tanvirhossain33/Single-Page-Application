import { Entity } from './entity.model';

export class Document extends Entity {
    Syllabus: string;
    DevelopmentOfficer: string;
    Manager: string;
    ActiveDate: Date;

    TradeId: string;
    LevelId: string;

    SyllabusFileName: string;
}
