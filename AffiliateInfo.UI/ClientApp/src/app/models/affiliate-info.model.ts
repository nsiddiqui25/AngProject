export interface AffiliateInfo {
  corpOwners: CorpOwner[];
  additionalEntities: AdditionalEntity[];
  masterSheetId: number;
}

export interface CorpOwner {
  corpOwnerId: number;
  masterSheetId: number;
  corpOwnerName: string;
  corpOwnerPercent?: number;
  lastChangedDate: Date;
  lastChangedId: string;
}

export interface AdditionalEntity {
  //AdditionalEntity
  entityId: number;
  legalName: string;
  dbaname: string;
  zip: string;
  additionalEntityOwner: AdditionalEntityOwner[];
  masterSheetId: number;
}
export interface AdditionalEntityOwner {
  //AdditionalEntityOwners
  entityOwnerId: number;
  fkEntityId?: number;
  ownerName: string;
  ownerPercent: number;
}
