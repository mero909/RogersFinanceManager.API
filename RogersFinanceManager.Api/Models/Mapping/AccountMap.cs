using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RogersFinanceManager.Api.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Website)
                .HasMaxLength(200);

            this.Property(t => t.Description)
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.C_CreateDate).HasColumnName("_CreateDate");
        }
    }
}
