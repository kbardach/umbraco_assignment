using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using umbraco_assignment.Business.Services.Interfaces;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IContentService _contentService;
        private readonly HttpClient _httpClient;
        private readonly ILogger<RestaurantService> _logger;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public RestaurantService(IContentService contentService, HttpClient httpClient, ILogger<RestaurantService> logger, IUmbracoContextAccessor umbracoContextAccessor)
        {
            _contentService = contentService;
            _httpClient = httpClient;
            _logger = logger;
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantWithDetailsAsync(string query)
        {
            var restaurants = new List<Restaurant>();

            if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            {
                var rootContent = umbracoContext.Content.GetAtRoot().FirstOrDefault();

                if (rootContent != null)
                {
                    // Get all restaurant nodes (use your document type alias)
                    var allRestaurants = rootContent.DescendantsOrSelf<Restaurant>();

                    restaurants = allRestaurants
                        .Where(x =>
                            // Check RestaurantName contains query (case-insensitive)
                            x.RestaurantName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            // Fallback: Check Description without spaces, in lowercase
                            (x.Description != null && x.Description.ToLower().Replace(" ", "").Contains(query.ToLower().Replace(" ", "")))
                        )
                        .ToList();
                }
            }

            return restaurants;
        }

        //public async Task<IEnumerable<Restaurant>> GetRestaurantWithDetailsAsync(string query)
        //{
        //    var restaurants = new List<Restaurant>();

        //    if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
        //    {
        //        var rootContent = umbracoContext.Content.GetAtRoot().FirstOrDefault();

        //        if (rootContent != null)
        //        {
        //            // Get all restaurant nodes (use your document type alias)
        //            var allRestaurants = rootContent.DescendantsOrSelf<Restaurant>();
        //            restaurants = allRestaurants.Where(x => x.RestaurantName.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
        //        }
        //    }

        //    return restaurants;
        //}
    }
}
