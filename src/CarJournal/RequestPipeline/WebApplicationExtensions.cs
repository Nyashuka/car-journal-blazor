
public static class WebApplicationExtensions
{
    public static WebApplication InitializeDatabase(
        this WebApplication app)
    {
        // wait on database connect

        return app;
    }
    public static WebApplication IncludeDeveloperServices(
            this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        
        return app;
    }
}