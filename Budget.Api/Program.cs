using AspNetCoreRateLimit;
using Budget.Api.Common;
using Budget.Api.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
services.ConfigureCors();
services.ConfigureIISIntegration();
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.ConfigureSqlContext(configuration);
services.Configure<ApiBehaviorOptions>(options =>
{
    // suppressing a default model state validation that is implemented
    // due to the existence of the [ApiController] attribute in all
    // API controllers
    options.SuppressModelStateInvalidFilter = true;
});
services.AddMemoryCache();
services.ConfigureRateLimitingOptions();
services.AddHttpContextAccessor();
services.AddAuthentication();
services.ConfigureIdentity();
services.ConfigureJWT(configuration);
services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors(BudgetConstants.CorsPolicy);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
