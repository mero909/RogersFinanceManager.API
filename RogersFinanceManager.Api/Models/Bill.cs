using System;
using System.Collections.Generic;

namespace RogersFinanceManager.Api.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int PeriodId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public System.DateTime C_CreateDate { get; set; }
        public virtual Account Account { get; set; }
        public virtual Period Period { get; set; }
        public virtual Status Status { get; set; }
    }
}
