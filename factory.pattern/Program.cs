/*
相比簡單工廠模式，若要新增一種鳥類，只需要新增一個鳥類別，不用修改任何原有的程式碼。
這樣的代碼真他媽的香啊！
*/

using factory.pattern;

//範例一
var eagleFactory = new EagleFactory();
var swanFactory = new SwanFactory();
var eagle = eagleFactory.CreateBird();
var swan = swanFactory.CreateBird();
Console.WriteLine($"Bird Name : {eagle.Name}");
Console.WriteLine($"Bird Name : {swan.Name}");
//範例二
IStoreFactory store = new Kfc();
Console.WriteLine($"Food Name : {store.CreateChip().Name}");

public interface IBird
{
    string Name { get; }
    void Fly();
}

internal class Eagle : IBird
{
    public string Name  => "老鷹";

    public void Fly()
    {
        // 實作可以飛高空
    }
}

internal class Swan : IBird
{
    public string Name => "天鵝";

    public void Fly()
    {
        // 實作只能飛低空
    }
}

//用abstract class也可以，但是C#不支援多重繼承，所以用interface比較好，不然EagleFactory只能繼承一個類別
public interface IBirdFactory
{
    IBird CreateBird();
}

public class EagleFactory : IBirdFactory
{
    public IBird CreateBird()
    {
        return new Eagle();
    }
}

public class SwanFactory : IBirdFactory
{
    public IBird CreateBird()
    {
        return new Swan();
    }
}
//若要新增一種鳥，只需要新增一個鳥類別，不用修改任何原有的程式碼。