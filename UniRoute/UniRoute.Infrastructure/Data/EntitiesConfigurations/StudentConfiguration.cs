using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniRoute.Domain.Entities;

namespace UniRoute.Infrastructure.Data.EntitiesConfigurations;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(s => s.Mail)
            .IsUnique();

        builder.Property(s => s.Mail)
            .IsRequired()
            .HasMaxLength(77);

        builder.Property(s => s.Password)
            .IsRequired();

        builder.Property(s => s.Salt)
            .IsRequired();

        builder.HasOne(s => s.Address)
            .WithOne(a => a.Student)
            .HasForeignKey<Address>(a => a.StudentId);
    }
}
