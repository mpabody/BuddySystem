export interface Trip{
    TripId: number;
    StartTime: Date;
    BuddyId: number;
    BuddyName: string;
    VolunteerId: number;
    Volunteer: string;
    StartLocation: string;
    ProjectedEndLocation: string;
    EndLocation: string;
    EndTime: Date;
    Description?: string;
    // AdditionalBuddies: AdditionalBuddy[]; AdditionalBuddy doesn't exist yet
}