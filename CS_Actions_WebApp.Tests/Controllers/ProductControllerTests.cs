using CS_Actions_WebApp.Controllers;
using CS_Actions_WebApp.Infrastructures.Entity;
using CS_Actions_WebApp.Models;
using CS_Actions_WebApp.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace CS_Actions_WebApp.Tests.Controllers;
/// <summary>
/// ProductControllerの単体テストドライバ
/// </summary>
[TestClass]
public class ProductControllerTests
{
    [TestMethod]
    public async Task Index_ReturnsViewResult_WithProductListViewModel()
    {
        // 準備 (Arrange)
        // 今回はインターフェイス(IProductService)をモック化
        var mockService = new Mock<IProductService>();

        // モックが返すダミーデータを作成
        var mockProducts = new List<Product>
        {
            new Product { Id = 1, Name = "水性ボールペン(黒)", Price = 120 },
            new Product { Id = 2, Name = "色鉛筆(48色)", Price = 1300 }
        };

        // Serviceの GetAllProductsAsync()が呼ばれたら、ダミーデータを返すように設定
        mockService.Setup(service => service.GetAllProductsAsync())
                   .ReturnsAsync(mockProducts);

        // Controllerをインスタンス化し、モックをコンストラクタに渡す(DI)
        var controller = new ProductController(mockService.Object);

        // 実行 (Act)
        // HTTPリクエストを通さず、直接 Index() メソッドを呼び出します
        var result = await controller.Index();

        // 検証 (Assert)
        // 戻り値がViewResult(Viewを返す指示)であることを確認
        var viewResult = result as ViewResult;
        Assert.IsNotNull(viewResult, "戻り値がViewResultではありません。");

        // ViewResultに渡されたモデルがProductListViewModelであることを確認
        var model = viewResult.Model as ProductListViewModel;
        Assert.IsNotNull(model, "ViewModelの型が違います、またはnullです。");

        // ViewModelの中にセットされた商品データが、モックデータと一致するか確認
        Assert.HasCount(2, model.Products);
        Assert.AreEqual("水性ボールペン(黒)", model.Products[0].Name);
        Assert.AreEqual(1300, model.Products[1].Price);

        // Controller内部で、Serviceのメソッドが正確に1回呼び出されたことを検証
        mockService.Verify(service => service.GetAllProductsAsync(), Times.Once);
    }
}