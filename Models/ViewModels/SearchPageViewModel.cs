using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
    public class SearchPageViewModel : BasePageViewModel<Search>
    {
        public SearchPageViewModel(Search content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }

        public IEnumerable<Restaurant> SearchHits { get; set; }

    }
}
