using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Albreca.Web.Controllers
{
    public class SubjectController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            yield return "Calculus";
            yield return "Algebra";
            yield return "Trig";
        }

        [HttpGet]
        public IEnumerable<string> GetSubjectByName(string subjectName)
        {
            yield return subjectName;
        }

        // POST api/book
        public void Post([FromBody]string value)
        {
        }

        // PUT api/book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/book/5
        public void Delete(int id)
        {
        }
    }
}
