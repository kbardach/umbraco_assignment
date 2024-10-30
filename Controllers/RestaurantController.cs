using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbraco_assignment.Models.ViewModels;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Controllers
{
    public class RestaurantController : RenderController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public RestaurantController(ILogger<RestaurantController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public override IActionResult Index()
        {
            var restaurantPage = CurrentPage as Restaurant;

            if (restaurantPage != null)
            {
                var model = new RestaurantPageViewModel(restaurantPage, _umbracoContextAccessor);
                return View(nameof(Restaurant).ToLower(), model);
            }

            return NotFound();
        }
    }
}
