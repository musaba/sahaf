using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sahaf.Entity.Mappings
{
    public class PageContentMap : IEntityTypeConfiguration<PageContent>
    {
        public PageContentMap()
        {


        }

        public void Configure(EntityTypeBuilder<PageContent> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).IsRequired();

            builder.ToTable("PageContent");

            builder.Property(t => t.State).IsRequired();

            builder.Property(t => t.PageId).IsRequired();

            builder.Property(t => t.VersionId).IsRequired();

            builder.Property(t => t.HtmlContent).IsRequired();

            builder.Property(t => t.CreatedUserId).IsRequired();

            builder.Property(t => t.CreatedDate).IsRequired();


            builder.Property(t => t.Id).HasColumnName("Id");
            builder.Property(t => t.State).HasColumnName("State");
            builder.Property(t => t.PageId).HasColumnName("PageId");
            builder.Property(t => t.VersionId).HasColumnName("VersionId");
            builder.Property(t => t.HtmlContent).HasColumnName("HtmlContent"); ;
            builder.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(t => t.UpdatedUserId).HasColumnName("UpdatedUserId");
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdateDate");
            builder.Property(t => t.DeletedUserId).HasColumnName("DeleteUserId");
            builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        }
    }
}
