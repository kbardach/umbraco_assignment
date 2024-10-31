using Microsoft.AspNetCore.Mvc;
using umbraco_assignment.Models.PublishedModels;

namespace umbraco_assignment.Business.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetRestaurantWithDetailsAsync(string query);
    }
}