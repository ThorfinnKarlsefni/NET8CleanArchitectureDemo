using LogisticsManagementSystem.Api;
using LogisticsManagementSystem.Application;
using LogisticsManagementSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandleMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
