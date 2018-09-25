using System;
using System.Configuration;

namespace MusicLuooUnity
{
    public static class ConnStr
    {
        public static string ConnectionWebRead
        {
            get { return PubConstant.GetConnectionString("ConnectionWebRead"); }
        }

        public static string ConnectionWebWrite
        {
            get { return PubConstant.GetConnectionString("ConnectionWebWrite"); }
        }
    }


    public class PubConstant
    {
        public static string GetAppSetting(string name)
        {
            try
            {
                return ConfigurationManager.AppSettings[name];
            }
            catch (Exception ex)
            {
                return "";
            }
            
        }
        public static string GetConnectSetting(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ToString();
        }
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string connectionString = GetConnectSetting("ConString");
                return connectionString; 
            }
        }

        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = GetConnectSetting(configName);
            return connectionString;
        }


    }
}
