using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singleton.pattern;

//這是一個要宣告為單例的類別
//建議加上sealed關鍵字，防止被繼承，避免子類可以創建自己的實例
public sealed class SingletonTest
{
    // 使用Lazy<T>來確保只有在需要時才創建實例，並且保證線程安全
    private static readonly Lazy<SingletonTest> _instance = new(() => new SingletonTest());
    private int _count = 0;

    // 私有構造函數，防止外部直接創建實例
    private SingletonTest()
    {
        // 初始化操作
    }

    //訪問點
    public static SingletonTest Instance => _instance.Value;

    //不該標記為static，因為這樣會使得外部可以直接訪問，破壞單例的設計，vscode蠢到要問設為static
    public void Show()
    {
        _count++;
        Console.WriteLine($"被調用了{_count}次");
    }
}
