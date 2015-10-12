using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork.Common.DBUtility
{
    /// <summary>
    /// 大批量插入数据到TargetPhone表中
    /// </summary>
    public static class TargetPhoneInsert
    {
        public static DataTable GetTargetPhoneSchema()
        {
            DataTable targetPhoneDT = new DataTable();
            targetPhoneDT.Columns.AddRange(new DataColumn[]{  
                 new DataColumn("ID",typeof(int)),  
                 new DataColumn("BatchID",typeof(Guid)),
                 new DataColumn("MsgID",typeof(string)),    
                 new DataColumn("Phone",typeof(string)),
                 new DataColumn("Status",typeof(int)),
                 new DataColumn("CreateDate",typeof(DateTime))});
            return targetPhoneDT;
        }
        public static bool Insert(DataTable sorceDataTable)
        {
            DataTable dt = sorceDataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return false;
            try
            {
                DbHelperSQL.BulkToDataTable(dt, "U_TargetPhone");
                return true;
            }
            catch (Exception ex)
            {
                DBLog.WriteLog("MideFrameWork.Common.DBUtility.TargetPhoneInsert.cs", "Insert", ex.ToString(), 0, 1);
                return false;
            }
            finally
            {
                dt = null;
            }
        }
    }
}
