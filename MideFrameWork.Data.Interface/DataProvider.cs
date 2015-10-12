using System;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace MideFrameWork.Data.Interface
{
    /// <summary>
    /// 数据提供类
    /// </summary>
    public class DataProvider
    {
        private static IDataProvider _instance = null;

        private static object lockHelper = new object();
        static DataProvider()
        {
            GetProvider();
        }

        private static void GetProvider()
        {
            try
            {
                _instance = (IDataProvider)Activator.CreateInstance(Type.GetType("MideFrameWork.Data.SqlServer.DataProvider,MideFrameWork.Data.SqlServer", false, true));

            }
            catch (Exception ex)
            {
                throw new Exception("请检查Web.config中Dbtype节点数据库类型是否正确，例如：Sybase、SqlServer、Oracle、MySql.\r\n" + ex.ToString());
            }
        }

        /// <summary>
        /// 获取 CDC.Framework.Data.DataProvider 的实例
        /// </summary>
        /// <returns></returns>
        public static IDataProvider GetInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                    {
                        GetProvider();
                    }
                }
            }
            return _instance;
        }
    }
}
