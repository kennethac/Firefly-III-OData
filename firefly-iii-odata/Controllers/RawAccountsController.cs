using System.Security.Claims;
using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class RawAccountsController : ODataController
{
    private readonly FireflyContext _dbContext;
    private readonly ILogger<RawAccountsController> _logger;

    public RawAccountsController(FireflyContext dbContext, ILogger<RawAccountsController> logger)
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