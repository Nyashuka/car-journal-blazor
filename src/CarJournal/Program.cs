
using CarJournal.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddServices()
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
    app.MapControllers();
    app.Run();
}
