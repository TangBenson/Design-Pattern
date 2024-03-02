using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simplefactory.pattern;


//抽象產品角色
public interface IFood
{
    string Name { get; }
    void Eat();
}

//具體產品角色 - 薯條
internal class Chips : IFood
{
    public string Name  => "薯條";

    public void Eat()
    {
        Console.WriteLine("吃薯條");
    }
}
//具體產品角色 - 麥香雞
internal class McChicken : IFood
{
    public string Name => "麥香雞";

    public void Eat()
    {
        Console.WriteLine("吃麥香雞");
    }
}

//工廠角色
public static class McdonladFactory
{
    private static readonly Dictionary<string, IFood> _foods = new()
    {
        { "Chips", new Chips() },
        { "McChicken", new McChicken() }
        //若要新增一種食物，需要在這裡加上，但這樣就算是修改現有代碼，違反開放封閉原則
    };
    public static IFood GetFood(string foodName)
    {
        return foodName switch
        {
            "Chips" => new Chips(),
            "McChicken" => new McChicken(),
            _ => throw new Exception("missing matching food name"),
        };

        // LINQ寫法較美
        // var food = _foods
        //     .Where(x => x.Key.Equals(foodName))
        //     .Select(x => x.Value)
        //     .FirstOrDefault();

        // return food ?? throw new Exception("無法生產這項食物!");
    }
}