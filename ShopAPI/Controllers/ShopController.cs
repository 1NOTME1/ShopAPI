using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Entities;
using ShopAPI.Models;
using ShopAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI.Controllers
{
    [Route("api/shop")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public ActionResult CreateShop([FromBody] CreateShopDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _shopService.Create(dto);

            return Created($"api/shop/{id}", null);
        }


        [HttpGet]
        public ActionResult<IEnumerable<ShopDto>> GetAll()
        {
            var shopsDto = _shopService.GetAll();

            return Ok(shopsDto);
        }

        [HttpGet("{id}")]
        public ActionResult<ShopDto> GetById([FromRoute] int id)
        {
            var shop = _shopService.GetById(id);

            if(shop is null)
            {
                return NotFound();
            }

            return Ok(shop);
        }
    }
}
