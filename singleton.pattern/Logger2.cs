using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singleton.pattern;
public class Logger2
{
    // 版本: 基本型, Lazy initialization, 使用 lock(), 執行緒安全
    private static Logger2? _instance = null;

    // 建構子一律隱藏起來，做成 private
    private Logger2() => _logfile = File.OpenWrite("log.txt");

    // Singleton一律提共靜態 instance
    private static object _locker = new();
    public static Logger2 Instance
    {
        get
        {
            if (_instance is null)
                lock (_locker)
                {
                    _instance ??= new Logger2();
                }
            return _instance;
        }
    }
    private readonly FileStream _logfile;
}
