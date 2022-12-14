// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QAP.DataContext
{
    // SessionAlgorithmVersion
    public class SessionAlgorithmVersionConfiguration : IEntityTypeConfiguration<SessionAlgorithmVersion>
    {
        public void Configure(EntityTypeBuilder<SessionAlgorithmVersion> builder)
        {
            builder.ToTable("SessionAlgorithmVersion", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SessionAlgorithmVersionId");

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.SessionId).HasColumnName(@"SessionId").HasColumnType("int").IsRequired();
            builder.Property(x => x.AlgorithmVersionId).HasColumnName(@"AlgorithmVersionId").HasColumnType("int").IsRequired();
            builder.Property(x => x.StateId).HasColumnName(@"StateId").HasColumnType("int").IsRequired();
            builder.Property(x => x.Configuration).HasColumnName(@"Configuration").HasColumnType("ntext").IsRequired(false);
            builder.Property(x => x.Seed).HasColumnName(@"Seed").HasColumnType("bigint").IsRequired(false);
            builder.Property(x => x.PermutationId).HasColumnName(@"PermutationId").HasColumnType("bigint").IsRequired(false);

            // Foreign keys
            builder.HasOne(a => a.AlgorithmVersion).WithMany(b => b.SessionAlgorithmVersions).HasForeignKey(c => c.AlgorithmVersionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SessionAlgorithmVersion_AlgorithmVersion");
            builder.HasOne(a => a.const_State).WithMany(b => b.SessionAlgorithmVersions).HasForeignKey(c => c.StateId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SessionAlgorithmVersion_State");
            builder.HasOne(a => a.Permutation).WithMany(b => b.SessionAlgorithmVersions).HasForeignKey(c => c.PermutationId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SessionAlgorithmVersion_Permutation");
            builder.HasOne(a => a.Session).WithMany(b => b.SessionAlgorithmVersions).HasForeignKey(c => c.SessionId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_SessionAlgorithmVersion_Session");
        }
    }

}
// </auto-generated>
