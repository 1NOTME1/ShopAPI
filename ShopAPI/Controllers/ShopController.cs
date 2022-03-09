using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public ActionResult CreateShop([FromBody]CreateShopDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shop = _mapper.Map<Shop>(dto);

            _dbContext.Shops.Add(shop);
            _dbContext.SaveChanges();

            return Created($"api/shop/{shop.Id}", null);
        }
            

        [HttpGet]
        public ActionResult<IEnumerable<ShopDto>> GetAll()
        {
            var shops = _dbContext
                .Shops
                .Include(s => s.Address)
                .Include(s => s.Product)
                .ToList();

            var shopsDto = _mapper.Map<List<ShopDto>>(shops);

            return Ok(shopsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ShopDto> GetById([FromRoute] int id)
        {
            var shop = _dbContext
                .Shops
                .Include(s => s.Address)
                .Include(s => s.Product)
                .FirstOrDefault(s => s.Id == id);

            if(shop is null)
            {
                return NotFound();
            }
           var shopDto = _mapper.Map<ShopDto>(shop);

            return Ok(shopDto);
        }
    }
}
