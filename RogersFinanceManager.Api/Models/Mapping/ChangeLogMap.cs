using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RogersFinanceManager.Api.Models.Mapping
{
    public class ChangeLogMap : EntityTypeConfiguration<ChangeLog>
    {
        public ChangeLogMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ChangeLog");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChangeTypeId).HasColumnName("ChangeTypeId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.C_CreateDate).HasColumnName("_CreateDate");
        }
    }
}
