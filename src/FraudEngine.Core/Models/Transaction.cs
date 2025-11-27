using System;
using System.ComponentModel.DataAnnotations;


namespace FraudEngine.Core.Models
{
  public record Transaction
 {
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    public string AccountId { get; init; } = string.Empty;
    public decimal Amount { get; init; }
    public string Currency { get; init; } = "USD";
    public string Merchant { get; init; } = string.Empty;
    public string MerchantCountry { get; init; } = string.Empty;
    public string MerchantCategory { get; init; } = string.Empty; // MCC
    public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;
    public string RawSource { get; init; } = string.Empty; // optional raw payload
  }
}