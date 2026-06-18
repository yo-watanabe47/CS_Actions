using CS_Actions_WebApp.Infrastructures.Entity;
using CS_Actions_WebApp.Infrastructures.Repository;
using CS_Actions_WebApp.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace CS_Actions_WebApp.Tests.Services;
/// <summary>
/// ProductServiceの単体テストドライバ
/// </summary>
[TestClass]
public class ProductServiceTests
{
    [TestMethod]
    public async Task GetAllProductsAsync_ShouldReturnMockedProducts()
    {
        // Arrange(準備)
        // Repositoryのモックを作成 (DbContextは不要なのでnullを渡すか、ダミーを渡す)
        // ※ Moqがメソッドを上書きできるように、対象メソッドにはvirtualが必要
        var mockRepo = new Mock<ProductRepository>(null!);

        var mockProducts = new List<Product>
        {
            new Product { Id = 1, Name = "水性ボールペン(黒)", Price = 120 },
            new Product { Id = 2, Name = "色鉛筆(48色)", Price = 1300 }
        };

        // SelectAllAsyncが呼ばれたら、用意したモックデータを返すように設定
        mockRepo.Setup(repo => repo.SelectAllAsync()).ReturnsAsync(mockProducts);

        // モック化したRepositoryをServiceに注入
        var service = new ProductService(mockRepo.Object);

        // Act(実行)
        var result = await service.GetAllProductsAsync();

        // Assert(検証)
        Assert.HasCount(2, result);
        Assert.AreEqual("水性ボールペン(黒)", result[0].Name);

        // RepositoryのSelectAllAsyncが正確に1回呼ばれたことを検証
        mockRepo.Verify(repo => repo.SelectAllAsync(), Times.Once);
    }
}