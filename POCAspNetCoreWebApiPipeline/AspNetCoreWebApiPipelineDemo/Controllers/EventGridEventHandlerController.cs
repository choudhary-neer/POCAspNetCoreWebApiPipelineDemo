using AspNetCoreWebApiPipelineDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace AspNetCoreWebApiPipelineDemo.Controllers
{
    [Produces("application/json")]
    public class EventGridEventHandlerController : Controller
    {
        [HttpPost]
        [Route("~/api/eventgrideventhandler/post")]
        public IActionResult Post([FromBody]object request)
        {
            //Deserializing the request 
            var eventGridEvent = JsonConvert.DeserializeObject<EventGridEvent[]>(request.ToString())
                .FirstOrDefault();
            var data = eventGridEvent.Data as JObject;

            // Validate whether EventType is of "Microsoft.EventGrid.SubscriptionValidationEvent"
            if (string.Equals(eventGridEvent.EventType, "Microsoft.EventGrid.SubscriptionValidationEvent", StringComparison.OrdinalIgnoreCase))
            {
                var eventData = data.ToObject<SubscriptionValidationEventData>();
                var responseData = new SubscriptionValidationResponseData
                {
                    ValidationResponse = eventData.ValidationCode
                };

                if (responseData.ValidationResponse != null)
                {
                    return new OkObjectResult(responseData);
                }
            }
            else
            {
                // Handle your custom event
                var eventData = data.ToObject<CustomData>();
                var customEvent = CustomEvent<CustomData>.CreateCustomEvent(eventData);
                return new OkObjectResult(customEvent);
            }

            return new OkResult();
        }

        [HttpGet]
        [Route("~/api/eventgrideventhandler/ping")]
        public IActionResult Ping()
        {
            return new OkObjectResult(new { message = "Ping successful..." });
        }
    }


}
