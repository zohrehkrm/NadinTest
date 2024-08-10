using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NadinTest.Controllers.BaseApi
{
    [ApiController]
    [Route("[Controller]")]

    public class BaseController : ControllerBase
    {
        [HttpGet(Name = "GetBase")]
        public ActionResult ApiResultAction(object data, string massage = "")
        {
            if(data == null )
                return BadRequest(new BaseResult()
                {
                    Massage = massage,
                    Data = data,
                    status = Status.Failed
                });

            return Ok(new BaseResult()
            {
                Massage = massage,
                Data = data,
                status = Status.Success
            });

        }
       
    }
}
