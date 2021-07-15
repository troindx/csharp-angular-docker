using System;

namespace Translator.Models
{
    public class TranslationRequest
    {
        public DateTime date { get; set; }

        public string from { get; set; }

        public string to { get; set; }
        public string text { get; set; }
    }
}
