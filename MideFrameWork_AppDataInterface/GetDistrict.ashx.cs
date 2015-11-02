using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// GetDistrict 的摘要说明
    /// </summary>
    public class GetDistrict : BaseForm, IHttpHandler
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
                string parentDistrictName = context.Request["ParentName"];
                List<RegionView> resultRegion = new List<RegionView>();
                IList<WG_RegionEntity> regionList;
                if (string.IsNullOrEmpty(parentDistrictName))
                {
                    //获取所有身份，parentid=0，0表示全国，父节点为0的所有身份
                    regionList = DataProvider.GetInstance().GetWG_RegionList(" ParentID= 0");
                }
                else
                {
                    //获取指定地区
                    regionList = DataProvider.GetInstance().GetWG_RegionList(" [name] = '" + parentDistrictName + "'");
                }

                //获取子地区
                foreach (WG_RegionEntity item in regionList)
                {
                    RegionView rv = new RegionView();
                    rv.CurrentRegion = item.Name;
                    rv.ChildRegion = GetChilds(item.ID);
                    resultRegion.Add(rv);
                }

                //获取子地区
                jbo.code = 0;
                jbo.data = resultRegion;
                jbo.message = "获取区域成功";
                jbo.success = false;

            }
            catch (Exception ex)
            {
                //失败
                jbo.code = -1;
                jbo.data = null;
                jbo.message = "接口调用过程中出现其他错误";
                jbo.success = false;
            }

            result = JsonSerializer<JsonBaseObject>(jbo);
            context.Response.Write(result);
        }

        private List<RegionView> GetChilds(int parentID)
        {
            List<RegionView> result = new List<RegionView>();
            //获取所有身份，parentid=0，0表示全国，父节点为0的所有身份
            IList<WG_RegionEntity> regionList = DataProvider.GetInstance().GetWG_RegionList(" ParentID= " + parentID);
            foreach (WG_RegionEntity item in regionList)
            {
                RegionView rv = new RegionView();
                rv.CurrentRegion = item.Name;
                rv.ChildRegion = GetChilds(item.ID);
                result.Add(rv);
            }

            return result;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    /// <summary>
    /// WG_Region:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class RegionView
    {
        private string _currentRegion = string.Empty;
        public string CurrentRegion
        {
            get
            {
                return _currentRegion;
            }
            set
            {
                _currentRegion = value;
            }
        }

        private List<RegionView> _childRegions = new List<RegionView>();
        public List<RegionView> ChildRegion
        {
            get
            {
                return _childRegions;
            }
            set
            {
                _childRegions = value;
            }
        }
    }
}