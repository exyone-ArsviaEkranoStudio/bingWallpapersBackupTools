using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
class bingWallpapersBackupTools
{
    static void Main(string[] args)
    {
        Console.WriteLine("运行本程序以备份必应每日壁纸,是否继续(y/n)");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "y")
        {
            Console.WriteLine("正在备份必应每日壁纸,请稍后...");
            try
            {
                Copy();
                Console.WriteLine("备份完成,请前往桌面bingWallpapers文件夹查看");
            }
            catch (Exception ex)
            {
                Console.WriteLine("备份失败: " + ex.Message);
            }
            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
        else if (answer.ToLower() == "n")
        {
            Console.WriteLine("已取消操作");
        }
        else
        {
            Console.WriteLine("输入无效,程序已退出");
        }
    }
    public static void Copy()
    {
        string sourceDir = Environment.ExpandEnvironmentVariables(
            @"%localappdata%\Packages\Microsoft.BingWallpaper_8wekyb3d8bbwe\LocalState\images\bing");
        string destDir = Environment.ExpandEnvironmentVariables(
            @"%userprofile%\Desktop\bingWallpapers");

        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }
        foreach (string subDir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
            CopyDirectory(subDir, destSubDir);
        }
    }
    public static void CopyDirectory(string sourceDir, string destDir)
    {
        if (!Directory.Exists(destDir))
        {
            Directory.CreateDirectory(destDir);
        }
        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string destFile = Path.Combine(destDir, Path.GetFileName(file));
            File.Copy(file, destFile, true);
        }
        foreach (string subDir in Directory.GetDirectories(sourceDir))
        {
            string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
            CopyDirectory(subDir, destSubDir);
        }
    }
}
