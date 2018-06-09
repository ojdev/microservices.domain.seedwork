using JetBrains.Annotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using YYY.Microservices.Domain.SeedWork;

namespace SeedWorkTest
{
    public class SelectEntityTest
    {
        private ADbContext DbContext()
        {
            var options = new DbContextOptionsBuilder<ADbContext>().UseInMemoryDatabase($"{Guid.NewGuid()}").Options;
            var context = new ADbContext(options);
            return context;
        }
        [Fact]
        public void Select()
        {
            using (var db = DbContext())
            {
                db.Bs.Add(new B());
                db.As.Add(new A());
                var domainEntities = db.ChangeTracker.Entries<IEntity>();
                domainEntities.Count().ShouldBe(1);
            }
        }
    }
    public class A : Entity<Guid>
    {

    }
    public class B
    {
        public int Id { set; get; }
    }
    public class ADbContext : DbContext
    {
        public DbSet<A> As { set; get; }
        public DbSet<B> Bs { set; get; }


        public ADbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
