using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_Actions_WebApp.Services;
namespace CS_Actions_WebApp.Tests.Services;
/// <summary>
/// 計算機能を提供するサービスクラスの単体テストドライバ
/// </summary>
[TestClass]
public class CalcServiceTests
{
    /// <summary>
    /// 加算処理のテスト
    /// </summary>   
    [TestMethod]
    public void Execute_Addition_ReturnsCorrectValue()
    {
        var service = new CalcService();
        var result = service.Execute(10, 5, "+");
        // テストを失敗させる
        Assert.AreEqual(10, result);
    }

    /// <summary>
    /// ゼロ除算処理のテスト
    /// </summary>
    [TestMethod]
public void Execute_DivideByZero_ThrowsException()
{
    var service = new CalcService();

    Assert.Throws<DivideByZeroException>(
        () => service.Execute(10, 0, "/")
    );
}
}