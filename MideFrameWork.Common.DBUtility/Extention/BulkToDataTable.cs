using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;

namespace MideFrameWork.Common.DBUtility
{
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) Maticsoft
    /// </summary>
    public partial class DbHelperSQL
    {
        /// <summary>
        /// 批量插入数据表
        /// </summary>
        /// <param name="dt">内容表</param>
        /// <param name="DestinationTableName">插入目标表名</param>
        public static void BulkToDataTable(DataTable FromDataTable, string DestinationTableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(conn);
                bulkCopy.DestinationTableName = DestinationTableName;
                bulkCopy.BatchSize = FromDataTable.Rows.Count;
                try
                {
                    conn.Open();
                    if (FromDataTable != null && FromDataTable.Rows.Count > 0)
                        bulkCopy.WriteToServer(FromDataTable);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                    if (bulkCopy != null)
                        bulkCopy.Close();
                }
            }
        }

        /// <summary>
        /// 扣费事务
        /// </summary>
        /// <param name="SQLStringList">事务中的SQL语句</param>
        /// <param name="FromDataTable">目标发送号码</param>
        public static void FeeDeductionTran(Hashtable SQLStringList, DataTable FromDataTable)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //批量插入号码
                        BulkToDataTable(FromDataTable, "U_TargetPhone");

                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                        //if (bulkCopy != null)
                        //    bulkCopy.Close();
                    }
                }
            }
        }
    }

}
