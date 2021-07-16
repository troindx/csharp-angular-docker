import {HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TranslationRequest } from '../../models/TranslationRequest';
import { TranslationResponse } from '../../models/TranslationResponse';
import { environment } from '../../environments/environment';
/*
  Generated class for the TranslationServiceProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class TranslationServiceProvider {

  constructor(public http: HttpClient) {
    console.log('Hello TranslationServiceProvider');
  }

  public async Translate (translationRequest: TranslationRequest){ 
    let xheaders= new HttpHeaders({
      'Content-Type': 'application/json'
    });
    console.log(environment.serverURL);
    return this.http.post(environment.serverURL + '/api/TranslationRequest', JSON.stringify(translationRequest) , {headers: xheaders});
  }



}
