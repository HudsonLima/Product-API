using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProductAPI.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Domain.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
        {
            builder.ToTable("tb_product");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Unit)
                .HasColumnName("Unit");

            builder.Property(c => c.Quantity)
                .HasColumnName("Quantity");


            builder.Property(c => c.Price)
                .HasColumnName("Price");


            builder.Property(c => c.Active)
                .HasColumnName("Active");


            builder.Property(c => c.Brand_Id)
                .IsRequired()
                .HasColumnName("Brand_Id");
        }
    }
}
