/*
把工廠模式再抽象一層的設計模式。把本來產生鳥類的介面 IBird 拆成的更細，例如鳥類的翅膀、鳥類的眼睛等等
*/
using abstractfactory.pattern;

//範例一
var eagleFactory = new EagleFactory();
var eagleSubasa = eagleFactory.CreateSubasa();
var eagleEye = eagleFactory.CreateEye();

var arcteryxFactory = new ArcTeryxFactory();
var arcteryxSubasa = arcteryxFactory.CreateSubasa();
var arcteryxEye = arcteryxFactory.CreateEye();

Console.WriteLine($"老鷹的翅膀是{eagleSubasa.Name}，眼睛是{eagleEye.Name}，可以飛{eagleSubasa.GetFlyDistance()}公里，可以看{eagleEye.GetSeeMeter()}公尺");
Console.WriteLine($"始祖鳥的翅膀是{arcteryxSubasa.Name}，眼睛是{arcteryxEye.Name}，可以飛{arcteryxSubasa.GetFlyDistance()}公里，可以看{arcteryxEye.GetSeeMeter()}公尺");

//範例二
IStoreFactory store = new Kfc();
IChicken chicken = store.CreateChicken();
chicken.Eat();

IStoreFactory store2 = new Mcdonald();
IChips chips = store2.CreateChip();
chips.Eat();

public interface ISubasa
{
    string Name { get; }
    int GetFlyDistance();
}

public interface IEye
{
    string Name { get; }
    int GetSeeMeter();
}
public class Subasa : ISubasa
{
    public string Name { get; set; }

    public int GetFlyDistance()
    {
        return Name switch
        {
            "天使之翼" => 1000,
            "惡魔之翼" => 900,
            "鳳凰之翼" => 1100,
            "鋼鐵之翼" => 500,
            "自然之翼" => 200,
            _ => 0
        };
    }
}
public class Eye : IEye
{
    public string Name { get; set; }

    public int GetSeeMeter()
    {
        return Name switch
        {
            "鷹眼" => 200,
            "白眼" => 500,
            "六眼" => 100,
            "血輪眼" => 500,
            "近視眼" => 1,
            _ => 0
        };
    }
}
public interface IBirdAbstractFactory
{
    ISubasa CreateSubasa();
    IEye CreateEye();
}
public class EagleFactory : IBirdAbstractFactory
{
    public ISubasa CreateSubasa()
    {
        return new Subasa { Name = "自然之翼" };
    }

    public IEye CreateEye()
    {
        return new Eye { Name = "鷹眼" };
    }
}
public class ArcTeryxFactory : IBirdAbstractFactory
{
    public ISubasa CreateSubasa()
    {
        return new Subasa { Name = "鳳凰之翼" };
    }

    public IEye CreateEye()
    {
        return new Eye { Name = "血輪眼" };
    }
}