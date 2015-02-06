using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RogersFinanceManager.Api.Models.Mapping
{
    public class BillMap : EntityTypeConfiguration<Bill>
    {
        public BillMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Bill");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.PeriodId).HasColumnName("PeriodId");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.PaidDate).HasColumnName("PaidDate");
            this.Property(t => t.C_CreateDate).HasColumnName("_CreateDate");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithMany(t => t.Bills)
                .HasForeignKey(d => d.AccountId);
            this.HasRequired(t => t.Period)
                .WithMany(t => t.Bills)
                .HasForeignKey(d => d.PeriodId);
            this.HasRequired(t => t.Status)
                .WithMany(t => t.Bills)
                .HasForeignKey(d => d.StatusId);

        }
    }
}
