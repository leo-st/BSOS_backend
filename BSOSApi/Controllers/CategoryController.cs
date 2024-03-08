using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSOSApi.Data;
using BSOSApi.Models;
using BSOSApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace BSOSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly TestContext _context;
        private readonly IClientService _clientService;

        public CategoryController(TestContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }

        // GET: api/category
        [HttpGet]
        [Route("all")]
        [EnableCors("corsapp")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            return await _clientService.GetAllCategories();
        }
        
    }
}
