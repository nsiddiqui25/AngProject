export class AffiliateInfo {
  MasterSheetId: number;

  //CorpOwner
  CorpOwnerId: number;
  CorpOwnerName: string;
  CorpOwnerPercent: number;
  LastChangedDate: Date;
  LastChangedId: string;

  //AdditionalEntity
  EntityId: number;
  LegalName: string;
  Dbaname: string;
  Zip: string;

  //AdditionalEntityOwners
  EntityOwnerId: number;
  FkEntityId: number;
  OwnerName: string;
  OwnerPercent: number;
}
