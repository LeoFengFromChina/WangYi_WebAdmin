using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MideFrameWork.Common.DBUtility;
using System.Data;

namespace MideFrameWork.UI.WebSite.Admin
{
    public partial class _CommonSelectBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //......aspx?keywords=&tableName=WG_Education&displaycolumns=*&callbackcolumns=id,name
            string _keyWord = "1 =1 " + Request["keywords"];//
            string _tableName = Request["tablename"];
            string _displayColumns = Request["displaycolumns"];
            string _callBackColumns = Request["callbackcolumns"];

            string whereSql = _keyWord.Replace('-', '=').Replace(",", " AND ");


            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  " + _displayColumns + " FROM " + _tableName + " WHERE " + _keyWord);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    GridView1.HeaderRow.Cells[i].Text = ds.Tables[0].Columns[i].Caption;
                }
            }
        }
    }
}