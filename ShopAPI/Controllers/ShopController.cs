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

        [HttpGet("{id}")]
        public ActionResult<Shop> GetById([FromRoute] int id)
        {
            var shop = _dbContext.Shops.FirstOrDefault(s => s.Id == id);

            if(shop is null)
            {
                return NotFound();
            }

            return Ok(shop);
        }
    }
}
