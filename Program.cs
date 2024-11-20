using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;
using umbraco_assignment.Business;
//-------------------------------tillagt för azureBlob-------------------------
using Umbraco.StorageProviders.AzureBlob;
using umbraco_assignment.Business.Services.Interfaces;
using umbraco_assignment.Business.Services;
using umbraco_assignment.Business.ScheduledJob;
//-----------------------------------------------------------------------------

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//---------------------------------------- Profiler för lokala databaser --------------------------------------
var environmentName = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.GetConnectionString("umbracoDbDSN");
//--------------------------------------------------------------------------------------------------------------

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    //-------------------------------tillagt för azureBlob-------------------------
    .AddAzureBlobMediaFileSystem()
    //-----------------------------------------------------------------------------
    .Build();


builder.Services.AddSingleton<IModelsGenerator, CustomModelsGenerator>();
builder.Services.AddScoped<ISitemapService, SitemapService>();
builder.Services.AddTransient<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ReviewCleanupJob>();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
