using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using umbraco_assignment.Business.Services.Interfaces;
using umbraco_assignment.Models.PetaPoco;
using umbraco_assignment.Models.PublishedModels;
using umbraco_assignment.Models.ViewModels;

namespace umbraco_assignment.Controllers
{
    public class ReviewController : SurfaceController
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService,IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _reviewService = reviewService;
        }

        [ValidateAntiForgeryToken]
        public IActionResult CreateReview(string name, string comment, int restaurantId, int rating)
        {
            if (ModelState.IsValid)
            {
                var review = new Review
                {
                    Name = name,
                    Comment = comment,
                    RestaurantId = restaurantId,
                    Rating = rating,
                    Date = DateTime.Now
                };

                _reviewService.CreateReview(review);

                return RedirectToCurrentUmbracoPage();
            }

            return NotFound();
        }
    }
}