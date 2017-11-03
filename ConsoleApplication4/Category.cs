using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBEntityFrameworkProject
{
    class Category
    {
        public int CategoryID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public List<Product> Products { get; set; }
    }

   
    
}
