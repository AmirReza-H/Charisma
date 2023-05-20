using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.OrderDomain.Entities;

namespace Store.Infrastructure.Persistence.Contexts.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
           builder.HasMany(x=>x.Products)
                .WithMany(x=>x.Orders)
                .UsingEntity<OrderLine>
                   (
                      j => j
                        .HasOne(p => p.Product)
                        .WithMany(o => o.OrderLines)
                        .HasForeignKey(ol => ol.ProductId)
                        .OnDelete(DeleteBehavior.Restrict),
                      j => j
                        .HasOne(hs => hs.Order)
                        .WithMany(o => o.OrderLines)
                        .HasForeignKey(c => c.OrderId)
                        .OnDelete(DeleteBehavior.Restrict),
                      j =>
                      {
                          j.HasKey(x => x.Id);
                          j.HasIndex(x => new { x.OrderId, x.ProductId }).IsUnique();
                      }
                    );
        }
    }
}
