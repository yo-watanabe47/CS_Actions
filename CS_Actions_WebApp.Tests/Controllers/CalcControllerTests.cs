using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using CS_Actions_WebApp.Controllers;
using CS_Actions_WebApp.Models;
using CS_Actions_WebApp.Services;

namespace CS_Actions_WebApp.Tests;
/// <summary>
/// 計算機能コントローラとサービスの結合テストドライバクラス
/// </summary>
[TestClass]
public class CalcControllerTests
{
    // <summary>
    /// 計算処理のテスト
    /// </summary>
    [TestMethod]
    public void Calculate_ValidInput_UpdatesResult()
    {
        var service = new CalcService();
        var controller = new CalcController(service);
        var model = new CalcViewModel { Value1 = 10, Value2 = 5, OperatorType = "+" };

        var result = controller.Calculate(model) as ViewResult;
        var resultModel = result?.Model as CalcViewModel;

        Assert.IsNotNull(resultModel);
        Assert.AreEqual(15, resultModel.Result);
        Assert.IsNull(resultModel.ErrorMessage);
    }

    /// <summary>
    /// ゼロ除算のエラーメッセージ更新のテスト
    /// </summary> 
    [TestMethod]
    public void Calculate_DivideByZero_UpdatesErrorMessage()
    {
        var service = new CalcService();
        var controller = new CalcController(service);
        var model = new CalcViewModel { Value1 = 10, Value2 = 0, OperatorType = "/" };

        var result = controller.Calculate(model) as ViewResult;
        var resultModel = result?.Model as CalcViewModel;

        Assert.IsNotNull(resultModel);
        Assert.IsNull(resultModel.Result);
        Assert.AreEqual("0で割ることはできません。", resultModel.ErrorMessage);
    }
}