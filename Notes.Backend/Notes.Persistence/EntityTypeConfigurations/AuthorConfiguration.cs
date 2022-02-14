using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(creator => creator.Id);
            builder.HasIndex(creator => creator.Id).IsUnique();
            builder.Property(creator => creator.Name).HasMaxLength(100);
        }
    }
}
