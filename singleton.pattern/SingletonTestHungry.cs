using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singleton.pattern;

//hungry單例模式，類加載時就創建實例
public class SingletonTestHungry
{
    //必須有一個私有的靜態成員變量，用於保存實例
    private static SingletonTestHungry _instance = new();
    private int _count = 0;

    // 必須有私有構造函數，防止外部直接創建實例
    private SingletonTestHungry()
    {
    }

    //必須有全域的靜態訪問點，因為只有靜態才能通過類名訪問
    public static SingletonTestHungry Instance => _instance;


    public void Show()
    {
        _count++;
        Console.WriteLine($"被調用了{_count}次");
    }
}
