using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RogersFinanceManager.Api.Contracts;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Controllers
{
    public class PeriodController : ApiController, IPeriod
    {
        [HttpGet]
        public IHttpActionResult GetPeriods()
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var periods = context.Periods.OrderByDescending(x => x.EndDate).ToList();

                    return Ok(periods);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetPeriodById(int id)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var period = context.Periods.FirstOrDefault(x => x.Id == id);

                    return Ok(period);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePeriodById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IHttpActionResult UpdatePeriod(Period period)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IHttpActionResult AddPeriod(Period period)
        {
            throw new NotImplementedException();
        }
    }
}
