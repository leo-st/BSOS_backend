

using BSOSApi.Models;

namespace BSOSApi.Services
{
    public interface IClientService
    {
        Task<List<Category>> GetAllCategories();
    }
}