using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveStore.Models
{
    public class PagingNumInfo
    {
        public int AllElement  { get; set; } //AllElement
    public int ProductPerPage  { get; set; } //ProductPerPage
    public int CurrentPage { get; set; }


        //TotalNumOfPages
        public int  TotalNumOfPages=> (int)Math.Ceiling((decimal)AllElement/ ProductPerPage);
    }
}
