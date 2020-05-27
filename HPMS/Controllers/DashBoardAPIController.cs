using HPMS.DataModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HPMS.Controllers
{
    public class DashBoardApiController : ApiController
    {
        //POST api/<controller>
        public HttpResponseMessage Post([FromBody] UserData userdata)
        {
            DashData _result = DataProcess.Dashboard(userdata.UserName);

            if (_result == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, _result);
            }
        }
    }
}