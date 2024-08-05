
using CarJournal.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddRepositories()
                    .AddRepositories()
                    .AddServices()
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

    app.UseExceptionHandler("/error");
    app.MapControllers();
    app.Run();
}
