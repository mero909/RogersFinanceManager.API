using System;
using System.Web.Http;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Contracts
{
    public interface IBill
    {
        IHttpActionResult GetBills();
        IHttpActionResult GetBillById(Int32 id);
        IHttpActionResult DeleteBillById(Int32 id);
        IHttpActionResult UpdateBill(Bill bill);
        IHttpActionResult AddBill(Bill bill);
    }
}