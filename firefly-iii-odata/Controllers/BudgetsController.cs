using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class BudgetsController : ODataController
{
    private readonly FireflyContext _dbContext;

    public BudgetsController(FireflyContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    public IQueryable<Budget> Get()
    {
        return _dbContext.Budgets.Where(b => b.UserId == HttpContext.FireflyUserId());;
    }
}