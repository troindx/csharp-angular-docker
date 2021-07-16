using NUnit.Framework;
using RestSharp;
using RestSharp.Deserializers;
using System.Net;
using Translator.Models;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace TranslationTesting{
    [TestFixture]
    public class TranslationRequestUnitTest{

        private IConfiguration configuration;
        private string serverURL;

        public TranslationRequestUnitTest(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.serverURL = this.configuration["serverURL"];
        }
       
        [Test]
        public void TestforApplicationJSONHeader(){
            RestClient client = new RestClient("https://jsonplaceholder.typicode.com/users");
            RestRequest request = new RestRequest("1", Method.POST);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var result = output["name"];
            Assert.That(result, Is.EqualTo("john"), "name not correct");
        }
    }
}
