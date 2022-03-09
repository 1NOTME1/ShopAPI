using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI.Entities;
using ShopAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI.Services
{
    public class ShopService
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ShopService(ShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ShopDto GetById(int id)
        {
            var shop = _dbContext
                .Shops
                .Include(s => s.Address)
                .Include(s => s.Product)
                .FirstOrDefault(s => s.Id == id);

            if (shop is null) return null;

            var shopDto = _mapper.Map<ShopDto>(shop);

            return shopDto;    
        }

        public IEnumerable<ShopDto> GetAll()
        {
            var shops = _dbContext
                .Shops
                .Include(s => s.Address)
                .Include(s => s.Product)
                .ToList();

            var shopsDto = _mapper.Map<List<ShopDto>>(shops);

            return shopsDto;
        }

        

    }
}
