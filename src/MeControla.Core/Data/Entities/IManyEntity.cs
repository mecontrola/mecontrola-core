namespace MeControla.Core.Data.Entities
{
    public interface IManyEntity<TRoot, TTarget> : IForeignKeysManyEntity
        where TRoot : IEntity
        where TTarget : IEntity
    {
        TRoot Root { get; set; }
        TTarget Target { get; set; }
    }
}