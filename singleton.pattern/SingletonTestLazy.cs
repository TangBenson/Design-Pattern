using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singleton.pattern;

//lazy單例模式，只有在需要時才創建實例
//網上的java版本範例
public class SingletonTestLazy
{
    //必須有一個私有的靜態成員變量，用於保存實例
    private static SingletonTestLazy _instance = null;
    private int _count = 0;

    // 必須有私有構造函數，防止外部直接創建實例
    private SingletonTestLazy()
    {
    }

    //必須有全域的靜態訪問點，因為只有靜態才能通過類名訪問
    //這寫法就=public static SingletonTestLazy Instance => _instance;
    public static SingletonTestLazy GetInstance(){
        //若實例為空，則創建實例
        return _instance ??= new SingletonTestLazy();
    }
}



//這是用c#的Lazy實作，但這也算是lazy單例模式?
//建議加上sealed關鍵字，防止被繼承，避免子類可以創建自己的實例
public sealed class SingletonTestLazy2
{
    // 使用Lazy<T>來確保只有在需要時才創建實例，並且保證線程安全
    private static readonly Lazy<SingletonTestLazy2> _instance = new(() => new SingletonTestLazy2());
    private int _count = 0;

    // 私有構造函數，防止外部直接創建實例
    private SingletonTestLazy2()
    {
        // 初始化操作
    }

    //訪問點
    public static SingletonTestLazy2 Instance => _instance.Value;

    //不該標記為static，因為這樣會使得外部可以直接訪問，破壞單例的設計，vscode蠢到要問設為static
    public void Show()
    {
        _count++;
        Console.WriteLine($"被調用了{_count}次");
    }
}
