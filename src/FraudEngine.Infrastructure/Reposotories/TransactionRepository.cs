using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudEngine.Core.Models;
using FraudEngine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FraudEngine.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FraudDbContext _db;

        public TransactionRepository(FraudDbContext db)
        {
            _db = db;
        }

        public async Task AddTransactionAsync(Transaction tx)
        {
            await _db.Transactions.AddAsync(tx);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(
            string accountId, DateTimeOffset from, DateTimeOffset to)
        {
            return await _db.Transactions
                .Where(t => t.AccountId == accountId 
                         && t.Timestamp >= from 
                         && t.Timestamp <= to)
                .OrderByDescending(t => t.Timestamp)
                .ToListAsync();
        }

        public async Task AddAlertsAsync(IEnumerable<Alert> alerts)
        {
            if (alerts == null || !alerts.Any())
                return;

            await _db.Alerts.AddRangeAsync(alerts);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Alert>> GetAlertsAsync(string? accountId = null)
        {
            var query = _db.Alerts.AsQueryable();

            if (!string.IsNullOrEmpty(accountId))
            {
                query = query.Where(a => a.AccountId == accountId);
            }

            return await query
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
        }
    }
}
