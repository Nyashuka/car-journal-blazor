
public static class WebApplicationExtensions
{
    public static WebApplication InitializeDatabase(
        this WebApplication app)
    {
        // wait on database connect   

        return app;
    }
}