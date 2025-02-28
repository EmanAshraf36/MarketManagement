using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases;

public class ViewCategoriesUseCase : IViewCategoriesUseCase
{
    //initialize the repo
    private readonly ICategoryRepository categoryRepository;

    public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }


    public IEnumerable<Category> Execute()
    {
        return categoryRepository.GetCategories();
    }
}