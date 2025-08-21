namespace Market.Core.SearchObjects
{
    public class BaseSearchObject
    {
        public string? SearchFilter { get; set; }
        public Guid? MarketId { get; set; }
    }
}