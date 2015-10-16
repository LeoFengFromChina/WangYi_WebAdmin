using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetHelpRequestList 的摘要说明
    /// </summary>
    public class GetRankList : BaseForm, IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            context.Response.AddHeader("Access-Control-Allow-Methods", "POST");
            context.Response.AddHeader("Access-Control-Allow-Headers", "x-requested-with,content-type");
            context.Response.ContentType = "text/plain";

            JsonBaseObject jbo = new JsonBaseObject();
            string result = string.Empty;

            try
            {

                //排名分为全国、全省、全市、全区、本小区
                string country = context.Request["country"];//全国
                string province = context.Request["province"];//广东
                string city = context.Request["city"];//广州
                string district = context.Request["district"];//天河
                string community = context.Request["community"];//羊城花园

                string whereStr = " 1=1 ";
                if (!string.IsNullOrEmpty(country))
                    whereStr += " AND Country='" + country + "' ";
                else if (!string.IsNullOrEmpty(province))
                    whereStr += " AND Province='" + province + "' ";
                else if (!string.IsNullOrEmpty(city))
                    whereStr += " AND City='" + city + "'";
                else if (!string.IsNullOrEmpty(district))
                    whereStr += " AND District='" + district + "' ";
                else if (!string.IsNullOrEmpty(community))
                    whereStr += " AND Community='" + community + "' ";
                else
                    whereStr += "";


                string PageIndex = "1";
                if (!string.IsNullOrEmpty(context.Request["PageIndex"]))
                    PageIndex = context.Request["PageIndex"];

                //IList<WG_OnGoingGiftsEntity> OnGoingGiftList = DataProvider.GetInstance().GetWG_OnGoingGiftsList(whereStr);
                int recordCount = -1;
                int pageCount = -1;
                // 查找条件：如typeid=1 and promoterid=1 and undertakerid=1
                IList<WG_MenberEntity> menberList = DataProvider.GetInstance().GetWG_MenberList(20, int.Parse(PageIndex), " WHERE " + whereStr, " ServiceHours Desc ", out recordCount, out pageCount);

                //如果所有数据分页后的总页数比请求的页数小，则返回空。
                if (int.Parse(PageIndex) > pageCount)
                    menberList.Clear();

                //SqlParameter[] parameters ={
                //                               new SqlParameter("@Country",SqlDbType.NVarChar,64),
                //                               new SqlParameter("@Province",SqlDbType.NVarChar,64),
                //                               new SqlParameter("@City",SqlDbType.NVarChar,64),
                //                               new SqlParameter("@District",SqlDbType.NVarChar,64),
                //                               new SqlParameter("@Community",SqlDbType.NVarChar,64)
                //                           };
                //parameters[0].Value = country;
                //parameters[1].Value = province;
                //parameters[2].Value = city;
                //parameters[3].Value = district;
                //parameters[4].Value = community;
                //DataSet ds = DbHelperSQL.RunProcedure("[dbo].[up_MenberRanking]", parameters);
                if (menberList != null && menberList.Count > 0)
                {
                    IList<MenberRankingView> list = new List<MenberRankingView>();
                   
                    // 组装
                    for (int i = 0; i < menberList.Count; i++)
                    {
                        MenberRankingView mrv = new MenberRankingView();
                        mrv.ID = menberList[i].ID;
                        mrv.Name = menberList[i].Name;
                        mrv.NickName = menberList[i].NickName;
                        mrv.ServiceHours = menberList[i].ServiceHours.ToString();
                        mrv.Rank = i + 1;
                        mrv.CreateDate = menberList[i].CreateDate.ToString();
                        list.Add(mrv);
                    }
                    //数据
                    jbo.code = 0;
                    jbo.data = list;
                    jbo.message = "成功。";
                    jbo.success = true;

                }
                else
                {
                    //没有任何数据
                    jbo.code = -1;
                    jbo.data = null;
                    jbo.message = "没有找到任何数据。";
                    jbo.success = false;
                }
            }
            catch (Exception ex)
            {
                //没有任何数据
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现其他错误。";
                jbo.success = false;
            }

            result = JsonSerializer<JsonBaseObject>(jbo);
            context.Response.Write(result);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private MenberRankingView GetArticle(DataRow dr)
        {
            MenberRankingView info = new MenberRankingView();
            if (DBNull.Value == dr["ID"])
                info.ID = 0;
            else
                info.ID = int.Parse(dr["ID"].ToString());
            if (DBNull.Value == dr["Ranking"])
                info.Rank = 0;
            else
                info.Rank = int.Parse(dr["Ranking"].ToString()); ;

            if (DBNull.Value == dr["NickName"])
                info.NickName = string.Empty;
            else
                info.NickName = dr["NickName"].ToString();

            if (DBNull.Value == dr["Name"])
                info.Name = string.Empty;
            else
                info.Name = dr["Name"].ToString();

            if (DBNull.Value == dr["ServiceHours"])
                info.ServiceHours = string.Empty;
            else
                info.ServiceHours = dr["ServiceHours"].ToString();

            if (DBNull.Value == dr["CreateDate"])
                info.CreateDate = string.Empty;
            else
                info.CreateDate = dr["CreateDate"].ToString();

            return info;
        }
    }

}

public class MenberRankingView
{
    public int Rank { get; set; }
    public int ID { get; set; }
    public string NickName { get; set; }
    public string Name { get; set; }
    public string ServiceHours { get; set; }
    public string CreateDate { get; set; }
}