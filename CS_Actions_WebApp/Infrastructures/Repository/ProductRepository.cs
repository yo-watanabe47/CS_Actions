using CS_Actions_WebApp.Infrastructures.Context;
using CS_Actions_WebApp.Infrastructures.Entity;

using Microsoft.EntityFrameworkCore;
namespace CS_Actions_WebApp.Infrastructures.Repository;

using CS_Actions_WebApp.Infrastructures.Entity;

/// <summary>
/// 商品情報のデータアクセスを担うリポジトリクラス
/// </summary>
public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    // <summary>
    /// 全ての商品をID順に取得する
    /// virtualを付与しているのは、Moqでこのメソッドを上書きできるようにするため
    /// </summary>
    public virtual async Task<List<Product>> SelectAllAsync()
    {
        return await _context.Products.OrderBy(p => p.Id).ToListAsync();
    }
}