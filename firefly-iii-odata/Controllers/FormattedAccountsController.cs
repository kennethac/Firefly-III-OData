using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models.Formatted;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class FormattedAccountsController : ODataController
{
    private readonly FireflyContext _dbContext;
    private readonly ILogger<AccountsController> _logger;

    public FormattedAccountsController(FireflyContext dbContext, ILogger<AccountsController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [EnableQuery]
    public IQueryable<FormattedAccount> Get()
    {
        return _dbContext
            .Accounts
            .Where(a => a.UserId == HttpContext.FireflyUserId())
            .Select(a => new FormattedAccount
            {
                AccountType = a.AccountType.Type,
                AccountTypeId = a.AccountTypeId,
                Active = a.Active,
                Id = a.Id,
                VirtualBalance = a.VirtualBalance,
                Name = a.Name,
                Order = a.Order,
                CurrentBalance = a.Transactions.Sum(t => t.Amount)
            });
    }
}