using Microsoft.AspNetCore.Mvc;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Business.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetRestaurantWithDetailsAsync(string query);
    }
}