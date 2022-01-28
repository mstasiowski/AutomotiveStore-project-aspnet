using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutomotiveStore.Models;


namespace AutomotiveStore.Models
{
    public class ProductListView
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingNumInfo PagingNumInfo { get; set; }

       
       
    }
}
