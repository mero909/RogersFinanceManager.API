using System;
using System.Collections.Generic;

namespace RogersFinanceManager.Api.Models
{
    public partial class Account
    {
        public Account()
        {
            this.Bills = new List<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public System.DateTime C_CreateDate { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
