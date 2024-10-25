using CarJournal.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

// configure the dependency injection
var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContextFactory<CarJournalDbContext>(options =>
    options.UseNpgsql(DbConstants.ConnectionString));

    builder.Services.AddScoped<CarJournalDbContext>(provider =>
        provider.GetRequiredService<IDbContextFactory<CarJournalDbContext>>().CreateDbContext());

    builder.Services.AddRepositories()
                    .AddInfrastructure()
                    .AddServices()
                    .AddRazor()
                    .AddMudServices()
                    .AddSwagger()
                    .AddControllers();

    builder.Services.AddAuthenticationCore();
}

// Configure the HTTP request pipeline.
var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.IncludeDeveloperServices();
        app.UseExceptionHandler("/Error");
    }

    app.UseStaticFiles();
    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.SetupHangFire();

    app.UseAuthentication();
    app.UseAuthorization();

    app.Run();
}