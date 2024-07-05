namespace MeControla.Core.Data.Entities
{
    public interface IForeignKeysManyEntity
    {
        long RootId { get; set; }
        long TargetId { get; set; }
    }
}