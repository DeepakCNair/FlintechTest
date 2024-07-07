export interface ClubMember {
    id: number;
    name: string;
    linkId?: number | null;
    isTraversed?: boolean | false;
    isCircularReference?: boolean | false;
    isBillable?: boolean | false;
}