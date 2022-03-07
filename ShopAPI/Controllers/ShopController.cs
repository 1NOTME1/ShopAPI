using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Entities;
using ShopAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI.Controllers
{
    [Route("api/shop")]
    public class ShopController : ControllerBase
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ShopController(ShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
