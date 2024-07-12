namespace CleanArchMvc.Domain.Entities
{
    // In this scenario it doesn't really make sense, it's just for studying, here we could place more useful information, like "created by", "modified by", etc. Fields which all entities on our database would have in common.
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
