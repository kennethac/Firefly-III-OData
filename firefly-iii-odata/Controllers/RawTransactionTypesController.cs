using firefly_iii_odata.Data;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace firefly_iii_odata.Controllers;

public class RawTransactionTypesController : ODataController
{
    private readonly FireflyContext _dbContext;

    public RawTransactionTypesController(FireflyContext dbContext)
    {
        _dbContext = dbContext;
    }

    [EnableQuery]
    public IQueryable<TransactionType> Get()
    {
        return _dbContext.TransactionTypes;
    }
}