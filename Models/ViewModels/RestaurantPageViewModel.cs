using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
    public class RestaurantPageViewModel : BasePageViewModel<Restaurant>
    {
        public RestaurantPageViewModel(Restaurant content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }
    }
}
