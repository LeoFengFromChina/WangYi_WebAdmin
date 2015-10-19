using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MideFrameWork_AppDataInterface
{
    /// <summary>
    /// PostFile 的摘要说明
    /// </summary>
    public class PostFile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            Stream Inputstream = request.InputStream;
            string savaPath = request.Headers["Path"];
            string fileName = request.Headers["FileName"];

            string FileStreamStr = string.Empty;
            if (Inputstream.Length != 0)
            {
                StreamReader streamReader = new StreamReader(Inputstream);
                FileStreamStr = streamReader.ReadToEnd();
            }
            if (WriteFile(savaPath, fileName, FileStreamStr))
                context.Response.Write("fengOk");
            else
            {
                context.Response.Write("fengError");
            }
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="content">The content.</param>
        /// <Author> frd  2011-11-714:16</Author>
        private bool WriteFile(string path, string fileName, string content)
        {
            bool result = false;
            if (Directory.Exists(path))
                path = path + fileName;
            else
            {
                Directory.CreateDirectory(path);
                path = path + fileName;
            }
            FileStream fs = null; ;
            StreamWriter sr = null;
            try
            {
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                sr = new StreamWriter(fs);
                sr.Write(content);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                sr.Close();
                fs.Close();
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
}