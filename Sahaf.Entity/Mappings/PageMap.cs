using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sahaf.Entity.Mappings
{
    public class PageMap : IEntityTypeConfiguration<Page>
    {
        public PageMap()
        {
           
        }

        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired();

            builder.Property(t => t.State).IsRequired();

            builder.Property(t => t.Title).IsRequired().HasMaxLength(150);

            builder.Property(t => t.LatestVersion).IsRequired();

            builder.Property(t => t.CreatedUserId).IsRequired();

            builder.Property(t => t.CreatedDate).IsRequired();

            builder.ToTable("Page");

            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.State).HasColumnName("State");
            builder.Property(t => t.Title).HasColumnName("Title");
            builder.Property(t => t.LatestVersion).HasColumnName("LatestVersion");
            builder.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(t => t.UpdatedUserId).HasColumnName("UpdatedUserId");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdateDate");
            builder.Property(t => t.DeletedUserId).HasColumnName("DeleteUserId");
            builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");
        }
    }
}
