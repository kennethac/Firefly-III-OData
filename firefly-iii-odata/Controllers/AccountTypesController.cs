using firefly_iii_odata.Data;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class AccountTypesController : ODataController
{
    private readonly FireflyContext _dbContext;

    public AccountTypesController(FireflyContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    public IQueryable<AccountType> Get()
    {
        return _dbContext.AccountTypes;
    }
}