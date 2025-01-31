namespace AcessFlow.Entity.Interfaces
{
    public interface IHasSoftDelete
    {
        public bool IsDeleted { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
