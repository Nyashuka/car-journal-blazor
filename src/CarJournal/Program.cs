using System.Security.Cryptography;

using CarJournal.Components;
using CarJournal.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddRepositories()
                    .AddInfrastructure()
                    .AddServices()
                    .AddRazor()
                    .AddSwagger()
                    .AddControllers();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.IncludeDeveloperServices();
    }

    //app.UseStaticFiles();
    //app.UseHttpsRedirection();

    app.UseExceptionHandler("/error");

    app.UseStaticFiles();
    app.UseAntiforgery();
    //app.MapControllers();
    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    app.Run();
}
