using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopDA.DBModels
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public virtual ICollection<Game> Games { get; set; }

    }
}
