
using Core.Entities;
using Shouldly;
using Xunit;

namespace MusicStreamingAppTesting.DomainTesting.Entities;

public class EntityTests
{
    private class TestEntity : Entity
    {
        public void PublicEnsureNotNull<T>(T value, string name) => EnsureNotNull(value, name);
    }

    [Fact]
    public void Constructor_ShouldInitialize_DefaultValues()
    {
        var entity = new TestEntity();

        entity.Id.ShouldNotBe(Guid.Empty);
        entity.CreationDate.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow);
        entity.UpdateDate.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow);
        entity.IsDeleted.ShouldBeFalse();
        entity.DeletedDate.ShouldBeNull();
        entity.CreatedBy.ShouldBeNull();
        entity.UpdatedBy.ShouldBeNull();
    }

    [Fact]
    public void MarkAsDeleted_ShouldSetDeletedFlags_AndUser()
    {
        var userId = Guid.NewGuid();
        var entity = new TestEntity();

        entity.MarkAsDeleted(userId);

        entity.IsDeleted.ShouldBeTrue();
        entity.DeletedDate.ShouldNotBeNull();
        entity.UpdatedBy.ShouldBe(userId);
    }

    [Fact]
    public void UpdateAuditInfo_ShouldUpdate_UpdateDate_AndUser()
    {
        var userId = Guid.NewGuid();
        var entity = new TestEntity();

        entity.UpdateAuditInfo(userId);

        entity.UpdateDate.ShouldBeInRange(DateTime.UtcNow.AddSeconds(-1), DateTime.UtcNow);
        entity.UpdatedBy.ShouldBe(userId);
    }
    

    [Fact]
    public void EnsureNotNull_ShouldThrow_WhenNull()
    {
        var entity = new TestEntity();

        Should.Throw<ArgumentNullException>(() => entity.PublicEnsureNotNull<object>(null, "param"))
            .Message.ShouldContain("param");
    }
}
