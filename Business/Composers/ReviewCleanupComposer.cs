using Hangfire;
using Umbraco.Cms.Core.Composing;
using umbraco_assignment.Business.ScheduledJob;

namespace umbraco_assignment.Business.Composers
{
    public class ReviewCleanupComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            RecurringJob.AddOrUpdate<ReviewCleanupJob>(
                "Weekly Review Cleanup",                   // Namn på jobbet
                x => x.CleanupOldReviews(null),           // Metoden som ska köras
                Cron.Weekly);                             // Kör varje vecka
        }
    }
}
