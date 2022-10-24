// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QAP.DataContext
{
    // Problem
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.ToTable("Problem", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_ProblemId");

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Size).HasColumnName(@"Size").HasColumnType("int").IsRequired();
            builder.Property(x => x.MatrixA).HasColumnName(@"MatrixA").HasColumnType("varbinary(max)").IsRequired();
            builder.Property(x => x.MatrixB).HasColumnName(@"MatrixB").HasColumnType("varbinary(max)").IsRequired();
            builder.Property(x => x.Hash).HasColumnName(@"Hash").HasColumnType("binary(32)").IsRequired().HasMaxLength(32);
            builder.Property(x => x.CreatedAt).HasColumnName(@"CreatedAt").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Alias).HasColumnName(@"Alias").HasColumnType("varchar(255)").IsRequired().IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.InitialBestKnownCost).HasColumnName(@"InitialBestKnownCost").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.AllTimeBestKnownCost).HasColumnName(@"AllTimeBestKnownCost").HasColumnType("bigint").IsRequired(false);

            builder.HasIndex(x => x.Alias).HasDatabaseName("UQ_ProblemAlias").IsUnique();
            builder.HasIndex(x => x.Hash).HasDatabaseName("UQ_ProblemHash").IsUnique();
        }
    }

}
// </auto-generated>
