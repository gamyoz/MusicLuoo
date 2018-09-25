using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MusicLuoo
{
    public class LoggerUtil
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Log(string message, Exception exception)
        {
            ErrorLog(message,exception);
        }

        public static void ErrorLog(string message, Exception ex)
        {
            List<string> str = new List<string>();
            str.Add("发生时间：" + DateTime.Now);
            str.Add("报错程序：" + message);
            str.Add("异常信息：" + ex.Message);
            str.Add("错误源：" + ex.Source);
            str.Add("堆栈信息：" + ex.StackTrace);
            str.Add("=========================================================");
            string fileName = Application.StartupPath + "/Logs/Errors/";
            FileHelper.FolderCreate(fileName);
            fileName += DateTime.Now.ToString("yyyyMMdd") + ".txt";
            FileHelper.WriteFile(fileName, str);
        }

        /// <summary>
        /// 系统操作日志
        /// </summary>
        public static void WriteLog(string id, string desc)
        {
            List<string> str = new List<string>();
            str.Add("发生时间：" + DateTime.Now);
            str.Add("对象ID：" + id);
            str.Add("描述：" + desc);
            str.Add("=========================================================");
            string fileName = Application.StartupPath + "~/Logs/System/";
            FileHelper.FolderCreate(fileName);
            fileName += DateTime.Now.ToString("yyyyMMdd") + ".txt";
            FileHelper.WriteFile(fileName, str);
        }
    }
}
