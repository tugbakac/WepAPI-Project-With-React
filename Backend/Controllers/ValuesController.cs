using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //Json formata uygun hale getiriyoruz WebApiConfig ayarlarını yaptıktan sonra
        //Veritabanındaki kolon ve sütun ayarlarına en yakın ayarları datatable ile kullanabiliriz
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("DepartmentID");
            dt.Columns.Add("DepartmentName");

            dt.Rows.Add(1, "IT");
            dt.Rows.Add(2, "Support");

            return Request.CreateResponse(HttpStatusCode.OK,dt);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
