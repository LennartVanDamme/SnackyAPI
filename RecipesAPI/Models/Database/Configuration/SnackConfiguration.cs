using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SnackyAPI.Models.Database.Configuration
{
    public class SnackConfiguration : IEntityTypeConfiguration<Snack>
    {
        public void Configure(EntityTypeBuilder<Snack> builder)
        {
            builder.HasKey(snack => snack.Id);
            
            builder
                .Property(snack => snack.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(snack => snack.Name)
                .IsRequired();
        }
    }
}
