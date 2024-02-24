// team member and schedule break interval - used for conodelgiorno registering
export interface TeamMember {
    fullName: string,
    breakStartHour?: Date,
    breakStopHour?: Date,
    hasCredential?: boolean,
    userName?: string,
    isAdmin?: boolean
}
