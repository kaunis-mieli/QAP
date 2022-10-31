// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QAP.DataContext
{
    // Permutation
    public class PermutationConfiguration : IEntityTypeConfiguration<Permutation>
    {
        public void Configure(EntityTypeBuilder<Permutation> builder)
        {
            builder.ToTable("Permutation", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_PermutationId");

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("bigint").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Cost).HasColumnName(@"Cost").HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Value).HasColumnName(@"Value").HasColumnType("varbinary(max)").IsRequired();
            builder.Property(x => x.SessionAlgorithmVariationId).HasColumnName(@"SessionAlgorithmVariationId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Iteration).HasColumnName(@"Iteration").HasColumnType("int").IsRequired();
            builder.Property(x => x.Trial).HasColumnName(@"Trial").HasColumnType("tinyint").IsRequired();
            builder.Property(x => x.Member).HasColumnName(@"Member").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Timestamp).HasColumnName(@"Timestamp").HasColumnType("datetime").IsRequired();

            // Foreign keys
            builder.HasOne(a => a.SessionAlgorithmVariation).WithMany(b => b.Permutations).HasForeignKey(c => c.SessionAlgorithmVariationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Permutation_SessionAlgorithmVariation");
        }
    }

}
// </auto-generated>