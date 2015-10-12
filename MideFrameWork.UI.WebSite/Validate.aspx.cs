using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

public partial class validate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.BufferOutput = true;    //特别注意消空缓存
        Response.Cache.SetExpires(DateTime.Now.AddMilliseconds(-1));//特别注意
        Response.Cache.SetCacheability(HttpCacheability.NoCache); //特别注意
        Response.AppendHeader("   Pragma", "No-Cache");
        string strNum = Rndnum();
        Session["Num0"] = strNum;
        ValidateCode(Session["Num0"].ToString());
    }

    public string Rndnum()
    {
        int j1;
        string strChoice = "1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p,q,r,s,t,u,v,w,x,y,z";
        string[] strResult = strChoice.Split(new Char[] { ',' });
        string strReturn = "";
        Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
        for (int i = 0; i < 4; i++)
        {
            Random rnd1 = new Random(rnd.Next() * unchecked((int)DateTime.Now.Ticks));
            j1 = rnd1.Next(33);
            rnd = new Random(rnd.Next() * unchecked((int)DateTime.Now.Ticks));
            strReturn = strReturn + strResult[j1].ToString();
        }
        return strReturn.ToUpper();
    }

    public void ValidateCode(string vnum)
    {
        MemoryStream ms = new MemoryStream();
        //double Height = (vnum.Length) * 12;
        int gHeight = 60;
        Bitmap img = new Bitmap(gHeight, 32);
        Graphics g = Graphics.FromImage(img);
        Pen pen = new Pen(Color.FromArgb(128,128,128));
        pen.DashStyle = DashStyle.Dash;
        g.DrawRectangle(pen, 0, 0, gHeight-1, 31);
        g.FillRectangle(Brushes.White,new Rectangle(1,1,gHeight-2,18));
        g.DrawString(vnum, new Font("幼圆", 16), new SolidBrush(Color.FromArgb(44,88,148)), 5,7);
        img.Save(ms, ImageFormat.Png);
        Response.ClearContent();
        Response.ContentType = "image/Bmp";
        Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        img.Dispose();
        Response.End();
    }
}