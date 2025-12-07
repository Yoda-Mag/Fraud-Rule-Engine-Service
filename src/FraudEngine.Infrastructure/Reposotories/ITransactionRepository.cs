using FraudEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FraudEngine.Infrastructure.Repositories
{
public interface ITransactionRepository
{
Task AddTransactionAsync(Transaction tx);
Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(string accountId, DateTimeOffset from, DateTimeOffset to);
Task AddAlertsAsync(IEnumerable<Alert> alerts);
Task<IEnumerable<Alert>> GetAlertsAsync(string? accountId = null);
}
}