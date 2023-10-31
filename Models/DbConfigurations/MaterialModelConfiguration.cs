using api.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.DbConfigurations
{
    public class MaterialModelConfiguration : IEntityTypeConfiguration<MaterialModel>
    {
        public void Configure(EntityTypeBuilder<MaterialModel> builder)
        {
            builder.ToTable("Material");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.SubjectId)
                .HasColumnName("subject_id");
            builder.Property(e => e.Slug)
                .HasColumnName("slug")
                .HasColumnType("varchar");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar");
            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("text");
            builder.Property(e => e.Content)
                .HasColumnName("content")
                .HasColumnType("text");
            builder.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp");
            builder.Property(e => e.UpdatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp");

            builder.HasOne(m => m.Subject)
                .WithMany(s => s.Materials)
                .HasForeignKey(m => m.SubjectId);
        }
    }
}
