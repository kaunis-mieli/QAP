// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QAP.DataContext
{
    // Multiverse
    public class MultiverseConfiguration : IEntityTypeConfiguration<Multiverse>
    {
        public void Configure(EntityTypeBuilder<Multiverse> builder)
        {
            builder.ToTable("Multiverse", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_MultiverseId");

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Alias).HasColumnName(@"Alias").HasColumnType("varchar(255)").IsRequired(false).IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Timestamp).HasColumnName(@"Timestamp").HasColumnType("datetime").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.auth_User).WithMany(b => b.Multiverses).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Multiverse_User");

            builder.HasIndex(x => x.Alias).HasDatabaseName("IX_MultiverseAlias");
        }
    }

}
// </auto-generated>