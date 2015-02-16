using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using RogersFinanceManager.Api.Contracts;
using RogersFinanceManager.Api.Models;

namespace RogersFinanceManager.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController, IPerson
    {
        [HttpGet]
        public IHttpActionResult GetPersons()
        {
            List<Person> people;

            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    people = context.People.ToList();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(people);
        }

        [HttpGet]
        public IHttpActionResult GetPersonById(Int32 personId)
        {
            Person person;

            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    person = context.People.FirstOrDefault(x => x.Id == personId);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }


            return Ok(person);
        }

        [HttpDelete]
        public IHttpActionResult DeletePersonById(Int32 personId)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var person = context.People.FirstOrDefault(x => x.Id == personId);

                    if (person != null)
                    {
                        context.People.Remove(person);
                        context.SaveChanges();

                        return Ok(true);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(false); // assume fails
        }

        [HttpPut]
        public IHttpActionResult UpdatePerson(Person person)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    var p = context.People.Find(person.Id);

                    if (p != null)
                    {
                        p.FirstName = person.FirstName;
                        p.LastName = person.LastName;
                        p.Email = person.Email;
                        p.Password = p.Password;

                        context.SaveChanges();

                        return Ok(p);
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(person);
        }

        [HttpPost]
        public IHttpActionResult AddPerson(Person person)
        {
            try
            {
                using (var context = new RogersFinanceManagerContext())
                {
                    context.Database.Connection.Open();
                    context.People.Add(person);
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
