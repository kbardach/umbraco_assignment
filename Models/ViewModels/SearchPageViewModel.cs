using Umbraco.Cms.Core.Web;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Models.ViewModels
{
    public class SearchPageViewModel : BasePageViewModel<Search>
    {
        public SearchPageViewModel(Search content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
            Restaurants = SettingsPage.Restaurants.Children<Restaurant>();
        }

        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}














//using Umbraco.Cms.Core.Web;
//using umbraco_assignment.Models.PublishedModels;

//namespace umbraco_assignment.Models.ViewModels
//{
//    public class SearchPageViewModel : BasePageViewModel<Search>
//    {
//        public SearchPageViewModel(Search content, IUmbracoContextAccessor umbracoContextAccessor, string searchTerm)
//            : base(content, umbracoContextAccessor)
//        {
//            SearchTerm = searchTerm; // Store the search term
//            Restaurants = SettingsPage.Restaurants.Children<Restaurant>(); // You may want to filter this list based on the search term
//        }

//        public string SearchTerm { get; set; } // Property to hold the search term
//        public IEnumerable<Restaurant> Restaurants { get; set; }
//    }
//}
