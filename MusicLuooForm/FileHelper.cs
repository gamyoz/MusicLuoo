using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MusicLuoo
{
    public class FileHelper
    {
        #region 取得文件名
        /// <summary>
        /// 取得文件名
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <param name="extension">是否返回文件扩展名</param>
        /// <returns></returns>
        public static string GetPostfixStr(string filename, bool extension = false)
        {
            return extension ? Path.GetExtension(filename) : Path.GetFileNameWithoutExtension(filename);
        }
        #endregion

        #region 写文件
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="xFile">文件路径</param>
        /// <param name="xContent">文件内容</param>
        /// <param name="append">编辑时是否append到文件后面</param>
        /// <returns>文件操作状态，Create为创建新文件，Edit为编辑旧文件</returns>
        public static string WriteFile(string xFile, List<string> xContent,bool append = true)
        {
            string fRes;
            if (!File.Exists(xFile))
            {
                File.Create(xFile).Close();
                fRes = "Create";
            }
            else
                fRes = "Edit";
            StreamWriter w = new StreamWriter(xFile, append);
            foreach (var str in xContent)
                w.WriteLine(str);
            w.Flush();
            w.Close();
            return fRes;
        }/// <summary>
        /// 写文件
        /// </summary>
        /// <param name="xFile">文件路径</param>
        /// <param name="xContent">文件内容</param>
        /// <param name="append">编辑时是否append到文件后面</param>
        /// <returns>文件操作状态，Create为创建新文件，Edit为编辑旧文件</returns>
        public static string WriteFile(string xFile, string xContent, bool append = true)
        {
            return WriteFile(xFile,new List<string>{xContent},append);
        }
        #endregion

        #region 读文件
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="xFile">文件路径</param>
        /// <returns></returns>
        public static string FileRead(string xFile)
        {
            string fRes;
            if (!File.Exists(xFile)) { fRes = "\0"; }
            else
            {
                FileStream fs = new FileStream(xFile, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default, true); // 
                fRes = sr.ReadToEnd();
                fs.Close();
            }
            return fRes;
        }
        #endregion

        #region 创建目录
        /// <summary>
        /// 若目录不存在则创建目录
        /// </summary>
        /// <param name="orignFolder">目录</param>
        public static void FolderCreate(string orignFolder)
        {
            if(!Directory.Exists(orignFolder))
                Directory.CreateDirectory(orignFolder);
        }
        #endregion

        #region 递归删除文件夹目录及文件
        /// <summary>
        /// 递归删除文件夹目录及文件
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static void DeleteFolder(string dir)
        {
            if (Directory.Exists(dir)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件 
                    else
                        DeleteFolder(d); //递归删除子文件夹 
                }
                Directory.Delete(dir); //删除已空文件夹 
            }

        }

        #endregion

        #region 显示文件列表
        /// <summary>
        /// 显示文件列表
        /// </summary>
        /// <param name="xPath">文件路径</param>
        /// <returns>返回文件名、文件类型、大小、创建日期、最后编辑日期</returns>
        public static DataTable GetFileList(string xPath)
        {
            Directory.CreateDirectory(xPath);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("Object Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Size", typeof(string)));
            dt.Columns.Add(new DataColumn("Date Created", typeof(string)));
            dt.Columns.Add(new DataColumn("Date Modified", typeof(string)));
            DirectoryInfo cd = new DirectoryInfo(xPath + "\\");
            foreach (DirectoryInfo dir in cd.GetDirectories())
            {
                dr = dt.NewRow();
                dr[0] = dir.Name;
                dr[1] = "Dir.";
                dr[2] = "";
                dr[3] = dir.CreationTime.ToString("yy-MM-dd HH:mm");
                dr[4] = dir.LastWriteTime.ToString("yy-MM-dd HH:mm");
                dt.Rows.Add(dr);
            }
            foreach (FileInfo fil in cd.GetFiles())
            {
                dr = dt.NewRow();
                dr[0] = fil.Name;
                dr[1] = "File";
                dr[2] = fil.Length;
                dr[3] = fil.CreationTime.ToString("yy-MM-dd HH:mm");
                dr[4] = fil.LastWriteTime.ToString("yy-MM-dd HH:mm");
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

    }
}
