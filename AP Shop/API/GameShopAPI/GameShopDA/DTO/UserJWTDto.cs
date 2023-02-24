using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.DTO
{
    public class UserJWTDto
    {
        public int Id { get; set; }
        public string role { get; set; }
        public string jwt { get; set; }
    }
}
