using System;

namespace Translator.Models
{
    public class GoogleData{
        public string translatedText { get; set; }
    }

    public class GoogleTranslations{
        public GoogleData [] translations { get; set; }
    }
    public class GoogleResponse
    {
        public GoogleTranslations data {get; set;}
    }



}