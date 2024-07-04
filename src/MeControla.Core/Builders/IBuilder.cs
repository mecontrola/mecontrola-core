namespace MeControla.Core.Builders
{
    public interface IBuilder<out TObject>
        where TObject : class
    {
        TObject ToBuild();
    }
}