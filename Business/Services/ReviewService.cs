using Microsoft.Data.SqlClient;
using NPoco;
using Umbraco.Cms.Core.Configuration.Models;
using umbraco_assignment.Business.Services.Interfaces;
using umbraco_assignment.Models.PetaPoco;

namespace umbraco_assignment.Business.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IConfiguration _configuration;

        public ReviewService(IConfiguration configuration)
        {
            _configuration = configuration;

            EnsureReviewsTableCreated();
        }

        public void EnsureReviewsTableCreated()
        {
            var connection = _configuration.GetConnectionString("umbracoDbDSN");

            using (var db = new Database(connection, DatabaseType.SqlServer2012, SqlClientFactory.Instance))
            {
                var sql = @"
                IF NOT EXISTS (
                    SELECT * 
                    FROM sys.tables 
                    WHERE name = 'Reviews' AND schema_id = SCHEMA_ID('dbo')
                )
                BEGIN
                    CREATE TABLE dbo.Reviews
                    (
                        id INT NOT NULL IDENTITY (1, 1),
                        restaurantId NVARCHAR(50) NULL,
                        comment NVARCHAR(MAX) NULL,
                        name NVARCHAR(50) NULL,
                        rating INT NULL,
                        date DATE NULL
                    ) 
                    ON [PRIMARY] 
                    TEXTIMAGE_ON [PRIMARY];
                END";

                db.Execute(sql);
            }
        }

        public void CreateReview(Review review)
        {
            var connection = _configuration.GetConnectionString("umbracoDbDSN");

            using (var db = new Database(connection, DatabaseType.SqlServer2012, SqlClientFactory.Instance))
            {
                var sql = @"
                    INSERT INTO dbo.Reviews (restaurantId, comment, name, rating, date)
                    VALUES (@0, @1, @2, @3, @4)";

                db.Execute(sql, review.RestaurantId, review.Comment, review.Name, review.Rating, review.Date);
            }
        }

        public List<Review> GetReviews(int restaurantId)
        {
            var connection = _configuration.GetConnectionString("umbracoDbDSN");

            using (var db = new Database(connection, DatabaseType.SqlServer2012, SqlClientFactory.Instance))
            {
                var sql = @"
                    SELECT restaurantId, name, comment, rating, date
                    FROM dbo.Reviews
                    WHERE restaurantId = @0";

                return db.Fetch<Review>(sql, restaurantId);
            }
        }

    }
}
