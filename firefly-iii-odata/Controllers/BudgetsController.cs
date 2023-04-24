using firefly_iii_odata.Data;
using firefly_iii_odata.Extensions;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

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
        return _dbContext
            .Budgets
            .Include(b => b.AutoBudgets)
            .Where(b => b.UserId == HttpContext.FireflyUserId());
    }

    public async Task<ActionResult<IEnumerable<AutoBudget>>> GetAutoBudgets([FromRoute] uint key)
    {
        var result = await _dbContext
            .Budgets
            .Where(b => b.UserId == HttpContext.FireflyUserId() && b.Id == key)
            .SelectMany(b => b.AutoBudgets)
            .ToListAsync();

        if (result is null || !result.Any()) return NotFound();
        return Ok(result);
    }
}