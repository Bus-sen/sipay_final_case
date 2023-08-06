using Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data;

[Table("HouseDetails", Schema = "dbo")]
public class HouseDetail : BaseModel
{
    public int HouseId { get; set; } //accountnumber

    public int HouseholderNumber { get; set; }
    public virtual Householder Householder { get; set; }

    public int Floor { get; set; }
    public bool IsEmpty { get; set; } //boş(true)
    public bool IsSmall { get; set; } // 3+1:small(true) 4+1=large(false)
    
    public virtual List<Bill> Bills { get; set; }
}

public class HouseDetailConfiguration : IEntityTypeConfiguration<HouseDetail>
{
    public void Configure(EntityTypeBuilder<HouseDetail> builder)
    {
        builder.Property(x => x.HouseId).IsRequired(true).ValueGeneratedNever();
        builder.HasIndex(x => x.HouseId).IsUnique(true);
        builder.HasKey(x => x.HouseId);

        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);

        builder.Property(x => x.HouseholderNumber).IsRequired(true);
        builder.Property(x => x.Floor).IsRequired(true).HasMaxLength(2);
        builder.Property(x => x.IsEmpty).IsRequired(true).HasDefaultValue(false);
        builder.Property(x => x.IsSmall).IsRequired(true).HasDefaultValue(false);

        builder.HasIndex(x => x.HouseholderNumber);

        builder.HasMany(x => x.Bills)
            .WithOne(x => x.HouseDetail)
            .HasForeignKey(x => x.HouseId)
            .IsRequired(true);
    }
}
