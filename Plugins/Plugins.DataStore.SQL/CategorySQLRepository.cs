using System.Collections.Generic;
using System.Linq;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL;

public class CategorySQLRepository : ICategoryRepository
{
    private readonly MarketContext db;

    public CategorySQLRepository(MarketContext db)
    {
        this.db = db;
    }

    public void AddCategory(Category category)
    {
        db.Categories.Add(category);
        db.SaveChanges();
    }

    public void DeleteCategory(int id)
    {
        var category = db.Categories.Find(id);
        if (category != null) return;
        
        db.Categories.Remove(category);
        db.SaveChanges();
    }

    public IEnumerable<Category> GetCategories()
    {
        return db.Categories.ToList();
    }

    public Category? GetCategoryById(int categoryId)
    {
        var category = db.Categories.Find(categoryId);
        return category;
    }

    public void UpdateCategory(int categoryId, Category category)
    {
        if (categoryId != category.CategoryId) return;
        
        var cat = db.Categories.Find(categoryId);
        if (cat == null) return;
        
        cat.Name = category.Name;
        cat.Description = category.Description;
        db.SaveChanges();
    }
}