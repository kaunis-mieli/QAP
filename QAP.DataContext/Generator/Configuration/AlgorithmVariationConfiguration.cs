// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QAP.DataContext
{
    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    // AlgorithmVariation
    public class AlgorithmVariationConfiguration : IEntityTypeConfiguration<AlgorithmVariation>
    {
        public void Configure(EntityTypeBuilder<AlgorithmVariation> builder)
        {
            builder.ToTable("AlgorithmVariation", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_AlgorithmVariationId");

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AlgorithmVersionId).HasColumnName(@"AlgorithmVersionId").HasColumnType("int").IsRequired();
            builder.Property(x => x.ConfigurationId).HasColumnName(@"ConfigurationId").HasColumnType("int").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.Configuration).WithMany(b => b.AlgorithmVariations).HasForeignKey(c => c.ConfigurationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AlgorithmVariation_Configuration");
            builder.HasOne(a => a.const_AlgorithmVersion).WithMany(b => b.AlgorithmVariations).HasForeignKey(c => c.AlgorithmVersionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AlgorithmVariation_AlgorithmVersion");
        }
    }

}
// </auto-generated>
