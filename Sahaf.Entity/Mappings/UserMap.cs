using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sahaf.Entity.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public UserMap()
        {

        }

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired();

            builder.Property(t => t.State).IsRequired();

            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);

            builder.Property(t => t.Surname).IsRequired().HasMaxLength(50);

            builder.Property(t => t.Email).HasMaxLength(50);

            builder.Property(t => t.CreatedDate).IsRequired();

            builder.ToTable("User");

            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.State).HasColumnName("State");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Surname).HasColumnName("Surname");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdateDate");
            builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");
            // this.HasOptional(t => t.Customer).WithMany(t => t.Orders).HasForeignKey(d => d.CustomerID);
        }
    }
}
