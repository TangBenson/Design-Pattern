/*
客戶端，不直接new物件，而是透過工廠取得物件，降低耦合，萬一物件改變，只要改工廠就好
缺點：違反開放封閉原則，如果要新增一種鳥，就要修改工廠，不符合開放封閉原則
也就是需要修改BirdFactory，在switch裡面加上新的case或是修改Dictionary，
但開放封閉原則希望你用新增的方式取代修改，也就是若要新增一種鳥，就要新增一個類別，而不是修改原本的BirdFactory，
如何解決請看我的FactoryMethod Pattern

另外應該把具體產品角色的類別設為內部類別，這樣客戶端就無法直接new物件，只能透過工廠取得物件，降低耦合，但目前這個範例沒有這樣做
*/

using simplefactory.pattern;

//範例一
var eagle = BirdFactory.GetBird("Eagle");
var swan = BirdFactory.GetBird("Swan");
Console.WriteLine($"Bird Name : {eagle.Name}");
Console.WriteLine($"Bird Name : {swan.Name}");
//範例二
var food1 = McdonladFactory.GetFood("Chips");
var food2 = McdonladFactory.GetFood("McChicken");
// var food3 = McdonladFactory.GetFood("Burger");
Console.WriteLine($"Food Name : {food1.Name}");
Console.WriteLine($"Food Name : {food2.Name}");
// Console.WriteLine($"Food Name : {food3.Name}");

//抽象產品角色
public interface IBird
{
    string Name { get; }
    void Fly();
}

//具體產品角色
public class Eagle : IBird
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

//工廠角色：使用 switch 實作
public static class BirdFactory
{
    private static readonly Dictionary<string, IBird> _birds = new()
    {
        { "Swan", new Swan() },
        { "Eagle", new Eagle() }
        //若要新增一種鳥，需要在這裡加上，但這樣就算是修改現有代碼，違反開放封閉原則
    };
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
