using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;
using RogersFinanceManager.Api.Contracts;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BillController : ApiController, IBill
    {
        [HttpGet]
        public IHttpActionResult GetBills()
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    context.Database.Connection.Open();
                    var bills = context.Bills.OrderByDescending(x => x.DueDate)
                        .Include(a => a.Account)
                        .Include(s => s.Status)
                        .Include(p => p.Period)
                        .ToList();

                    return Ok(bills);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetBillById(int id)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var b = context.Bills.FirstOrDefault(x => x.Id == id);

                    return Ok(b);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteBillById(int id)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var bill = context.Bills.Find(id);

                    if (bill != null)
                    {
                        context.Bills.Remove(bill);
                        context.SaveChanges();

                        return Ok(true);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(false);
        }

        [HttpPut]
        public IHttpActionResult UpdateBill(Bill bill)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var b = context.Bills.Find(bill.Id);

                    if (b != null)
                    {
                        b.Name = bill.Name;
                        b.PaidDate = bill.PaidDate;
                        b.DueDate = bill.DueDate;
                        b.Amount = bill.Amount;
                        b.Account = bill.Account;
                        b.Status = bill.Status;
                        b.Period = bill.Period;

                        context.SaveChanges();

                        return Ok(true);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(false);
        }

        [HttpPost]
        public IHttpActionResult AddBill(Bill bill)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    context.Bills.Add(bill);
                    context.SaveChanges();

                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
