using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
    public class SitemapViewModel : BasePageViewModel<Sitemap>
    {
        public List<IPublishedContent> Pages { get; set; }

        public SitemapViewModel (Sitemap content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }
    }
}