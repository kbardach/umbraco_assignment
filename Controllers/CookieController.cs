using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbraco_assignment.Models.PublishedModels;
using umbraco_assignment.Models.ViewModels;

namespace umbraco_assignment.Controllers
{
    public class CookieController : RenderController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public CookieController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public override IActionResult Index()
        {
            var cookiePage = CurrentPage as CookieDeclaration;

            if (cookiePage != null)
            {
                var model = new CookiePageViewModel(cookiePage, _umbracoContextAccessor);

                return CurrentTemplate(model);
            }

            return null;
        }
    }
}
