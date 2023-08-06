using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Base.BaseModel;

namespace Data.Models;

[Table("UserLog", Schema = "dbo")]
public class UserLog : IdBaseModel
{
    public string UserName { get; set; }
    public string LogType { get; set; }
}

public class UserLogConfiguration : IEntityTypeConfiguration<UserLog>
{
    public void Configure(EntityTypeBuilder<UserLog> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();

        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.LogType).IsRequired(true).HasMaxLength(20);
    }
}
