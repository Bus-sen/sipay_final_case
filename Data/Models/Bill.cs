using Base.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data;

[Table("Bills", Schema = "dbo")]
public class Bill : IdBaseModel
{
    public int HouseId { get; set; } //accountnumber
    public virtual HouseDetail HouseDetail { get; set; }

    public int Dues { get; set; }
    public decimal ElectricBill { get; set; }
    public decimal WaterBill { get; set; }
    public decimal GasBill { get; set; }
}

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);

        builder.Property(x => x.Dues).IsRequired(true).HasMaxLength(5);
        builder.Property(x => x.ElectricBill).IsRequired(true).HasPrecision(15,2).HasDefaultValue(0);
        builder.Property(x => x.WaterBill).IsRequired(true).HasPrecision(15,2).HasDefaultValue(0);
        builder.Property(x => x.GasBill).IsRequired(true).HasPrecision(15,2).HasDefaultValue(0);

        builder.HasIndex(x => x.HouseId);
    }
}
