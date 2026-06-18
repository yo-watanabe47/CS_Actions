using System.Collections.Generic;

using CS_Actions_WebApp.Infrastructures.Entity;
namespace CS_Actions_WebApp.Models;

/// <summary>
/// 商品一覧画面用のViewModel
/// </summary>
public class ProductListViewModel
{
    /// <summary>
    /// Viewに渡す商品リスト
    /// </summary>
    public List<Product> Products { get; set; } = new List<Product>();
}