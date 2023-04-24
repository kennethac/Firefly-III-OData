using firefly_iii_odata.Data;
using firefly_iii_odata.Models.Formatted;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class FormattedBudgetLimitsController : ODataController
{
    private readonly FireflyContext _dbContext;

    public FormattedBudgetLimitsController(FireflyContext dbContext)
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
            .Join(_dbContext.AutoBudgets,
            bl => bl.BudgetId,
            ab => ab.BudgetId,
            (budgetLimits, autoBudget) => new { budgetLimits, autoBudget })
            .Select(l => new FormattedBudgetLimit
            {
                BudgetName = l.budgetLimits.Budget.Name,
                CurrentPeriodAmount = l.budgetLimits.Amount,
                BudgetId = l.budgetLimits.BudgetId,
                EndDate = l.budgetLimits.EndDate,
                StartDate = l.budgetLimits.StartDate,
                Id = l.budgetLimits.Id,
                CurrentPeriodSpent = budgetsWithTransactions
                    .Where(t =>
                        t.BudgetId == l.budgetLimits.BudgetId
                        && DateOnly.FromDateTime(t.Date) >= l.budgetLimits.StartDate
                        && DateOnly.FromDateTime(t.Date) < l.budgetLimits.EndDate)
                    .Sum(t => t.Amount),
                Period = l.autoBudget == null ? null : l.autoBudget.Period,
                PeriodAmount = l.autoBudget == null ? null : l.autoBudget.Amount,
                RollsOver = l.autoBudget == null ? null : l.autoBudget.AutoBudgetType == 2
            });

        return sumWithPeriod;
    }
}