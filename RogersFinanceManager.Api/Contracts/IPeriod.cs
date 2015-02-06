using System;
using System.Web.Http;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Contracts
{
    public interface IPeriod
    {
        IHttpActionResult GetPeriods();
        IHttpActionResult GetPeriodById(Int32 id);
        IHttpActionResult DeletePeriodById(Int32 id);
        IHttpActionResult UpdatePeriod(Period period);
        IHttpActionResult AddPeriod(Period period);
    }
}
