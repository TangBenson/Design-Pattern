using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abstractfactory.pattern;


public interface IChips
{
    string Name { get; }
    void Eat();
}
public interface IChicken
{
    string Name { get; }
    void Eat();
}

internal class McChips : IChips
{
    public string Name  => "賣噹噹薯條";

    public void Eat()
    {
    }
}

internal class KfcChips : IChips
{
    public string Name => "老爺爺薯條";

    public void Eat()
    {
    }
}

internal class OrleanChicken : IChicken
{
    public string Name => "奧爾良烤翅";

    public void Eat()
    {
    }
}
internal class McChicken : IChicken
{
    public string Name => "賣噹噹烤翅";

    public void Eat()
    {
    }
}

//用abstract class也可以，但是C#不支援多重繼承，所以用interface比較好，不然EagleFactory只能繼承一個類別
public interface IStoreFactory
{
    IChips CreateChip();
    IChicken CreateChicken();
}

public class Mcdonald : IStoreFactory
{
    public IChips CreateChip()
    {
        Console.WriteLine("Mcdonald");
        return new McChips();
    }
    public IChicken CreateChicken()
    {
        Console.WriteLine("Mcdonald烤翅");
        return new McChicken();
    }
}

public class Kfc : IStoreFactory
{
    public IChips CreateChip()
    {
        Console.WriteLine("Kfc");
        return new KfcChips();
    }
    public IChicken CreateChicken()
    {
        Console.WriteLine("Kfc奧爾良烤翅");
        return new OrleanChicken();
    }
}
//若要新增一種鳥，只需要新增一個鳥類別，不用修改任何原有的程式碼。