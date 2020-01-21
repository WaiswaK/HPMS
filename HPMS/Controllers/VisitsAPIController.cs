using HPMS.DataModels;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HPMS.Controllers
{
    public class VisitsAPIController : ApiController
    {
        private Models.HPMS db = new Models.HPMS();
        
        //POST api/<controller>
        public HttpResponseMessage Post([FromBody] UserData userdata)
        {
            List<ResultData> _results = DataProcess.Patient_Visits(userdata.UserName);
            
            if (_results == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, _results);
            }
        }
    }
}