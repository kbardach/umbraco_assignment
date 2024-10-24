using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbraco_assignment.Models.PublishedModels;
using umbraco_assignment.Models.ViewModels;

namespace umbraco_assignment.Controllers
{
	public class ErrorController : RenderController
	{
		private readonly IUmbracoContextAccessor _umbracoContextAccessor;

		public ErrorController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
			_umbracoContextAccessor = umbracoContextAccessor;
		}

		public override IActionResult Index()
		{
			var errorPage = CurrentPage as Error;

			if (errorPage != null)
			{
				var model = new ErrorPageViewModel(errorPage, _umbracoContextAccessor);

				return CurrentTemplate(model);
			}

			return null;
		}
	}
}