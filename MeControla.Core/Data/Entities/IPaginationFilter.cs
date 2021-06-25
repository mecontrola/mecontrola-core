namespace MeControla.Core.Data.Entities
{
    public interface IPaginationFilter
    {
        int PageNumber { get; }
        int PageSize { get; }
    }
}