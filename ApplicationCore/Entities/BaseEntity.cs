namespace ApplicationCore.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
