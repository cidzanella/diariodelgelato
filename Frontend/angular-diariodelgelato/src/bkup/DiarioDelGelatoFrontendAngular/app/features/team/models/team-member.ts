// team member and schedule break interval - used for conodelgiorno registering and time&attendance
export interface TeamMember {
    id?: number;
    fullName: string;
    workStartHour?: Date;
    workStopHour?: Date;
    breakStartHour?: Date;
    breakStopHour?: Date;
    userName?: string;
    isAdmin?: boolean;
    photo?: string;
}
