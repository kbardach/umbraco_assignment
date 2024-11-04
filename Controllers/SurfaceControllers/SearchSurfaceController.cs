using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using umbraco_assignment.Business.Services.Interfaces;
using umbraco_assignment.Models.PublishedModels;
using umbraco_assignment.Models.ViewModels;

namespace umbraco_assignment.Controllers.SurfaceControllers
{
    public class SearchSurfaceController : SurfaceController
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public SearchSurfaceController(IRestaurantService restaurantService, IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _restaurantService = restaurantService;
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchRestaurants(string query)
        {
            if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            {
                var content = umbracoContext.Content;

                var settingsPage = content.GetAtRoot().DescendantsOrSelf<Settings>().FirstOrDefault();
                var searchPage = settingsPage?.SearchPage as Search; // TODO om searchpage är null fix
                var searchPageUrl = searchPage.Url();
                
                return Redirect($"{searchPageUrl}?query={Uri.EscapeDataString(query)}");
            }

            return View();
        }

    }
}
