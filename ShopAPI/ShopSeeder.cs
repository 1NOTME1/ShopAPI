using ShopAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopAPI
{
    public class ShopSeeder //seedowanie danych do DB.
    {
        private readonly ShopDbContext _dbContext;
        public ShopSeeder(ShopDbContext dbContext) //wstrzykniecie by komunikowac sie z baza
        {
            _dbContext = dbContext;
        }

        public void Seed() //seeduje objekty
        {
            if (_dbContext.Database.CanConnect()) //checking DB connections
            {
                if (!_dbContext.Shops.Any()) //checking if table Shops is empty if not added objects to Shops table.
                {
                    var shop = GetShops();
                    _dbContext.Shops.AddRange(shop);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Shop> GetShops() //creating objects.
        {
            var shops = new List<Shop>()
            {
                new Shop()
                {
                    Name = "morele.net",
                    Category = "AGD",
                    Description =
                        "Shop with AGD, IT stuff",
                    ContactEmail = "contact@morele.com",
                    ContactNumber ="999 888 777",
                    HasDelivery = true,
                    Product = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Apple Watch 7",
                            Producer = "Apple",
                            Price = 4110.30M,
                            Description = "Apple Watch is a wearable smartwatch that allows users to accomplish a variety of tasks, including making phone calls, sending text messages and reading email. ",
                            Category = "Accessories",
                        },

                        new Product()
                        {
                            Name = "IPhone 13 Pro Max",
                            Producer = "Apple",
                            Price = 7499.99M,
                            Description = "The iPhone 13 Pro and Pro Max uses an Apple-designed A15 Bionic processor featuring a 16-core neural engine, 6-core CPU (with 2 performance cores and 4 efficiency cores), and 5-core GPU. The A15 Bionic also contains a next-generation image processor.",
                            Category = "Phone",
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },
                new Shop()
                {
                    Name = "Kaufland",
                    Category = "Supermarket",
                    Description = "Kaufland is a German hypermarket chain, part of the Schwarz Gruppe which also owns Lidl. The hypermarket directly translates to English as 'buy-land'.",
                    ContactEmail = "contact@kaufland.com",
                    HasDelivery = false,
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Szewska 2",
                        PostalCode = "10-201"
                    }
                }
            };

            return shops;
        }
    }
}
