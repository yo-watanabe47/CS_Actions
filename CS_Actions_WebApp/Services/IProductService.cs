using CS_Actions_WebApp.Infrastructures.Entity;
namespace CS_Actions_WebApp.Services;
/// <summary>
/// 商品情報を扱うサービスインターフェイス
/// </summary>
public interface IProductService
{
    /// <summary>
    /// 全ての商品情報をID順に取得する
    /// </summary>
    Task<List<Product>> GetAllProductsAsync();
}