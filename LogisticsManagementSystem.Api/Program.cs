
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
{
    app.UseExceptionHandler();
    app.UseInfrastructure();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var seedDataInitializer = services.GetRequiredService<SeedDataInitializer>();
        seedDataInitializer.Initialize();
    }

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}