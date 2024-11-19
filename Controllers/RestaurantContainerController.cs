using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace umbraco_assignment.Controllers
{
    public class RestaurantContainerController : RenderController
    {
        public RestaurantContainerController(
            ILogger<RestaurantContainerController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        { }

        public override IActionResult Index()
        {
            var currentCulture = System.Globalization.CultureInfo.CurrentUICulture.Name;
            string redirectUrl = currentCulture == "sv" ? "/sok" : "/en/search";
            return Redirect(redirectUrl);
        }
    }
}
