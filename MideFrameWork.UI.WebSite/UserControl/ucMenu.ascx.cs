using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MideFrameWork.UI.WebSite
{
    public partial class ucMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        List<ucMenuBar> _barList = new List<ucMenuBar>();
        public List<ucMenuBar> MenuBarList
        {
            get { return _barList; }
            set { _barList = value; }
        }
        public void Add(ucMenuBar mbar)
        {
            if (MenuBarList == null)
                MenuBarList = new List<ucMenuBar>();
            MenuBarList.Add(mbar);
        }
        public void Clear()
        {
            if (MenuBarList != null)
                MenuBarList.Clear();
        }
        protected string InitalMenu()
        {
            string menuHtml = @"<ul id='expmenu-freebie'>"
                                                     + "<li>"
                                                            + "<ul class='expmenu'>";
            string expandStyle = "arrow up";
            if (MenuBarList != null && MenuBarList.Count > 0)
            {
                foreach (ucMenuBar mb in MenuBarList)
                {
                    expandStyle = !mb.Expand ? "arrow down" : "arrow up";
                    if (mb.MenuItems != null && mb.MenuItems.Count > 0)
                    {
                        menuHtml += "<li>"
                                            + "<div class='header'>"
                                                + "<a class='label' style='background-image: url(" + mb.ImageUrl + ");'  href='javascript:void(0)'>" + mb.Text + "</a>"
                                                + "<span class='" + expandStyle + "'></span>"
                                            + "</div>";
                        if (mb.Expand)
                            menuHtml += "<ul class='menu' >";
                        else
                        {
                            menuHtml += "<ul class='menu'  style='overflow: hidden;display: none'>";
                        }
                        foreach (ucMenuItem mi in mb.MenuItems)
                        {
                            menuHtml += "<li><a href='" + mi.Url + "' target='" + mi.TargetFrame + "'  class='targetNode'>" + mi.Text + "</a></li>";
                        }
                        menuHtml += "</ul>";
                    }
                    else
                    {
                        //如果没有子节点，上下箭头就不显示
                        menuHtml += "<li>"
                                            + "<div class='header'>"
                                                + "<a class='label targetNode' style='background-image: url(" + mb.ImageUrl + ");'  href='" + mb.LinkUrl + "' target='" + mb.TargetFrame + "'>" + mb.Text + "</a>"
                                           + "</div>";
                    }
                    menuHtml += "</li>";
                }
            }
            menuHtml += "</ul>"
                                + "</li>"
                            + "</ul>";
            return menuHtml;
        }
    }
    /// <summary>
    /// 菜单中的一栏
    /// </summary>
    public class ucMenuBar
    {
        private int _id;
        private string _imgUrl;
        private string _text;
        private bool _expand = false;
        private string _linkurl;
        private string _targetFrame;
        public ucMenuBar()
        { }

        public string TargetFrame
        {
            get { return _targetFrame; }
            set { _targetFrame = value; }
        }
        public ucMenuBar(int id, string imgurl, string text, string linkurl, string target)
        {
            _id = id;
            _imgUrl = imgurl;
            _text = text;
            _linkurl = linkurl;
            _targetFrame = target;
        }
        public string ImageUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public bool Expand
        {
            get { return _expand; }
            set { _expand = value; }
        }
        public string LinkUrl
        {
            get { return _linkurl; }
            set { _linkurl = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private List<ucMenuItem> _menuItemList;
        public List<ucMenuItem> MenuItems
        {
            get { return _menuItemList; }
            set { _menuItemList = value; }
        }
        public void Add(ucMenuItem menuItem)
        {
            if (MenuItems == null)
                MenuItems = new List<ucMenuItem>();
            MenuItems.Add(menuItem);
        }
    }

    /// <summary>
    /// 菜单项
    /// </summary>
    public class ucMenuItem
    {
        string _imgUrl;
        string _text;
        string _url;
        string _targetFrame;
        public ucMenuItem()
        { }
        public ucMenuItem(string imgurl, string text, string url, string targetframe)
        {
            _imgUrl = imgurl;
            _text = text;
            _url = url;
            _targetFrame = targetframe;
        }
        public string ImageUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public string TargetFrame
        {
            get { return _targetFrame; }
            set { _targetFrame = value; }
        }

    }


}