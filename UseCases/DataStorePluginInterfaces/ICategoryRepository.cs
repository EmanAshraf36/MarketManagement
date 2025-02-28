using CoreBusiness;
namespace UseCases.DataStorePluginInterfaces;
public interface ICategoryRepository
{
    
    void AddCategory(Category category);
    void DeleteCategory(int id);
    IEnumerable<Category> GetCategories();
    Category? GetCategoryById(int categoryId);
    void UpdateCategory(int categoryId,Category category);
}