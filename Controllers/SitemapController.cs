using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using umbraco_assignment.Models.ViewModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbraco_assignment.Business.Services.Interfaces;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Controllers
{
    public class SitemapController : RenderController
    {
        private readonly ISitemapService _sitemapService;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public SitemapController(ISitemapService sitemapService, ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _sitemapService = sitemapService;
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public override IActionResult Index()
        {
            var sitemap = CurrentPage as Sitemap;

            if (sitemap != null)
            {
                var model = new SitemapViewModel(sitemap, _umbracoContextAccessor)
                {
                    Pages = _sitemapService.Pages()
                };

                return CurrentTemplate(model);
            }

            return null;
        }
    }
}
