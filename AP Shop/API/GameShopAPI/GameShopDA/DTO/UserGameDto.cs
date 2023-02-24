using GameShopDA.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.DTO
{
    public class UserGameDto
    {
        public int Id { get; set; }
        public bool BuyCheck { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public double? ShippingPrice { get; set; }
        public double? PurchasedAtPrice { get; set; }

        public bool Purchased { get; set; }
        public int UserId { get; set; }
        public int gameId { get; set; }
    }
}
