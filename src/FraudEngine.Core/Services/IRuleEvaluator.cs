using FraudEngine.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace FraudEngine.Core.Services
{
    public interface IRuleEvaluator
    {
      Task<IEnumerable<Alert>> EvaluateAsync(Transaction tx);
    }
}