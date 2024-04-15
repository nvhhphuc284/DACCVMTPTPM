using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VSG.Models
{
    public class Shoe_Category
    {
        public List<Shoe> ListShoe { get; set; }
        public List<Category> ListCategory { get; set; }
        public List<Shoe_Service> ListShoeService { get; set; }
    }
}