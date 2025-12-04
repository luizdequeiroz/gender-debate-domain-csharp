namespace GenderDebate.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected init; } = Guid.NewGuid();
        public DateTime CreatedAt { get; protected init; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; protected set; }

        protected void Touch()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
