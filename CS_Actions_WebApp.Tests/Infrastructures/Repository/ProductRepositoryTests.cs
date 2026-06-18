using CS_Actions_WebApp.Infrastructures.Context;
using CS_Actions_WebApp.Infrastructures.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Testcontainers.PostgreSql;
namespace CS_Actions_WebApp.Tests.Infrastructures;

/// <summary>
/// ProductRepositoryの単体テストドライバ
/// </summary>
[TestClass]
public class ProductRepositoryTests
{
    // TestcontainersのPostgreSQLコンテナ
    private static PostgreSqlContainer _dbContainer = null!;

    /// <summary>
    /// テスト全体の初期化（コンテナの起動とデータ投入）
    /// </summary>
    [ClassInitialize]
    public static async Task ClassInit(TestContext context)
    {
        // PostgreSQL 17のコンテナを定義して起動
        _dbContainer = new PostgreSqlBuilder()
            .WithDatabase("ActionsDB")
            .WithImage("postgres:17-alpine")
            .Build();

        await _dbContainer.StartAsync();

        // テスト用のテーブル作成と初期データ投入のSQL
        var sql = @"
            CREATE TABLE product (
                id            INT         GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
                product_uuid  UUID        NOT NULL UNIQUE DEFAULT gen_random_uuid(),
                name          VARCHAR(30) DEFAULT NULL,
                price         INT         DEFAULT NULL
            );
            INSERT INTO product (product_uuid, name, price) VALUES
            ('ac413f22-0cf1-490a-9635-7e9ca810e544','水性ボールペン(黒)',120),
            ('8f81a72a-58ef-422b-b472-d982e8665292','水性ボールペン(赤)',120),
            ('d952b98c-a1ea-478d-8380-3b90fde872ea','水性ボールペン(青)',120),
            ('9959e553-c9da-4646-bd85-8663a3541583','油性ボールペン(黒)',100),
            ('79023e82-9197-40a5-b236-26487f404be4','油性ボールペン(赤)',100),
            ('7dfd0fd0-0893-4d20-83ef-6f70aab0ab76','油性ボールペン(青)',100),
            ('dc7243af-c2ce-4136-bd5d-c6b28ee0a20a','蛍光ペン(黄)',130),
            ('83fbc81d-2498-4da6-b8c2-54878d3b67ff','蛍光ペン(赤)',130),
            ('ee4b3752-3fbd-45fc-afb5-8f37c3f701c9','蛍光ペン(青)',130),
            ('35cb51a7-df79-4771-9939-7f32c19bca45','蛍光ペン(緑)',130),
            ('e4850253-f363-4e79-8110-7335e4af45be','鉛筆(黒)',100),
            ('5ca7dbdf-0010-44c5-a001-e4c13c4fe3a1','鉛筆(赤)',100),
            ('fbc43b9b-90a9-4712-925c-4d66a2a30372','色鉛筆(12色)',400),
            ('4b3db238-8ada-49b4-bb60-1a034914e528','色鉛筆(48色)',1300);";

        await _dbContainer.ExecScriptAsync(sql);
    }

    /// <summary>
    /// テスト全体の終了処理（コンテナの破棄）
    /// </summary>
    [ClassCleanup]
    public static async Task ClassCleanup()
    {
        await _dbContainer.DisposeAsync();
    }

    /// <summary>
    /// 商品一覧取得メソッドのテスト
    /// </summary>
    [TestMethod]
    public async Task SelectAllAsync_ShouldReturnAllProducts()
    {
        // 準備 (Arrange)
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(_dbContainer.GetConnectionString())
            .Options;
        using var context = new AppDbContext(options);
        var repository = new ProductRepository(context);

        // 実行 (Act)
        var products = await repository.SelectAllAsync();

        // 視覚的確認のためのログ出力
        Console.WriteLine("--- 取得した商品データ一覧 ---");
        foreach (var p in products)
        {
            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}円");
        }
        Console.WriteLine("------------------------------");

        // 検証 (Assert)
        Assert.HasCount(14, products);
        Assert.AreEqual("水性ボールペン(黒)", products[0].Name);
        Assert.AreEqual(1300, products[13].Price);
    }
}