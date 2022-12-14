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
            builder.Property(x => x.Hash).HasColumnName(@"Hash").HasColumnType("binary(20)").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Alias).HasColumnName(@"Alias").HasColumnType("varchar(255)").IsRequired().IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.Title).HasColumnName(@"Title").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.Description).HasColumnName(@"Description").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.InitialBestKnownCost).HasColumnName(@"InitialBestKnownCost").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Timestamp).HasColumnName(@"Timestamp").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.PermutationId).HasColumnName(@"PermutationId").HasColumnType("bigint").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.auth_User).WithMany(b => b.Problems).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Problem_User");
            builder.HasOne(a => a.Permutation).WithMany(b => b.Problems).HasForeignKey(c => c.PermutationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Problem_Permutation");

            builder.HasIndex(x => x.Alias).HasDatabaseName("UQ_ProblemAlias").IsUnique();
            builder.HasIndex(x => x.Hash).HasDatabaseName("UQ_ProblemHash").IsUnique();
        }
    }

}
// </auto-generated>
