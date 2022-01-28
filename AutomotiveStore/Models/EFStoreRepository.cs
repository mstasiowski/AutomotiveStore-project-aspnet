using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveStore.Models
{
   public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public EFStoreRepository(StoreDbContext _contex)
        {
            context = _contex; 
        }

        public IQueryable<Product> Products => context.Products;
    }
}
