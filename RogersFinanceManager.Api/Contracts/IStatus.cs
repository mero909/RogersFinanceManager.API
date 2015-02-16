using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RogersFinanceManager.Api.Contracts
{
    public interface IStatus
    {
        IHttpActionResult GetStatuses();
        IHttpActionResult GetStatusById(Int32 id);
    }
}
