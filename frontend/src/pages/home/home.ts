import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Input } from '@angular/core';
import { TranslationServiceProvider } from '../../providers/translation-service/translation-service';
import { TranslationRequest } from '../../models/TranslationRequest';
import { TranslationResponse }from '../../models/TranslationResponse';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  public from : string = "en";
  public to : string = "es";
  public text : string = "";
  public translatedText : string = "";
  public timeout = null;
  constructor(public navCtrl: NavController , public transSrv : TranslationServiceProvider) {
    console.log(transSrv);
  }

  RetrieveTranslation(){
    if (this.timeout == null)
      this.timeout = setTimeout((this.RetrieveTranslationHandler).bind(this),3000)
    else{
      clearTimeout(this.timeout);
      this.timeout = setTimeout((this.RetrieveTranslationHandler).bind(this), 3000);
    }
  }

  async RetrieveTranslationHandler(){
    let from = this.from;
    let to = this.to;
    let text = this.text;
    let translationRequest : TranslationRequest = {
      date: new Date().toISOString(),
      from: from,
      to: to,
      text: text
    } ;
    console.log(translationRequest);
    (await this.transSrv.Translate(translationRequest)).subscribe( (response => {
      console.log(response);
      this.timeout = null;
      this.translatedText = response.translatedText;
    }).bind(this));
    
  }


}
