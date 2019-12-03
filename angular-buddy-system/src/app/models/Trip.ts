/*This model's sole purpose is to display some trip details for a list */
export interface TripListItem {
    TripId?: number;
    StartLocation: string;
    EndLocation: string;
    Description: string;
    BuddyId: number;
    BuddyName: string;
    VolunteerId?: number;
    VolunteerName?: string;
}