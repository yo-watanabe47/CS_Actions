namespace CS_Actions_WebApp.Models;
/// <summary>
/// 計算機能のViewModelクラス
/// </summary> 
public class CalcViewModel
{
    // 値1
    public int Value1 { get; set; }
    // 値2
    public int Value2 { get; set; }
    // 演算子タイプ
    public string OperatorType { get; set; } = "+";
    // 結果
    public int? Result { get; set; }
    // エラーメッセージ
    public string? ErrorMessage { get; set; }
}