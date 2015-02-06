using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RogersFinanceManager.Api.Models.Mapping
{
    public class PeriodMap : EntityTypeConfiguration<Period>
    {
        public PeriodMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Period");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.IsClosed).HasColumnName("IsClosed");
            this.Property(t => t.C_CreateDate).HasColumnName("_CreateDate");
        }
    }
}
