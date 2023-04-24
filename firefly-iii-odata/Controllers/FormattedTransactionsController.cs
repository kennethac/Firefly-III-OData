using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models.Formatted;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace firefly_iii_odata.Controllers;

public class FormattedTransactionsController : ODataController
{
    private readonly FireflyContext _dbContext;

    public FormattedTransactionsController(FireflyContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    public IQueryable<FormattedTransaction> Get()
    {
        return _dbContext
            .TransactionJournals
            .Include(j => j.Transactions)
            .Include(j => j.TransactionGroup)
            .Where(t => t.UserId == HttpContext.FireflyUserId())
            .Select(j => new FormattedTransaction
            {
                GroupId = j.TransactionGroupId,
                GroupTitle = j.TransactionGroup == null ? "" : j.TransactionGroup.Title,
                JournalDate = j.Date,
                JournalId = j.Id,
                JournalDescription = j.Description,
                DestinationAccountId = j.Transactions.First(t => t.Amount > 0).AccountId,
                DestinationAccountName = j.Transactions.First(t => t.Amount > 0).Account.Name,
                SourceAccountId = j.Transactions.First(t => t.Amount < 0).AccountId,
                SourceAccountName = j.Transactions.First(t => t.Amount < 0).Account.Name,
                Amount = Math.Abs(j.Transactions.First(t => t.Amount < 0).Amount),
                BudgetId = j.BudgetTransactionJournals.Any() ? j.BudgetTransactionJournals.First().Id : null,
                BudgetName = j.BudgetTransactionJournals.Any() ? j.BudgetTransactionJournals.First().Budget.Name : null,
                TransactionTypeId = j.TransactionTypeId,
                TransactionType = j.TransactionType.Type
            });
    }
}