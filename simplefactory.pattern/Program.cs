
//抽象產品角色
public interface IBird
{
    string Name { get; set; }
    void Fly();
}

//具體產品角色
public class Eagle : IBird
{
    public string Name { get; set; } = "老鷹";

    public void Fly()
    {
        // 實作可以飛高空
    }
}

public class Swan : IBird
{
    public string Name { get; set; } = "天鵝";

    public void Fly()
    {
        // 實作只能飛低空
    }
}

//工廠角色：使用 switch 實作
public static class BirdFactory
{
    private static readonly Dictionary<string, IBird> _birds;
    static BirdFactory()
    {
        _birds = new Dictionary<string, IBird>();
        _birds.Add("Eagle", new Eagle());
        _birds.Add("Swan", new Swan());
    }
    public static IBird GetBird(string birdName)
    {
        // switch (birdName)
        // {
        //     case "Swan":
        //         return new Swan();

        //     case "Eagle":
        //         return new Eagle();

        //     default:
        //         throw new Exception("missing matching bird name");
        // }

        // LINQ寫法較美
        var bird = _birds
            .Where(x => x.Key.Equals(birdName))
            .Select(x => x.Value)
            .FirstOrDefault();

        return bird ?? throw new Exception("No match bird!");
    }
}


// 客戶端，不直接new物件，而是透過工廠取得物件，降低耦合，萬一物件改變，只要改工廠就好
var eagle = BirdFactory.GetBird("Eagle");
var swan = BirdFactory.GetBird("Swan");
Console.WriteLine($"Bird Name : {eagle.Name}");
Console.WriteLine($"Bird Name : {swan.Name}");