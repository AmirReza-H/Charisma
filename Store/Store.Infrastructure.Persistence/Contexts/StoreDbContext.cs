using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Store.Domain.Common;
using Store.Infrastructure.Persistence.Extensions;
using System.Linq.Expressions;
using System.Reflection;

namespace Store.Infrastructure.Persistence.Contexts
{
    public class StoreDbContext : DbContext
    {

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            var entitiesAssembly = typeof(BaseEntity).Assembly;
            modelBuilder.RegisterAllEntities<BaseEntity>(entitiesAssembly);
        }
    }
}
