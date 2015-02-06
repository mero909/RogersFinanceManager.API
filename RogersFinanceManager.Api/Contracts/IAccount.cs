using System;
using System.Web.Http;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Contracts
{
    public interface IAccount
    {
        IHttpActionResult GetAccounts();
        IHttpActionResult GetAccountById(Int32 accountId);
        IHttpActionResult DeleteAccountById(Int32 accountId);
        IHttpActionResult UpdateAccount(Account account);
        IHttpActionResult AddAccount(Account account);
    }
}
