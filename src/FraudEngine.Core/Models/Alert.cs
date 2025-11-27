using System;


namespace FraudEngine.Core.Models
{
    public record Alert
    {
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid TransactionId { get; init; }
    public string AccountId { get; init; } = string.Empty;
    public string RuleId { get; init; } = string.Empty;
    public string RuleName { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public decimal Score { get; init; } = 0; // 0..1
    }
}