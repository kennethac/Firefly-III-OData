using firefly_iii_odata.Data;
using firefly_iii_odata.Models.Formatted;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class BudgetLimitsController : ODataController
{
    private readonly FireflyContext _dbContext;

    public BudgetLimitsController(FireflyContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    public IQueryable<FormattedBudgetLimit> Get()
    {
        var budgetsWithTransactions = Queryable.Join(
            _dbContext.Budgets
            , _dbContext.Transactions
                    .Where(t => t.Amount > 0)
                    .Join(_dbContext.TransactionJournals, t => t.TransactionJournalId, j => j.Id, (t, j) => new { Amount = t.Amount, Date = j.Date, JournalId = j.Id })
                    .Join(_dbContext.BudgetTransactionJournals, o => o.JournalId, btj => btj.TransactionJournalId, (o, btj) => new { Amount = o.Amount, Date = o.Date, btj.BudgetId }),
                    b => b.Id,
                    i => i.BudgetId,
                    (b, i) => new { i.BudgetId, i.Amount, i.Date });

        var sumWithPeriod = _dbContext.BudgetLimits
            .Select(l => new FormattedBudgetLimit
            {
                BudgetName = l.Budget.Name,
                Amount = l.Amount,
                BudgetId = l.BudgetId,
                EndDate = l.EndDate,
                StartDate = l.StartDate,
                Id = l.Id,
                Period = l.Period,
                Spent = budgetsWithTransactions
                    .Where(t =>
                        t.BudgetId == l.BudgetId
                        && DateOnly.FromDateTime(t.Date) >= l.StartDate
                        && DateOnly.FromDateTime(t.Date) < l.EndDate)
                    .Sum(t => t.Amount)
            });

        return sumWithPeriod;
    }
}