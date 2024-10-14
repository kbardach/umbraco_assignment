using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.PublishedModels;
using umbraco_assignment.Models.ViewModels;

namespace umbraco_assignment.Controllers
{
    namespace Umbraco14_002.Controllers
    {
        public class StartController : RenderController
        {
            private readonly IUmbracoContextAccessor _umbracoContextAccessor;

            public StartController(ILogger<StartController> logger,
                ICompositeViewEngine compositeViewEngine,
                IUmbracoContextAccessor umbracoContextAccessor)
                : base(logger, compositeViewEngine, umbracoContextAccessor)
            {
                _umbracoContextAccessor = umbracoContextAccessor;
            }

            public override IActionResult Index()
            {
                var startPage = CurrentPage as Start;

                if (startPage != null)
                {
                    var model = new StartPageViewModel(startPage, _umbracoContextAccessor);
                    return View(nameof(Start).ToLower(), model);
                }

                return NotFound();
            }
        }
    }

}
