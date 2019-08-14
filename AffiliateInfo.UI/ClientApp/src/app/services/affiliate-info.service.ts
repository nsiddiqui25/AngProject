import { Injectable } from '@angular/core';
import { AffiliateInfo } from '../models/affiliate-info.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AffiliateInfoService {
  formData: AffiliateInfo;
  readonly baseUrl = 'http://localhost:55379/api/';
  list: AffiliateInfo[];

  constructor(private http: HttpClient) { }

  putAffiliateInfo(formData: AffiliateInfo): Observable<void> {
    console.log(JSON.stringify(formData));
    return this.http.put<void>(this.baseUrl + 'affiliates/', formData);
  }

  getAffiliateInfo(masterSheetId): Observable<AffiliateInfo> {
    return this.http.get<AffiliateInfo>(this.baseUrl + 'affiliates/' + masterSheetId);
  }
}
