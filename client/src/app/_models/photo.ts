export interface Photo {
    id: number;
    url: string;
    isMain: boolean;
    isApproved: boolean;
    username?: string //https://stackoverflow.com/questions/47942141/optional-property-class-in-typescript
}
