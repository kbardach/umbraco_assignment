using Hangfire.Console;
using Hangfire.Server;
using umbraco_assignment.Business.Services.Interfaces;

namespace umbraco_assignment.Business.ScheduledJob
{
    public class ReviewCleanupJob
    {
        private readonly IReviewService _reviewService;

        public ReviewCleanupJob(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public void CleanupOldReviews(PerformContext context)
        {
            context.WriteLine("Starting cleanup of old reviews...");

            // Exempel: Ta bort recensioner äldre än 30 dagar
            _reviewService.DeleteOldReviews(5);

            context.WriteLine("Cleanup of old reviews completed.");
        }
    }
}
