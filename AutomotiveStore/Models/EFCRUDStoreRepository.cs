using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AutomotiveStore.Models
{
    public class EFCRUDStoreRepository : ICRUDStoreRepository
    {
        private StoreDbContext context;

        public EFCRUDStoreRepository(StoreDbContext _context)
        {
            context = _context;
        }

        public Product Add(Product product)
        {
            EntityEntry<Product> entityEntry = context.Add(product);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            context.Products.Remove(context.Products.Find(id));
            context.SaveChanges();
        }

        public List<Product> FindAll()
        {
            return context.Products.ToList();
        }

        public Product FindById(int id)
        {
            return context.Products.Find(id);
        }

        public Product Update(Product product)
        {
            Product original = context.Products.Find(product.ProductID);
            original.Name = product.Name;
            original.Description = product.Description;
            original.Category = product.Category;
            original.Price = product.Price;
            EntityEntry<Product> entityEntry = context.Products.Update(original);
            context.SaveChanges();
            return entityEntry.Entity;
        }

    }
}
