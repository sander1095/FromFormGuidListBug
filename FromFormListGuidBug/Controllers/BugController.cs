using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace FromFormListGuidBug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        // ISSUE WITH [FromForm] and the BugModel
        // I expect the IEnumerable<Guid> to be filled with the Guids I supplied
        // Currently it is empty, probably because it can't translate the big 1 string into a GUID.

        // Putting the same info into the IdsAsString does kind of work, although the list will only
        // contain 1 item which is all the items but comma seperated into 1 value.



        // REMARKS ABOUT PROJECT:
        // 1. Swagger is added for easy testing
        // 2. I disabled model validation in Startup.cs because it will throw an error about not being able
        //    to transform the string "37a2b5e7-13e6-4329-8f52-decd842bedf1, 6d46f11f-7fd2-4688-a112-128c319e396d" into a guid

        [HttpPost("bug")]
        public ActionResult<string> Bug([FromForm] BugModel bugModel)
        {
            var message = GetMessage(bugModel);

            return Ok(message);
        }

        [HttpPost("works")]
        public ActionResult<string> Works([FromBody] BugModel bugModel)
        {
            var message = GetMessage(bugModel);

            return Ok(message);
        }

        private string GetMessage(BugModel bugModel)
        {
            var amountOfGuids = bugModel?.Ids?.Count();
            var guidsText = string.Join(", ", bugModel?.Ids) ?? "EMPTY";

            var amountOfGuidsAsString = bugModel?.IdsAsStringList?.Count();
            var guidsAsStringText = string.Join(", ", bugModel?.IdsAsStringList) ?? "EMPTY";

            string guidMessage = $"You have supplied a total of {amountOfGuids} GUID(s). {Environment.NewLine}" +
                $"The values are as follows: {guidsText}";

            string guidsAsStringMessage = $"You have supplied a total of {amountOfGuidsAsString} GUID(s) as strings. {Environment.NewLine}" +
                $"The values are as follows: {guidsAsStringText}";

            return guidMessage + 
                Environment.NewLine + 
                Environment.NewLine + 
                guidsAsStringMessage;
        }
    }
}