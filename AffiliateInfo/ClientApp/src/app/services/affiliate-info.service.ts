import { Injectable } from '@angular/core';
import { AffiliateInfo } from '../models/affiliate-info.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AffiliateInfoService {
  formData: AffiliateInfo;
  readonly baseUrl = 'http://localhost:55379/api/';

  constructor(private http: HttpClient) { }

  putAffiliateInfo(formData: AffiliateInfo) {
    return this.http.put(this.baseUrl + 'affiliates/', formData);
  }
}
