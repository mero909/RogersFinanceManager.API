using System;
using System.Collections.Generic;

namespace RogersFinanceManager.Api.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public System.DateTime C_CreateDate { get; set; }
    }
}
