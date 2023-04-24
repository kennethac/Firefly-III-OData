using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models;
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
    public IQueryable<BudgetLimit> Get()
    {
        return _dbContext.BudgetLimits.Where(a => a.Budget.UserId == HttpContext.FireflyUserId()); ;
    }
}