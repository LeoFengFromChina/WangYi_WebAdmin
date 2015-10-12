using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;

namespace MideFrameWork.Common.DBUtility
{
    public static class DBLog
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <param name="operate">函数名称</param>
        /// <param name="logcontent">日志正文</param>
        /// <param name="logtype">日志类型(1为系统日志，2用户日志)</param>
        public static void WriteLog(string module, string operate, string logcontent, int userID, int logType)
        {
            LogEntity log = new LogEntity();
            log.ModuleName = module;
            log.Operation = operate;
            log.LogContent = logcontent;
            log.FromUserID = userID;
            log.LogType = logType;//操作日志
            log.CreateDate = DateTime.Now;

            try
            {
                DataProvider.GetInstance().AddLog(log);
            }
            catch
            {
            }
        }
    }
}
