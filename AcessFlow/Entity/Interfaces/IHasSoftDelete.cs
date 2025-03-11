namespace AcessFlowService.Entity.Interfaces
{
    public interface IHasSoftDelete
    {
        public bool IsDeleted { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
