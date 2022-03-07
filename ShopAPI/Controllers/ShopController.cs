using Microsoft.AspNetCore.Mvc;
using ShopAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI.Controllers
{
    [Route("api/shop")]
    public class ShopController : ControllerBase
    {
        private readonly ShopDbContext _dbContext;

        public ShopController(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shop>> GetAll()
        {
            var shops = _dbContext.Shops.ToList();

            return Ok(shops);
        }
        
        
    }
}
