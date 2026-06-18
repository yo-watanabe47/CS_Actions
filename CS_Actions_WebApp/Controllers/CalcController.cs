using Microsoft.AspNetCore.Mvc;
using CS_Actions_WebApp.Models;
using CS_Actions_WebApp.Services;
namespace CS_Actions_WebApp.Controllers;
/// <summary>
/// 計算機能のコントローラークラス
/// </summary>
public class CalcController : Controller
{
    // 計算サービス
    private readonly CalcService _calcService;
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="calcService">計算サービス</param>
    public CalcController(CalcService calcService)
    {
        _calcService = calcService;
    } 

    /// <summary>
    /// 計算機能の入力を表示するアクション
    /// </summary>
    [HttpGet]
    public IActionResult Index()
    {
        return View(new CalcViewModel());
    }

    /// <summary>
    /// 計算機能の計算を実行するアクション
    /// </summary>
    /// <param name="model">計算モデル</param>
    /// <returns>計算結果</returns>
    [HttpPost]
    public IActionResult Calculate(CalcViewModel model)
    {
        try
        {
            model.Result = _calcService.Execute(model.Value1, model.Value2, model.OperatorType);
            model.ErrorMessage = null;
        }
        catch (Exception ex)
        {
            model.Result = null;
            model.ErrorMessage = ex.Message;
        }

        return View("Index", model);
    }
}