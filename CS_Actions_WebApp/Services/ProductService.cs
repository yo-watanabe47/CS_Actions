using CS_Actions_WebApp.Infrastructures.Entity;
using CS_Actions_WebApp.Infrastructures.Repository;
namespace CS_Actions_WebApp.Services;
/// <summary>
/// 商品情報を扱うサービスインターフェイス実装クラス
/// </summary>
public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="productRepository">ProductRepositoryを注入する</param>
    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// 全ての商品情報をID順に取得する
    /// </summary>
    public async Task<List<Product>> GetAllProductsAsync()
    {
        // リポジトリのメソッドを非同期で呼び出して結果を返す
        return await _productRepository.SelectAllAsync();
    }
}