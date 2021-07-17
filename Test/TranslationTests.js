const path = require('path');
const scriptName = path.basename(__filename).replace('.js', '');
var request = require('then-request');

//Integration tests for Language Wire

module.exports = async it => {
    var url = 'http://localhost:5001/api/translationRequest';
    var correctTranslationRequest = 
    {
        "date": "2021-07-17T13:58:45.996Z",
        "from": "es",
        "to": "en",
        "text": "hola mundo"
    }
    var incorrectTranslationRequest = 
    {
        "date": "2021-07-17T13:58:45.996Z",
        "from": "string",
        "to": "string",
        "text": "hola mundo"
    }
    let response = await request('POST', url, {json: correctTranslationRequest})
    let jsonResponse = JSON.parse(response.getBody('utf8'))
    it(scriptName + " Response statuscode should be 200" , () => it.eq(response.statusCode, 200));
    it(scriptName + " Response should be Hello World" , () => it.eq(jsonResponse.translatedText, "Hello World"));

    response = await request('POST', url, {json: incorrectTranslationRequest})
    it(scriptName + " On Malformed Request. Statuscode should be 400" , () => it.eq(response.statusCode, 400));
};
