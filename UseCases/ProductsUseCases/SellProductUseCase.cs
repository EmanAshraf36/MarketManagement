using UseCases.DataStorePluginInterfaces;
using UseCases.TransactionsUseCases;

namespace UseCases.ProductsUseCases;

public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductRepository productRepository;
    private readonly IRecordTransactionUseCase recordTransactionUseCase;

    public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
    {
        this.productRepository = productRepository;
        this.recordTransactionUseCase = recordTransactionUseCase;
    }

    public void Execute(string cashierName, int productId, int qtyToSell)
    {
        var product = productRepository.GetProductById(productId);
        if (product == null) return;
        
        recordTransactionUseCase.Execute(cashierName, productId, qtyToSell);
        product.Quantity -= qtyToSell;
        productRepository.UpdateProduct(productId, product);
    }
}