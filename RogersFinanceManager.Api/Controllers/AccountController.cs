using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using RogersFinanceManager.Api.Contracts;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Controllers
{
    [EnableCors(origins: "http://localhost:888", headers: "*", methods: "*")]
    public class AccountController : ApiController, IAccount
    {
        [HttpGet]
        public IHttpActionResult GetAccounts()
        {
            List<Account> accounts;

            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    accounts = context.Accounts.OrderBy(x => x.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(accounts);
        }

        [HttpGet]
        public IHttpActionResult GetAccountById(Int32 accountId)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var account = context.Accounts.FirstOrDefault(x => x.Id == accountId);

                    return Ok(account);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteAccountById(Int32 accountId)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var account = context.Accounts.Find(accountId);

                    if (account != null)
                    {
                        context.Accounts.Remove(account);
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
        public IHttpActionResult UpdateAccount(Account account)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var a = context.Accounts.Find(account.Id);

                    a.Name = account.Name;
                    a.Website = account.Website;
                    a.Description = account.Description;

                    context.SaveChanges();

                    return Ok(a);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult AddAccount(Account account)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    context.Accounts.Add(account);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(true);
        }
    }
}
