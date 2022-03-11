using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models
{
    public class UpdateShopDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
    }
}
