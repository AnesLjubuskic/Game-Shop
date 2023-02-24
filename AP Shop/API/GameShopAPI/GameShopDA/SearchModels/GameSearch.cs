using GameShopDA.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.SearchModels
{
    public class GameSearch:BaseSearch
    {
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public Platform? Platform { get; set; }
        public string? Sort { get; set; }
    }
}
