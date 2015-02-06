using System;
using System.Collections.Generic;

namespace RogersFinanceManager.Api.Models
{
    public partial class ChangeLog
    {
        public int Id { get; set; }
        public int ChangeTypeId { get; set; }
        public string Description { get; set; }
        public System.DateTime C_CreateDate { get; set; }
    }
}
