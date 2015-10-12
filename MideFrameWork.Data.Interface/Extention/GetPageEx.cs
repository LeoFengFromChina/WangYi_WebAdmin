using System;
using System.Data;

namespace MideFrameWork.Framework.Data
{
    public partial interface IDataProvider
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
        DataSet GetRecordByPage(string fields, string tableValue, string IdentKey, string whereStr, string orderKey, int pageSize, int pageNumber, int isCount);
    }
}
