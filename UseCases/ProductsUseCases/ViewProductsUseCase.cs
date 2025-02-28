using System.Collections.Generic;
using CoreBusiness;
using UseCases;
using UseCases.DataStorePluginInterfaces;

namespace UseCases.ProductsUseCases;

public class ViewProductsUseCase : IViewProductsUseCase
{
    private readonly IProductRepository productRepository;

    public ViewProductsUseCase(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public IEnumerable<Product> Execute(bool loadCategory = false)
    {
        return productRepository.GetProducts(loadCategory);
    }
}