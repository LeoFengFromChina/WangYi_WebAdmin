using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MideFrameWork.Data.Entity;
using MideFrameWork.Authorization;
using System.Configuration;
using System.IO;
namespace MideFrameWork.UI.WebSite
{
    public partial class Left : BaseForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }
        private void LoadMenu()
        {

            Authorization.Authorization author = CurrentAuthor;
            IList<MenuEntity> menuList = author.GetAuthorizeMenus();
            UsersEntity currUser = author.GetAuthorizeUsers();
            LoadLogo();
            if (currUser != null && menuList != null && menuList.Count > 0)
            {
                lbl_UserName.Text = currUser.ChildAccount + "@" + currUser.ParentAccount;
                lbl_Balance.Text = currUser.Balance.ToString();
                myMenu.Clear();
                foreach (MenuEntity menuFirst in menuList)
                {
                    if (menuFirst.ParentID == 0)
                    {
                        ucMenuBar mb = new ucMenuBar(menuFirst.ID, menuFirst.ImageUrl, menuFirst.DisplayName, menuFirst.LinkUrl, "mainframe");
                        foreach (MenuEntity menuSec in menuList)
                        {
                            if (menuSec.ParentID == mb.ID)
                            {
                                ucMenuItem mi = new ucMenuItem(menuSec.ImageUrl, menuSec.DisplayName, menuSec.LinkUrl, "mainframe");
                                mb.Add(mi);
                            }
                        }
                        myMenu.Add(mb);
                    }
                }

                ucMenuBar mb3 = new ucMenuBar(99, "images/search.png", "飞扬短信营销平台 V1.0", "../WelcomePage.aspx", "mainframe");
                myMenu.Add(mb3);
                myMenu.MenuBarList[0].Expand = true;
            }
        }

        private void LoadLogo()
        {

            //logo
            string logosrcStr = Server.MapPath("~/eLogo/") + CurrentUser.ParentAccount + "_" + CurrentUser.ChildAccount;
            string fullname = string.Empty;
            if (File.Exists(GetLogoFullName(logosrcStr, "jpg"))
                || File.Exists(GetLogoFullName(logosrcStr, "png"))
                || File.Exists(GetLogoFullName(logosrcStr, "jpeg"))
                || File.Exists(GetLogoFullName(logosrcStr, "bmp"))
                || File.Exists(GetLogoFullName(logosrcStr, "gif")))
            {
                eLogo.ImageUrl = FullLogoPath;
            }

        }
        protected void lbUploadPhoto_Click(object sender, EventArgs e)
        {
            string fliter = ful_logo.PostedFile.FileName.Substring(ful_logo.PostedFile.FileName.LastIndexOf('.'), ful_logo.PostedFile.FileName.Length - ful_logo.PostedFile.FileName.LastIndexOf('.'));
            if (!fliter.Equals(".jpg", StringComparison.OrdinalIgnoreCase)
            && !fliter.Equals(".jpeg", StringComparison.OrdinalIgnoreCase)
              && !fliter.Equals(".gif", StringComparison.OrdinalIgnoreCase)
                && !fliter.Equals(".png", StringComparison.OrdinalIgnoreCase)
                && !fliter.Equals(".bmp", StringComparison.OrdinalIgnoreCase))
            {
                Alert("请选择如jpg,gif,png等格式的图片");
                return;
            }
            //判断文件大小不能超过1M
            else if (ful_logo.PostedFile.ContentLength > 1024 * 1024)
            {
                Alert("图片大小不能超过1M大小！");
                return;
            }
            string filefullname = ful_logo.PostedFile.FileName;
            string LogoPath = Server.MapPath("~/eLogo/") + CurrentUser.ParentAccount + "_" + CurrentUser.ChildAccount + filefullname.Substring(filefullname.LastIndexOf('.'), filefullname.Length - filefullname.LastIndexOf('.'));

            //清除本企业当前的Logo
            string[] files = Directory.GetFiles(Server.MapPath("~/eLogo/"));
            foreach (string fileStr in files)
            {
                if (fileStr.Contains("\\" + CurrentUser.ParentAccount + "_" + CurrentUser.ChildAccount + "."))
                    File.Delete(fileStr);
            }

            //开始上传Logo
            ful_logo.SaveAs(LogoPath);

            //裁剪Logo
            MakeThumbnail(LogoPath, LogoPath, 200, 160, "Cut");

            LoadLogo();
        }
        private string FullLogoPath
        {
            get
            {
                if (ViewState["FullLogoPath"] != null)
                    return ViewState["FullLogoPath"].ToString();
                else
                {
                    return "/images/head.gif";
                }
            }
            set { ViewState["FullLogoPath"] = value; }
        }
        private string GetLogoFullName(string name, string fliter)
        {
            FullLogoPath = "/eLogo/" + CurrentUser.ParentAccount + "_" + CurrentUser.ChildAccount + "." + fliter;
            return name + "." + fliter;
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image bitmap;
            using (System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath))
            {
                int towidth = width;
                int toheight = height;

                int x = 0;
                int y = 0;
                int ow = originalImage.Width;
                int oh = originalImage.Height;

                switch (mode)
                {
                    case "HW"://指定高宽缩放（可能变形）                
                        break;
                    case "W"://指定宽，高按比例      
                        {
                            if (originalImage.Width > width)
                                toheight = originalImage.Height * width / originalImage.Width;
                        }
                        break;
                    case "H"://指定高，宽按比例
                        {
                            if (originalImage.Height > height)
                                towidth = originalImage.Width * height / originalImage.Height;
                        }
                        break;
                    case "Cut"://指定高宽裁减（不变形）                
                        if (originalImage.Height > height || originalImage.Width > width)
                        {
                            if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                            {
                                oh = originalImage.Height;
                                ow = originalImage.Height * towidth / toheight;
                                y = 0;
                                x = (originalImage.Width - ow) / 2;
                            }
                            else
                            {
                                ow = originalImage.Width;
                                oh = originalImage.Width * height / towidth;
                                x = 0;
                                y = (originalImage.Height - oh) / 2;
                            }
                        }
                        break;
                    default:
                        break;
                }

                //新建一个bmp图片
                bitmap = new System.Drawing.Bitmap(towidth, toheight);

                //新建一个画板
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

                //设置高质量插值法
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                //设置高质量,低速度呈现平滑程度
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //清空画布并以透明背景色填充
                g.Clear(System.Drawing.Color.Transparent);

                //在指定位置并且按指定大小绘制原图片的指定部分
                g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                    new System.Drawing.Rectangle(x, y, ow, oh),
                    System.Drawing.GraphicsUnit.Pixel);
            }
            try
            {
                //以jpg格式保存缩略图
                if (File.Exists(thumbnailPath))
                    File.Delete(thumbnailPath);
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                bitmap.Dispose();
            }
        }
    }
}