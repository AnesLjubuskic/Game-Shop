using GameShopDA.DBModels;
using GameShopDA.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.DTO
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public bool EditMode { get; set; }
        public bool SoftDelete { get; set; }

        public Platform Platform { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string? PlatformName { get; set; }
        public string? CategoryName { get; set; }
        public string? SubcategoryName { get; set; }
    }
}
