using BSOSApi.Data;
using BSOSApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BSOSApi.Services
{
    public class ClientService(TestContext context) : IClientService
    {
        private readonly TestContext _context = context;

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

    }
}