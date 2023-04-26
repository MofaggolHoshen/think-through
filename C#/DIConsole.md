## DI with console

```C#
/*
 * NuGet Packages
 * Microsoft.Extensions.Configuration
 * Microsoft.Extensions.Configuration.Json
 * Microsoft.Extensions.Logging
 */
private ServiceProvider ServiceCollections()
{
   var Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Env.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                   // .AddCommandLine(args)
                    .Build();


    var serviceProvider = new ServiceCollection()
           .AddTransient<TwOneService>()
           .AddScoped<StartupService>()
           .AddSingleton<IConfiguration>(Configuration)
           //.AddHttpContextAccessor()
          .AddTransient<IHttpContextAccessor>((sp) =>
           {
               IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
               httpContextAccessor.HttpContext = new DefaultHttpContext();
               httpContextAccessor.HttpContext.Request.Headers.Add("key", "BlaBla");
               return httpContextAccessor;
           })
          //.AddHttpClient()
           .AddLogging()
           .BuildServiceProvider();

    return serviceProvider;
}
```

Read more about DI container [here](https://stackoverflow.com/questions/62489732/blazor-which-is-better-inject-or-cascading-value/62502222#62502222)
