using System;
using Xunit;
using Shouldly;
using YYY.Microservices.Domain.SeedWork;

namespace SeedWorkTest
{
    public class EntityEqualTest
    {
        [Fact]
        public void GuidTest()
        {
            Guid guid = Guid.NewGuid();
            var r1 = new Overwrite<Guid>(guid);
            var r2 = new Overwrite<Guid>(guid);
            var x = r1 == r2;
            x.ShouldBe(true);
        }
        [Fact]
        public void IntTest()
        {
            var r1 = new Overwrite<int>(1);
            var r2 = new Overwrite<int>(1);
            var x = r1 == r2;
            x.ShouldBe(true);
        }
        [Fact]
        public void LongTest()
        {
            var r1 = new Overwrite<long>(2147483648);
            var r2 = new Overwrite<long>(2147483648);
            var x = r1 == r2;
            x.ShouldBe(true);
        }

        [Fact]
        public void StandardTest()
        {
            var r1 = new Standard<long>(2147483648);
            var r2 = new Standard<long>(2147483648);
            var x = r1 == r2;
            x.ShouldBe(false);
        }
    }
    public class Overwrite<TKey> : Entity<TKey> where TKey : struct
    {
        public Overwrite(TKey guid)
        {
            Id = guid;
        }
    }
    public class Standard<TKey> where TKey : struct
    {
        public TKey Id { private set; get; }
        public Standard(TKey guid)
        {
            Id = guid;
        }
    }
}
