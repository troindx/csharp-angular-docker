using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Translator.Models;
using System.Net.Http;
using System.Web;
using System.Net.Http.Json;

namespace Translator.Services
{
    public class GoogleTranslateService
    {
        static readonly HttpClient client = new HttpClient();
        private string apikey;
        public GoogleTranslateService(string apikey)
        {
            this.apikey = apikey;
        }

        public async Task<TranslationResponse> GetTranslation(TranslationRequest translationRequest)
        {
            var response = new TranslationResponse();
            try	
            {
                var url = "https://www.googleapis.com/language/translate/v2?key="+this.apikey+"&source="+translationRequest.from+"&target="+translationRequest.to+"&q="+HttpUtility.UrlEncode(translationRequest.text);
                Console.WriteLine("[REQUEST] {0}",url);
                GoogleResponse responseBody = await client.GetFromJsonAsync<GoogleResponse>(url);
                response.translatedText = responseBody.data.translations[0].translatedText;           
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("[GOOGLE SERVICE] Exception Caught!");	
                Console.WriteLine("[GOOGLE SERVICE] Message :{0} ",e.Message);
                throw;
            }
            return response;
        }
    }
}