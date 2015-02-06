using System;
using System.Web.Http;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Contracts
{
    public interface IPerson
    {
        IHttpActionResult GetPersons();
        IHttpActionResult GetPersonById(Int32 personId);
        IHttpActionResult DeletePersonById(Int32 personId);
        IHttpActionResult UpdatePerson(Person person);
        IHttpActionResult AddPerson(Person person);
    }
}
