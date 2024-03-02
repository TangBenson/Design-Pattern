using singleton.pattern;

Console.WriteLine("------------Start斗-----------");
var a1 = SingletonTestHungry.Instance;
var a2 = SingletonTestHungry.Instance;
a1.Show();
a2.Show();
Console.WriteLine(a1 == a2); //true，兩個實例是同一個實例
var b1 = SingletonTestLazy.GetInstance();
var b2 = SingletonTestLazy.GetInstance();
Console.WriteLine(b1 == b2); //true，兩個實例是同一個實例



Console.WriteLine("------------我的版本-----------");
SingletonTestLazy2.Instance.Show();
SingletonTestLazy2.Instance.Show();
SingletonTestLazy2.Instance.Show();
//調用三次都是同個實例，所以次數會累加

// SingletonTestLazy2 a = new(); //無法創建實例，因為構造函數是私有的。違反單例模式的設計

SingletonTestLazy2 i1 = SingletonTestLazy2.Instance;
SingletonTestLazy2 i2 = SingletonTestLazy2.Instance;
Console.WriteLine(i1 == i2); //true，兩個實例是同一個實例