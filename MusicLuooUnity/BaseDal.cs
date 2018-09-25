using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Kamsoft.Data.Dapper;

namespace MusicLuooUnity
{
    public class BaseDal
    {
        /// <summary>
        /// 查询实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<T> Query<T>(string sql, string conn = "") where T : new()
        {
            if (string.IsNullOrEmpty(conn)) conn = ConnStr.ConnectionWebRead;
            List<T> list;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                list = connection.Query<T>(sql).ToList();
                connection.Close();
                connection.Dispose();
            }
            return list;
        }

        /// <summary>
        /// 查询实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public List<T> Query<T>(string sql, ref DynamicParameters parameters, string conn = "")
        {
            if (string.IsNullOrEmpty(conn)) conn = ConnStr.ConnectionWebRead;
            List<T> list;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                list = connection.Query<T>(sql, parameters).ToList();
                connection.Close();
                connection.Dispose();
            }
            return list;
        }

        /// <summary>
        /// 返回单个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public T QueryFirst<T>(string sql, ref DynamicParameters parameters, string conn = "") where T : class
        {
            if (string.IsNullOrEmpty(conn)) conn = ConnStr.ConnectionWebRead;
            T list;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                list = connection.Query<T>(sql, parameters).FirstOrDefault();
                connection.Close();
                connection.Dispose();
            }
            return list;
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int Execute(string sql, ref DynamicParameters parameters, string conn = "")
        {
            if (string.IsNullOrEmpty(conn)) conn = ConnStr.ConnectionWebRead;
            int result = 0;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                try
                {
                    result = connection.Execute(sql, parameters);
                }
                catch (Exception ex)
                {
                    LoggerUtil.ErrorLog("Execute", ex);
                    LoggerUtil.ErrorLog("Execute", new Exception(ex.Message+"|"+sql));
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return result;
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public void ExecuteProcedure(string sql, ref DynamicParameters parameters, string conn = "")
        {
            if (string.IsNullOrEmpty(conn)) conn = ConnStr.ConnectionWebRead;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Execute(sql, parameters, null, null, CommandType.StoredProcedure);
                connection.Close();
                connection.Dispose();
            }
        }
        /// <summary>
        /// 记录条数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public int Count(string sql, ref DynamicParameters parameters, string conn = "")
        {
            if (string.IsNullOrEmpty(conn)) conn = ConnStr.ConnectionWebRead;
            int result;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                result = connection.Query<int>(sql, parameters).FirstOrDefault();
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public bool Exists(string sql, ref DynamicParameters parameters, string conn = "")
        {
            if (string.IsNullOrEmpty(conn)) conn = ConnStr.ConnectionWebRead;
            int result;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                result = connection.Query<int>(sql, parameters).FirstOrDefault();
                connection.Close();
                connection.Dispose();
            }
            return result > 0;
        }

    }
}
