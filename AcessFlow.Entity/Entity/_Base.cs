namespace AcessFlow.Entity.Entity
{
    public class _Base: IHasSoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
