using System.Security.Cryptography;

using CarJournal.Components;
using CarJournal.DependencyInjection;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddRepositories()
                    .AddInfrastructure()
                    .AddServices()
                    .AddRazor()
                    .AddSwagger()
                    .AddControllers();

    builder.Services.AddDbContext<CarJournalDbContext>(options =>
            options.UseNpgsql(DbConstants.ConnectionString));
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.IncludeDeveloperServices();
    }

    app.UseStaticFiles();

    app.UseExceptionHandler("/error");

    app.UseStaticFiles();
    app.UseAntiforgery();

    //app.MapControllers();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
    app.Run();
}
