using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CS_Actions_WebApp.Infrastructures.Entity;
/// <summary>
/// 商品を扱うエンティティクラス
/// </summary>
[Table("product")]
public class Product
{
    /// <summary>
    /// レコード識別ID
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }

    /// <summary>
    /// 商品Id
    /// </summary>
    [Column("product_uuid")]
    public Guid ProductUuid { get; set; }

    /// <summary>
    /// 商品名
    /// </summary>
    [Column("name")]
    [StringLength(30)]
    public string? Name { get; set; }

    /// <summary>
    /// 価格
    /// </summary>
    [Column("price")]
    public int? Price { get; set; }
}