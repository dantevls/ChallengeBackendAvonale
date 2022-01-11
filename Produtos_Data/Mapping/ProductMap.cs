using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos_Domain.Entities;

namespace Produtos_Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(50);
            builder.Property(p => p.Valor_Unitario);
            builder.Property(p => p.Qtde_estoque);
        }
    }
}
