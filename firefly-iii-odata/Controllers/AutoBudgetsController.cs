using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class AutoBudgetsController : ODataController
{
    private readonly FireflyContext _dbContext;

    public AutoBudgetsController(FireflyContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    public IQueryable<AutoBudget> Get()
    {
        return _dbContext.AutoBudgets.Where(b => b.Budget.UserId == HttpContext.FireflyUserId());;
    }
}