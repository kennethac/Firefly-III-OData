using System.Security.Claims;
using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class AccountsController : ODataController
{
    private readonly FireflyContext _dbContext;
    private readonly ILogger<AccountsController> _logger;

    public AccountsController(FireflyContext dbContext, ILogger<AccountsController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [EnableQuery]
    public IQueryable<Account> Get()
    {
        return _dbContext.Accounts.Where(a => a.UserId == HttpContext.FireflyUserId());
    }
}