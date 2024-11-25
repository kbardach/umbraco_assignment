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
                    var allRestaurants = rootContent.DescendantsOrSelf<Restaurant>();

                    restaurants = allRestaurants
                        .Where(x => x.Keywords?.Split(',').Any(k => k.Trim().Equals(query, StringComparison.OrdinalIgnoreCase)) == true)
                        .ToList();
                }
            }

            return restaurants;
        }
    }
}
