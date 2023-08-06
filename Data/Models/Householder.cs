using Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data;

[Table("Householders", Schema = "dbo")]
public class Householder : BaseModel
{
    public string HouseholderTc { get; set; }
    public int HouseholderNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool HaveCar { get; set; }

    public virtual List<HouseDetail> HouseDetails { get; set; }
}

public class HouseholderConfiguration : IEntityTypeConfiguration<Householder>
{
    public void Configure(EntityTypeBuilder<Householder> builder)
    {
        builder.Property(x => x.HouseholderNumber).IsRequired(true).ValueGeneratedNever();
        builder.HasIndex(x => x.HouseholderNumber).IsUnique(true);
        builder.HasKey(x => x.HouseholderNumber);

        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);

        builder.Property(x => x.HouseholderTc).IsRequired(true).HasMaxLength(11);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(20);
        builder.Property(x => x.PhoneNumber).IsRequired(true).HasMaxLength(10);
        builder.Property(x => x.HaveCar).IsRequired(true).HasDefaultValue(false);

        builder.HasIndex(x => x.HouseholderNumber).IsUnique(true);

        builder.HasMany(x => x.HouseDetails)
            .WithOne(x => x.Householder)
            .HasForeignKey(x => x.HouseholderNumber)
            .IsRequired(true);

    }
}
