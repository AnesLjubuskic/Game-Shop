using GameShopDA.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.DBModels
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public bool EditMode { get; set; }
        public Platform Platform { get; set; }
        public bool SoftDelete { get; set; }
        public virtual ICollection<UserGame> UserGame { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }


    }
}
