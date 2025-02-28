using System.Collections.Generic;
using System.Linq;
using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class ProductSQLRepository : IProductRepository
{
    private readonly MarketContext db;


    public ProductSQLRepository(MarketContext db)
    {
        this.db = db;
    }

    public IEnumerable<Product> GetProducts(bool loadCategory = false)
    {
        if (loadCategory)
            return db.Products.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList();
        else
        {
            return db.Products.OrderBy(x => x.CategoryId).ToList();
        }
    }

    public void AddProduct(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
    }

    public void UpdateProduct(int productId, Product product)
    {
        var prod  = db.Products.Find(productId);
        if (prod == null) return;
        
        prod.CategoryId = product.CategoryId;
        prod.Price = product.Price;
        prod.Name = product.Name;
        prod.Quantity = product.Quantity;
        
        db.SaveChanges();
    }

    public Product? GetProductById(int productId, bool loadCategory = false)
    {
        if(loadCategory)
            return db.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == productId);
        else
        {
            return db.Products.FirstOrDefault(x => x.ProductId == productId);
        }
    }

    public void DeleteProduct(int productId)
    {
        var product = db.Products.Find(productId);
        if(product == null) return;
        
        db.Products.Remove(product);
        db.SaveChanges();
    }

    public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
    {
        return db.Products.Where(x => x.CategoryId == categoryId);
    }
}