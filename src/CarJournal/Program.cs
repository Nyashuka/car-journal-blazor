using CarJournal.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddServices()
                    .AddSwagger();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
    }

    app.UseHttpsRedirection();

    app.Run();
}
