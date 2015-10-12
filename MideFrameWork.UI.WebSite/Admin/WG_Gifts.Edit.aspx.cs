using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using MideFrameWork.Common.DBUtility;
using System.Collections;

namespace MideFrameWork.UI.WebSite.Admin
{
    public partial class WG_GiftsEdit : BaseForm
    {
        private string ctrID
        {
            get
            {
                if (ViewState["ctrID"] != null)
                    return (string)ViewState["ctrID"];
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["ctrID"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ctrID = Request.QueryString["ctrID"];

            //初始化日期选择事件










            //表单提交事件
            Button_submit.Click += new EventHandler(Button_submit_Click);

            init_form(ctrID);
        }

        void Button_submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrID))
            {
                WG_GiftsAdd();
            }
            else
            {
                WG_GiftsEditFunc(ctrID);
            }
        }

        #region 初始化表单
        WG_GiftsEntity _WG_GiftsEntity = null;
        protected void init_form(string ctrID)
        {
            if (!string.IsNullOrEmpty(ctrID))
            {
                _WG_GiftsEntity = DataProvider.GetInstance().GetWG_GiftsEntity(int.Parse(ctrID));

                TextBox_Title.Text = _WG_GiftsEntity.Title.ToString();
                TextBox_PhotoUrl.Text = _WG_GiftsEntity.PhotoUrl.ToString();
                TextBox_NeedScores.Text = _WG_GiftsEntity.NeedScores.ToString();
                TextBox_Count.Text = _WG_GiftsEntity.Count.ToString();
                TextBox_Detail.Text = _WG_GiftsEntity.Detail.ToString();
                TextBox_RegionID.Text = _WG_GiftsEntity.RegionID.ToString();
            }
        }
        #endregion

        #region 新增
        protected void WG_GiftsAdd()
        {
            #region 判断是否可空


            var _Title = Request.Form["TextBox_Title"];
            if (string.IsNullOrEmpty(_Title))
            {
                Alert("[ 礼物名称 ]不能为空");
                return;
            }

            var _PhotoUrl = Request.Form["TextBox_PhotoUrl"];
            if (string.IsNullOrEmpty(_PhotoUrl))
            {
                Alert("[ 图片地址 ]不能为空");
                return;
            }

            var _NeedScores = Request.Form["TextBox_NeedScores"];
            if (string.IsNullOrEmpty(_NeedScores))
            {
                Alert("[ 所需积分 ]不能为空");
                return;
            }

            var _Count = Request.Form["TextBox_Count"];
            if (string.IsNullOrEmpty(_Count))
            {
                Alert("[ 礼物数量 ]不能为空");
                return;
            }

            var _Detail = Request.Form["TextBox_Detail"];
            if (string.IsNullOrEmpty(_Detail))
            {
                Alert("[ 详细说明 ]不能为空");
                return;
            }

            var _RegionID = Request.Form["TextBox_RegionID"];
            if (string.IsNullOrEmpty(_RegionID))
            {
                Alert("[ 区域ID ]不能为空");
                return;
            }

            #endregion

            #region 获取数据

            WG_GiftsEntity _WG_GiftsEntity = new WG_GiftsEntity();



            _WG_GiftsEntity.Title = Convert.ToString(_Title.ToString());


            _WG_GiftsEntity.PhotoUrl = Convert.ToString(_PhotoUrl.ToString());

            _WG_GiftsEntity.NeedScores = Convert.ToInt32(_NeedScores.ToString());

            _WG_GiftsEntity.Count = Convert.ToInt32(_Count.ToString());


            _WG_GiftsEntity.Detail = Convert.ToString(_Detail.ToString());

            _WG_GiftsEntity.RegionID = Convert.ToInt32(_RegionID.ToString());

            _WG_GiftsEntity.CreateDate = DateTime.Now;

            _WG_GiftsEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().AddWG_Gifts(_WG_GiftsEntity);
            }
            catch
            {
                WriteLog("WG_GiftsAdd", "添加WG_Gifts", "插入数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("添加数据时出错，请重试");
                return;
            }
            Alert("添加WG_Gifts成功");
        }
            #endregion
        #endregion

        #region 编辑
        protected void WG_GiftsEditFunc(string ctrID)
        {
            #region 判断是否可空


            var _Title = Request.Form["TextBox_Title"];
            if (string.IsNullOrEmpty(_Title))
            {
                Alert("[ 礼物名称 ]不能为空");
                return;
            }

            var _PhotoUrl = Request.Form["TextBox_PhotoUrl"];
            if (string.IsNullOrEmpty(_PhotoUrl))
            {
                Alert("[ 图片地址 ]不能为空");
                return;
            }

            var _NeedScores = Request.Form["TextBox_NeedScores"];
            if (string.IsNullOrEmpty(_NeedScores))
            {
                Alert("[ 所需积分 ]不能为空");
                return;
            }

            var _Count = Request.Form["TextBox_Count"];
            if (string.IsNullOrEmpty(_Count))
            {
                Alert("[ 礼物数量 ]不能为空");
                return;
            }

            var _Detail = Request.Form["TextBox_Detail"];
            if (string.IsNullOrEmpty(_Detail))
            {
                Alert("[ 详细说明 ]不能为空");
                return;
            }

            var _RegionID = Request.Form["TextBox_RegionID"];
            if (string.IsNullOrEmpty(_RegionID))
            {
                Alert("[ 区域ID ]不能为空");
                return;
            }

            #endregion

            _WG_GiftsEntity.Title = Convert.ToString(_Title.ToString());



            _WG_GiftsEntity.PhotoUrl = Convert.ToString(_PhotoUrl.ToString());


            _WG_GiftsEntity.NeedScores = Convert.ToInt32(_NeedScores.ToString());


            _WG_GiftsEntity.Count = Convert.ToInt32(_Count.ToString());



            _WG_GiftsEntity.Detail = Convert.ToString(_Detail.ToString());


            _WG_GiftsEntity.RegionID = Convert.ToInt32(_RegionID.ToString());

            _WG_GiftsEntity.UpdateDate = DateTime.Now;
            try
            {
                DataProvider.GetInstance().UpdateWG_Gifts(_WG_GiftsEntity);
            }
            catch
            {
                WriteLog("WG_GiftsEditFunc", "编辑WG_Gifts", "更新到数据库时出错", Common.DailyUtility.MideSmsType.LogType.SystemLog);
                Alert("更新数据时出错，请重试");
                return;
            }
            Alert("更新WG_Gifts资料成功", "");
        }
        #endregion
    }
}