using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.CategoriesUseCases;

public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
{
    private readonly ICategoryRepository categoryRepository;

    public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public Category? Execute(int id)
    {
        return categoryRepository.GetCategoryById(id);
    }
}