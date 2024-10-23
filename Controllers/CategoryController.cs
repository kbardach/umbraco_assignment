using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbraco_assignment.Models.ViewModels;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Controllers
{
	public class CategoryController : RenderController
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public CategoryController(ILogger<CategoryController> logger,
			ICompositeViewEngine compositeViewEngine,
			IUmbracoContextAccessor umbracoContextAccessor)
			: base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public override IActionResult Index()
		{
			var categoryPage = CurrentPage as Category;

			if (categoryPage != null)
			{
				var model = new CategoryPageViewModel(categoryPage, _umbracoContextAccessor);
				return View(nameof(Category).ToLower(), model);
			}

			return NotFound();
		}
	}
}
