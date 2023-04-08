using firefly_iii_odata.Data;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Firefly");
var serverVersion = ServerVersion.AutoDetect(connectionString);

// Add services to the container.
builder.Services.AddDbContext<FireflyContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString, serverVersion);

        if (builder.Environment.IsDevelopment())
        {
            // The following three options help with debugging, but should
            // be changed or removed for production.
            dbContextOptions.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    });


builder.Services.AddControllers().AddOData(opt =>
{
    opt.AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .Count();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseODataRouteDebug();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:6001");

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Budget>("Budgets");
    builder.EntitySet<Transaction>("Transactions");
    builder.EntitySet<BudgetLimit>("BudgetLimits");
    builder.EntitySet<Account>("Accounts");
    builder.EntitySet<AccountType>("AccountTypes");
    builder.EntitySet<TransactionType>("TransactionTypes");
    return builder.GetEdmModel();
}