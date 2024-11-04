using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using umbraco_assignment.Models.PublishedModels;
using umbraco_assignment.Models.ViewModels;
using umbraco_assignment.Business.Services.Interfaces;
using umbraco_assignment.Business.Services;
using Microsoft.IdentityModel.Tokens;

namespace umbraco_assignment.Controllers
{
    public class SearchController : RenderController
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly IRestaurantService _restaurantService;

        public SearchController(IRestaurantService restaurantService,ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _restaurantService = restaurantService;
        }

        [HttpGet("search/index")]
        public async Task<IActionResult> Index()
        {
            var query = HttpContext.Request.Query["query"];
            var searchPage = CurrentPage as Search;

            if (searchPage != null)
            {
                var hits = await _restaurantService.GetRestaurantWithDetailsAsync(query);
                var message = "";

                if (!string.IsNullOrEmpty(query) && !hits.Any())
                {
                    message = searchPage.NoResultsMessage;
                }

                var model = new SearchPageViewModel(searchPage, _umbracoContextAccessor)
                {
                    SearchQuery = query,
                    SearchHits = hits,
                    NoResultsMessage = message
                };

                return CurrentTemplate(model);
            }

            return null;
        }

        //[HttpPost]
        //public IActionResult SubmitForm(string query)
        //{
        //    return null;
        //}

        //[HttpPost]
        //public IActionResult SearchResults(string query) 
        //{

        //    return null;
        //}
    }
}























//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Linq;
//using Umbraco.Cms.Core.Services;
//using Umbraco.Cms.Infrastructure.Examine;
//using Examine;
//using Umbraco.Cms.Web.Common.Controllers;
//using Umbraco.Cms.Core.Web;
//using umbraco_assignment.Models.ViewModels;
//using Microsoft.AspNetCore.Mvc.ViewEngines;
//using umbraco_assignment.Models.PublishedModels;

//namespace umbraco_assignment.Controllers
//{
//    public class SearchController : RenderController
//    {
//        private readonly IExamineManager _examineManager;
//        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

//        public SearchController(
//            ILogger<SearchController> logger,
//            ICompositeViewEngine compositeViewEngine,
//            IUmbracoContextAccessor umbracoContextAccessor,
//            IExamineManager examineManager)
//            : base(logger, compositeViewEngine, umbracoContextAccessor)
//        {
//            _examineManager = examineManager;
//            _umbracoContextAccessor = umbracoContextAccessor;
//        }

//        [HttpGet]
//        public IActionResult SearchResults(string query)
//        {
//            // Fetch the current page content as a SearchPageViewModel
//            var model = new SearchPageViewModel(CurrentPage as Search, _umbracoContextAccessor, query); // Pass the query as searchTerm

//            // If there's no query, return an empty result set
//            if (string.IsNullOrWhiteSpace(query))
//            {
//                model.Restaurants = new List<Restaurant>();
//                return View("SearchResults", model);
//            }

//            var searchResults = new List<Restaurant>();

//            // Check if the Examine index is available and perform search
//            if (_examineManager.TryGetIndex("ExternalIndex", out var index))
//            {
//                var searcher = index.Searcher;

//                // Build a query to search the "nodeName" field for restaurant names that match the query
//                var criteria = searcher.CreateQuery("content")
//                                       .NodeTypeAlias("restaurant") // Specify the node type alias for restaurants
//                                       .And().Field("nodeName", query.MultipleCharacterWildcard());

//                var results = criteria.Execute();

//                // Convert results to a list of Restaurant nodes
//                searchResults = results.Select(result =>
//                {
//                    if (_umbracoContextAccessor.TryGetUmbracoContext(out var context) &&
//                        int.TryParse(result.Id, out var contentId))
//                    {
//                        return context.Content.GetById(contentId) as Restaurant;
//                    }
//                    return null;
//                })
//                .Where(r => r != null).ToList();
//            }

//            // Populate the Restaurants property in the view model with the search results
//            model.Restaurants = searchResults;

//            return View("SearchResults", model); // Render the SearchResults.cshtml view with the model
//        }
//    }
//}



