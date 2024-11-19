using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbraco_assignment.Models.ViewModels;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Linq;
using umbraco_assignment.Models.PublishedModels;
using Umbraco.Extensions;

namespace umbraco_assignment.Controllers
{
    public class CategoryContainerController : RenderController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public CategoryContainerController(
            ILogger<CategoryContainerController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public override IActionResult Index()
        {
            var categoryContainerPage = CurrentPage as CategoryContainer;

            if (categoryContainerPage != null)
            {
                var model = new CategoryContainerViewModel(categoryContainerPage, _umbracoContextAccessor);

                // Använd denna metod för att hämta barnnoder
                var categories = categoryContainerPage.Children<Category>().ToList();
                model.Categories = categories;

                return View(nameof(CategoryContainer).ToLower(), model);
            }

            // Lägg till denna return-sats för att hantera fallet när categoryContainerPage är null
            return NotFound();
        }

    }
}
