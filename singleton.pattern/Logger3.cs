using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singleton.pattern;
public class Logger3
{
    // 版本: .Net Lazy<T>, 需要時才建立 _instance, Lazy<T> 是執行緒安全的
    private static Lazy<Logger3> _instance = new(() => new Logger3());

    // 建構子一律藏起來，做成 private
    private Logger3() => _logfile = File.OpenWrite("log.txt");

    // Singleton一律提共靜態 instance
    public static Logger3 Instance => _instance.Value;

    private readonly FileStream _logfile;

    public void Log(string msg)
    {
        // ....省略
    }
}