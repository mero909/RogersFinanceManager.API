using System;
using System.Collections.Generic;

namespace RogersFinanceManager.Api.Models
{
    public partial class Period
    {
        public Period()
        {
            this.Bills = new List<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool IsClosed { get; set; }
        public System.DateTime C_CreateDate { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
