namespace MeControla.Core.Data.Enums
{
    public abstract class BaseEnumItemDto : IEnumDto
    {
        public uint Id { get; set; }
        public string Value { get; set; }
    }
}