using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;
using CoreBusiness;
namespace UseCases.ProductsUseCases;

public class ViewProductsInCategoryUseCase : IViewProductsInCategoryUseCase
{
    private readonly IProductRepository productRepository;

    public ViewProductsInCategoryUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public IEnumerable<Product> Execute(int categoryId)
    {
        return productRepository.GetProductsByCategoryId(categoryId);
    }
    
}