using umbraco_assignment.Models.PetaPoco;

namespace umbraco_assignment.Business.Services.Interfaces
{
    public interface IReviewService
    {
        void CreateReview(Review review);

        List<Review> GetReviews();
    }
}