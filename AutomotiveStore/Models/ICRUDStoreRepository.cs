using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomotiveStore.Models
{
   public interface ICRUDStoreRepository
    {
        Product FindById(int id);
        Product Add(Product product);

        void Delete(int id);

        Product Update(Product product);

        List<Product> FindAll();
    }
}
