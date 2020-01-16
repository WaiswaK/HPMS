using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HPMS.DataModels;
using HPMS.Models;

namespace HPMS.Controllers
{
    public class VisitsAPIController : ApiController
    {
        private Models.HPMS db = new Models.HPMS();
        /*
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] UserData userdata)
        {





            List<Disease> diseases = DiseaseProcess.FinalDiseases(responsedata.Selected_symptoms);
            List<Pest> pests = PestProcess.FinalPests(responsedata.Selected_symptoms);
            List<Result> final = new List<Result>();
            try
            {
                foreach (var disease in diseases)
                {
                    Result dis = new Result()
                    {
                        Item = "Disease",
                        Name = disease.Name,
                        Solutions = ControlProcess.DiseaseControls(disease.D_ID)
                    };
                    final.Add(dis);
                }
            }
            catch
            {

            }
            try
            {
                foreach (var pest in pests)
                {
                    Result pes = new Result()
                    {
                        Item = "Pest",
                        Name = pest.Name,
                        Solutions = ControlProcess.PestControls(pest.P_ID)
                    };
                    final.Add(pes);
                }
            }
            catch
            {

            }
            if (diseases == null && pests == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Diagnosis found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, final);
            }
        }
        */
    }
}