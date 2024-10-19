using CarJournal.DependencyInjection;
using CarJournal.Jobs;

using Hangfire;

using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContextFactory<CarJournalDbContext>(options =>
    options.UseNpgsql(DbConstants.ConnectionString));

    builder.Services.AddScoped<CarJournalDbContext>(provider =>
        provider.GetRequiredService<IDbContextFactory<CarJournalDbContext>>().CreateDbContext());

    // builder.Services.AddDbContext<CarJournalDbContext>(options =>
    //         options.UseNpgsql(DbConstants.ConnectionString), ServiceLifetime.Scoped);

    builder.Services.AddRepositories()
                    .AddInfrastructure()
                    .AddServices()
                    .AddRazor()
                    .AddMudServices()
                    .AddSwagger()
                    .AddControllers();

    builder.Services.AddAuthenticationCore();


    // builder.Services.AddAuthorization(options =>
    // {
    //     options.AddPolicy("admin", policy =>
    //         policy.RequireRole("admin"));
    // });
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.IncludeDeveloperServices();
        app.UseExceptionHandler("/Error");
    }

    app.UseStaticFiles();
    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    var options = new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.Local  // Використання налаштованого часового поясу
        };
    app.UseHangfireDashboard();
    RecurringJob.AddOrUpdate<DailyTrackingJob>(
        "tracking",
        job => job.ExecuteAsync(),
        "14 13 * * *",
        options
    );

    app.UseAuthentication();
    app.UseAuthorization();

    app.Run();
}