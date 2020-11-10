using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Doctor_MaxOne_Four.DAL
{
    /// <summary>
    /// DBHelper
    /// </summary>
    public class DBHelper
    {
        string str = "";
        //显示  返回datatable类型
        /// <summary>
        /// 显示，返回datatable类型，需要转化为List类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetShow(string sql)
        {
            using (SqlConnection con = new SqlConnection(str))
            { 
                con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            var dt = new DataTable();
            sda.Fill(dt);
            return dt;
            }
        }
        //显示
        /// <summary>
        /// 返回List类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetShow<T>(string sql)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                sda.Fill(dt);
                var list = DatatabletoList<T>(dt);
                return list;
            }
        }
        //datatable  转   list
        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<T> DatatabletoList<T>(DataTable dt)
        {

            List<T> list = new List<T>();
            Type type = typeof(T);
            PropertyInfo[] pro = type.GetProperties();
            foreach (DataRow item in dt.Rows)
            {
                T t = (T)Activator.CreateInstance(type);
                foreach (var p in pro)
                {
                    var name = p.Name;
                    object value = item[name];
                    p.SetValue(t, value, null);
                }
                list.Add(t);
            }
            return list;
        }
        //CMD
        /// <summary>
        /// 实现增删改功能
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public int CMD(string sql)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                return com.ExecuteNonQuery();
            }
        }
        //登录
        /// <summary>
        /// 实现登录功能
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public object Deng(string sql)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand com = new SqlCommand(sql, con);
                return com.ExecuteScalar();
            }
        }
        /// <summary>
        /// 存储过程又有输出类型
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <param name="dic">字典对应的值</param>
        /// <param name="outname">输出参数</param>
        /// <param name="id">输出</param>
        /// <returns></returns>
        public DataSet Proc(string name, Dictionary<string, object> dic, string outname, out object id)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();
                SqlCommand com = new SqlCommand(name, con);
                com.CommandType = CommandType.StoredProcedure;
                foreach (var item in dic)
                {
                    SqlParameter par = new SqlParameter();
                    par.ParameterName = item.Key;
                    if (item.Key.ToLower().Equals(outname))
                    {
                        par.Direction = ParameterDirection.Output;
                        par.SqlDbType = SqlDbType.Int;
                        par.Size = 10;
                    }
                    else
                    {
                        par.Value = item.Value;
                    }
                    com.Parameters.Add(par);
                }
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataSet sd = new DataSet();
                sda.Fill(sd);
                id = (int)com.Parameters[outname].Value;
                return sd;
            }
        }
        /// <summary>
        ///  执行不带参数的增删改SQL语句或存储过程
        /// </summary>
        /// <param name="cmdText">增删改SQL语句或存储过程</param>
        /// <param name="ct">命令类型</param>
        /// <returns></returns>
        public  int ExecuteNonQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            using (SqlConnection con = new SqlConnection(str))
            {
                int res;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(cmdText, con);
                    cmd.CommandType = ct;
                    cmd.Parameters.AddRange(paras);
                    res = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }

                return res;
            }
               
        }

    }
}
