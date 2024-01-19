using singleton.pattern;

SingletonTest.Instance.Show();
SingletonTest.Instance.Show();
SingletonTest.Instance.Show();
//調用三次都是同個實例，所以次數會累加

// SingletonTest a = new(); //無法創建實例，因為構造函數是私有的。違反單例模式的設計

SingletonTest i1 = SingletonTest.Instance;
SingletonTest i2 = SingletonTest.Instance;
Console.WriteLine(i1 == i2); //true，兩個實例是同一個實例