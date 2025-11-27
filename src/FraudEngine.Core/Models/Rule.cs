namespace FraudEngine.Core.Models
{
    public record Rule
    {
        public string Id { get; init; } = string.Empty;
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public bool Enabled { get; init; } = true;
        // A very lightweight rule configuration - typed as simple properties for this sample
        public decimal? AmountGreaterThan { get; init; }
        public int? MaxTransactionsPerMinute { get; init; }
        public string? CountryMismatch { get; init; }
    }
}