namespace CS_Actions_WebApp.Services;
/// <summary>
/// 計算機能を提供するサービスクラス
/// </summary>
public class CalcService
{
    /// <summary>
    /// 計算を実行するメソッド
    /// </summary>
    /// <param name="value">値1</param>
    /// <param name="value2">値2</param>
    /// <param name="operatorType">演算子</param>
    /// <returns>計算結果</returns>
    /// <exception cref="DivideByZeroException">0で割ろうとした場合</exception>
    /// <exception cref="InvalidOperationException">不正な演算子が指定された場合</exception>
    public int Execute(int value, int value2, string operatorType)
    {
        return operatorType switch
        {
            "+" => value + value2,
            "-" => value - value2,
            "*" => value * value2,
            "/" when value2 == 0 => throw new DivideByZeroException("0で割ることはできません。"),
            "/" => value / value2,
            _ => throw new InvalidOperationException("不正な演算子です。")
        };
    }
}