using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Template.API.Mappers;
using Template.Domain.Repositories;
using Template.Domain.Services;
using Template.Infrastructure.Context;
using Template.Infrastructure.Mappers;
using Template.Infrastructure.Repositories;
using Template.API.HealthChecks;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(setup =>
{
	setup.ReturnHttpNotAcceptable = true; // Ensures people send in the correct Accept header. We only support json. If we need more add OutputFormatters
})
.ConfigureApiBehaviorOptions(setup =>
{
	setup.InvalidModelStateResponseFactory = context =>
	{
		var problemDetailsFactory = context.HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
		var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);

		problemDetails.Detail = "See the errors field for details";
		problemDetails.Instance = context.HttpContext.Request.Path;

		var actionExecutingContext = context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;


		if ((context.ModelState.ErrorCount > 0) && (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
		{
			problemDetails.Type = ""; // Find correct link
			problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
			problemDetails.Title = "One or more validation errors occured";

		return new UnprocessableEntityObjectResult(problemDetails)
		{
			ContentTypes = { "application/problem+json" }
		};
		}

		problemDetails.Status = StatusCodes.Status400BadRequest;
		problemDetails.Title = "One or more errors on input occured";

		return new BadRequestObjectResult(problemDetails)
		{
			ContentTypes = { "application/problem+json" }
		};
	};
});
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddSingleton<ReadyHealthCheck>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IFinanceUnitMapper, FinanceUnitMapper>();
builder.Services.AddScoped<IEfMapper, EfMapper>();
builder.Services.AddScoped<IFinanceUnitRepository, FinanceUnitRepository>();
builder.Services.AddScoped<IFinanceUnitService, FinanceUnitService>();
//builder.Services.AddSwaggerGen(options => options.())
builder.Services.AddDbContext<FinanceUnitContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
builder.Services.AddHealthChecks()
	.AddCheck<ReadyHealthCheck>("Ready", HealthStatus.Unhealthy, tags: new[] { "Ready" })
	.AddCheck<LiveHealthCheck>("Live", HealthStatus.Unhealthy, tags: new[] { "Live" });

var app = builder.Build();

app.MapHealthChecks("/healthz/live", new HealthCheckOptions
{
	// Predicate = healthCheck => healthCheck.Tags.Contains("Live")
	Predicate = _ => true // this will call all health checks (including readiness).
});

app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
{
	Predicate = healthCheck => healthCheck.Tags.Contains("Ready")
});



// perform something startup heavy
var readyHealthCheck = app.Services.GetService<ReadyHealthCheck>();
if (readyHealthCheck != null)
{
	readyHealthCheck.IsReady = true;
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
	app.UseExceptionHandler(appBuilder =>
	{
		appBuilder.Run(async context =>
		{
			context.Response.StatusCode = 500;
			await context.Response.WriteAsync("An unexpected fault happened. Try again later");
		});

	});
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
