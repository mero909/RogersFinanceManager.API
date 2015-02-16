using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using RogersFinanceManager.Api.Contracts;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StatusController : ApiController, IStatus
    {
        [HttpGet]
        public IHttpActionResult GetStatuses()
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var statuses = context.Status.ToList();

                    return Ok(statuses);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetStatusById(int id)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var status = context.Status.FirstOrDefault(x => x.Id == id);

                    return Ok(status);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
