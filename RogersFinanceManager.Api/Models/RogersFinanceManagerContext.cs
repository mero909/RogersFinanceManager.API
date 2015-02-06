using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RogersFinanceManager.Api.Models.Mapping;

namespace RogersFinanceManager.Api.Models
{
    public partial class RogersFinanceManagerContext : DbContext
    {
        static RogersFinanceManagerContext()
        {
            Database.SetInitializer<RogersFinanceManagerContext>(null);
        }

        public RogersFinanceManagerContext()
            : base("Name=RogersFinanceManagerContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new BillMap());
            modelBuilder.Configurations.Add(new ChangeLogMap());
            modelBuilder.Configurations.Add(new PeriodMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new StatusMap());
        }
    }
}
