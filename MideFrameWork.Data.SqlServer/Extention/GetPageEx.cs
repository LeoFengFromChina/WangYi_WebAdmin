using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using MideFrameWork.Common.DBUtility;
using MideFrameWork.Data.Interface;
using MideFrameWork.Data.SqlServer;
using MideFrameWork.Data.Entity;
using System.Data.SqlClient;

namespace MideFrameWork.Data.SqlServer
{
    public partial class DataProvider : IDataProvider
    {
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="fields">需要返回的列（如：* || a.*,b.Classdesc ）</param>
        /// <param name="tableValue">查询的表或多个表（如：Common.Logs || t_news a left join T_NewsClass b on a.ClassId = b.ClassId ）</param>
        /// <param name="IdentKey">表主键字段名（如：ID  || a.newsid）</param>        
        /// <param name="whereStr">查询条件 (注意: 不要加 where)（如：1=1 ）</param>
        /// <param name="orderKey">排序（如：CreatedTime desc || a.focus desc）</param>
        /// <param name="pageSize">每页的行数</param>
        /// <param name="pageNumber">要显示的页码, 从1开始</param>
        /// <param name="isCount">是否需要统计记录总数，1表示要，0表示不要</param>
        /// <returns>查询结果记录集</returns>
        public DataSet GetRecordByPage(string tableValue, string fields, string orderKey, string whereStr, int pageSize, int pageNumber)
        {
            SqlParameter[] parameters ={						
                                           
                                new SqlParameter("@TableName",SqlDbType.VarChar,50),
                                new SqlParameter("@Fields",SqlDbType.VarChar,5000),
                                new SqlParameter("@OrderField",SqlDbType.VarChar,5000),                           
                                new SqlParameter("@SqlWhere",SqlDbType.VarChar,1500),
                                new SqlParameter("@PageSize",SqlDbType.Int,4),
                                new SqlParameter("@PageIndex",SqlDbType.Int,4)
           };

            parameters[0].Value = tableValue;
            parameters[1].Value = fields;
            parameters[2].Value = orderKey;
            parameters[3].Value = whereStr;
            parameters[4].Value = pageSize;
            parameters[5].Value = pageNumber;

            DataSet ds = DbHelperSQL.RunProcedure("[dbo].[up_GetPage]", parameters);
            return ds;
        }
    }
}
