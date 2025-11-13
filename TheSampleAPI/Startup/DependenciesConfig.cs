namespace TheSampleAPI.Startup
{
    public static class DependenciesConfig
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            // Register application services here
            builder.Services.AddOpenApiServices();
        }
    }
}
