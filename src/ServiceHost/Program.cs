using Microsoft.Extensions.Options;
using NLog;
using NLog.Web;
using ShopManagement.Infrastructure.ConfigureServices;
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region try Add Services

try
{
    #region NLog

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    builder.Services.AddSingleton<ILoggerManger, LoggerManger>();
    builder.Services.AddSingleton(typeof(ILoggerManger<>), typeof(LoggerManger<>));
    #endregion /NLog

    #region Routing

    builder.Services.AddRouting(op =>
    {
        op.LowercaseUrls = true;
        op.LowercaseQueryStrings = true;
    });

    #endregion /Routing

    builder.Services.AddRazorPages();
    builder.Services.AddControllers();
    builder.Services.ShopManagementBootstrapper(builder.Configuration);
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    // Custom LogManger
  

    #region  ApplicationSettings 

    builder.Services.Configure<ApplicationSettings>
            (builder.Configuration.GetSection(ApplicationSettings.KeyName))
        .AddSingleton
        (serviceType =>
        {
            var result =
                // GetRequiredService()-> using Microsoft.Extensions.DependencyInjection;
                serviceType.GetRequiredService
                <IOptions
                    <ApplicationSettings>>().Value;

            return result;
        });

    #endregion /ApplicationSettings

    // Add Application And Database Services

}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}

#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();


app.Run();
