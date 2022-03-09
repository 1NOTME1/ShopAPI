using ShopAPI.Models;

namespace ShopAPI.Services
{
    public class ShopService
    {
       
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


    }
}
