using CS_Actions_WebApp.Models;
using CS_Actions_WebApp.Services;

using Microsoft.AspNetCore.Mvc;

namespace CS_Actions_WebApp.Controllers;
/// <summary>
/// 商品一覧コントローラ
/// </summary> 
public class ProductController : Controller
{
    private readonly IProductService _productService;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="productService">商品サービスの注入</param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// 商品一覧画面を表示する (GET: /Product)
    /// </summary>
    public async Task<IActionResult> Index()
    {
        // Serviceを呼び出して商品一覧を非同期で取得
        var products = await _productService.GetAllProductsAsync();

        // ViewModelにデータを詰める
        var viewModel = new ProductListViewModel
        {
            Products = products
        };

        // Views/Product/Index.cshtml を呼び出し、ViewModelを渡す
        return View(viewModel);
    }
}