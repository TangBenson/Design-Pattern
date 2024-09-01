using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singleton.pattern;
public class Logger
{
    // 版本: 基本型, Eager Initialization, 直接建立靜態 instance, 執行緒安全
    private static readonly Logger _instance = new();

    // 建構子一律藏起來，做成 private
    private Logger() => _logfile = File.OpenWrite("log.txt");

    // Singleton一律提共靜態 instance
    public static Logger Instance => _instance;

    private readonly FileStream _logfile;

    public void Log(string msg)
    {
        // ....省略
    }
}