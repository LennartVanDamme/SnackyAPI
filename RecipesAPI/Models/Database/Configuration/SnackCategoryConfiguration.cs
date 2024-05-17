using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SnackyAPI.Models.Database.Configuration
{
    public class SnackCategoryConfiguration : IEntityTypeConfiguration<SnackCategory>
    {
        public void Configure(EntityTypeBuilder<SnackCategory> builder)
        {
            builder.HasKey(snackCategory => new { snackCategory.SnackId, snackCategory.Category });

            builder
                .HasOne(snackCategory => snackCategory.Snack)
                .WithMany(snack => snack.Categories)
                .HasForeignKey(snackCategory => snackCategory.SnackId);

            builder
                .Property(snackCategory => snackCategory.Category)
                .HasConversion<string>();
        }
    }
}
