using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Translator.Models;
using Translator.Services;
using System.Web.Http.Cors;

namespace Translator.Controllers
{
    [ApiController]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    public class TranslationRequestController : ControllerBase
    {
        private GoogleTranslateService googleTranslate;

        public TranslationRequestController( GoogleTranslateService googleTranslateService)
        {
            this.googleTranslate = googleTranslateService;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TranslationResponse>> Post(TranslationRequest translationRequest)
        {
           if (translationRequest != null)
           {
                try
                {
                   var x = await this.googleTranslate.GetTranslation(translationRequest);  
                   return Ok(x);        
                }
                catch(HttpRequestException e)
                {
                    return BadRequest(e.Message);
                }
           } 
           else 
           {
               return BadRequest("Translation request badly formed. Check the request Schema in api documentation");
           }
        }
            
    }
}
