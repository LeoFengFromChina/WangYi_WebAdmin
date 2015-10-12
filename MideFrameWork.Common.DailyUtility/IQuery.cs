using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MideFrameWork.Common.DailyUtility
{
    public enum OrderType
    {
        Asc = 0, Desc = 1
    }
    public interface IQuery
    {
        /// <summary>
        /// 返回结果包含的列，列之间用逗号分隔，*表示所有列
        /// </summary>
        string Columns { get; set; }
        /// <summary>
        /// 查询时的主排序字段
        /// </summary>
        string OrderColumn { get; set; }
        /// <summary>
        /// 主排序字段的排序方式
        /// </summary>
        OrderType OrderType { get; set; }
        /// <summary>
        /// 查询条件
        /// </summary>
        string WhereStr { get; set; }
        /// <summary>
        /// 副排序字段，多列用逗号分隔，如："ID Asc,Name Desc"
        /// </summary>
        string OrderBy { get; set; }
    }


    [Serializable()]
    public class QueryEntity : IQuery
    {
        #region IQuery 成员
        private string columns = "*";
        public string Columns
        {
            get
            {
                return columns;
            }
            set
            {
                columns = value;
            }
        }
        private string orderColumn = "ID";
        public string OrderColumn
        {
            get
            {
                return orderColumn;
            }
            set
            {
                orderColumn = value;
            }
        }
        private OrderType orderType = OrderType.Asc;
        public OrderType OrderType
        {
            get
            {
                return orderType;
            }
            set
            {
                orderType = value;
            }
        }
        private string whereStr = "";
        public string WhereStr
        {
            get
            {
                return whereStr;
            }
            set
            {
                whereStr = value;
            }
        }
        private string orderBy = "";
        public string OrderBy
        {
            get
            {
                return orderBy;
            }
            set
            {
                orderBy = value;
            }
        }

        #endregion
    }
}
