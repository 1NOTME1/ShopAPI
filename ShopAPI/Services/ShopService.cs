using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopAPI.Entities;
using ShopAPI.Exceptions;
using ShopAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI.Services
{
    public interface IShopService
    {
        public void Delete(int id);
        int Create(CreateShopDto dto);
        IEnumerable<ShopDto> GetAll();
        ShopDto GetById(int id);
        public void Update(int id, UpdateShopDto dto);
    }

    public class ShopService : IShopService
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ShopService> _logger;

        public ShopService(ShopDbContext dbContext, IMapper mapper, ILogger<ShopService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public void Update(int id, UpdateShopDto dto)
        {
            var shop = _dbContext
                .Shops
                .FirstOrDefault(s => s.Id == id);

            if (shop is null)
                throw new NotFoundException("Restaurant not found");

            shop.Name = dto.Name;
            shop.Description = dto.Description;
            shop.HasDelivery = dto.HasDelivery;

            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _logger.LogError($"Shop with id: {id} DELETE actoin invoked");

            var shop = _dbContext
                .Shops
                .FirstOrDefault(x => x.Id == id);

            if (shop is null)
                throw new NotFoundException("Restaurant not found");

            _dbContext.Shops.Remove(shop);
            _dbContext.SaveChanges();
        }

        public ShopDto GetById(int id)
        {
            var shop = _dbContext
                .Shops
                .Include(s => s.Address)
                .Include(s => s.Product)
                .FirstOrDefault(s => s.Id == id);

            if (shop is null)
                throw new NotFoundException("Restaurant not found");

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

        public int Create(CreateShopDto dto)
        {
            var shop = _mapper.Map<Shop>(dto);

            _dbContext.Shops.Add(shop);
            _dbContext.SaveChanges();

            return shop.Id;
        }

    }
}
