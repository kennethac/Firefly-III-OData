using firefly_iii_odata.Crypto;
using firefly_iii_odata.Data;
using firefly_iii_odata.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConfiguration(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("Firefly");
var serverVersion = ServerVersion.AutoDetect(connectionString);

var appKey = builder.Configuration["AppKey"] ?? throw new Exception("No AppKey found in configuration");

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

builder.Services.AddSingleton<RsaSecurityKey>(provider =>
{
    var db = provider.GetRequiredService<FireflyContext>();
    var privateKeyLoader = new RsaSecurityKeyLoader(new firefly_iii_odata.Config.AppKeyHolder { AppKey = appKey }, db);
    return privateKeyLoader.LoadKey();
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    SecurityKey rsa = builder.Services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();
    // options.Audience = "1";
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = "https://firefly2.exultantsoftware.com",
        ValidIssuer = "https://firefly2.exultantsoftware.com",
        IssuerSigningKey = rsa,
        RequireSignedTokens = true,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});

builder
    .Services
    .AddControllers()
    // .AddMvcOptions(opt => opt.Filters.Add())
    .AddOData(opt =>
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

app.UseAuthentication();
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