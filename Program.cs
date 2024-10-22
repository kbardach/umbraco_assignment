using Umbraco.Cms.Infrastructure.ModelsBuilder.Building;
using umbraco_assignment.Business;
//-------------------------------tillagt f�r azureBlob-------------------------
using Umbraco.StorageProviders.AzureBlob;
//-----------------------------------------------------------------------------

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//---------------------------------------- Profiler f�r lokala databaser --------------------------------------
var environmentName = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);
builder.Configuration.GetConnectionString("umbracoDbDSN");
//--------------------------------------------------------------------------------------------------------------

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    //-------------------------------tillagt f�r azureBlob-------------------------
    .AddAzureBlobMediaFileSystem()
    //-----------------------------------------------------------------------------
    .Build();


builder.Services.AddSingleton<IModelsGenerator, CustomModelsGenerator>();

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
