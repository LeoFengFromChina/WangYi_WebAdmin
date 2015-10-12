using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MideFrameWork.Common.DailyUtility
{
    public static class MideSmsType
    {
        public enum LogType
        {
            SystemLog = 1,
            UserLog = 2,
        };

    }
    public class Status
    {
        public Status(int id, string text)
        {
            _id = id;
            _text = text;
        }
        private int _id;
        public int ID
        {
            get
            { return _id; }
            set
            { _id = value; }
        }
        private string _text;
        public string Text
        {
            get
            { return _text; }
            set
            { _text = value; }
        }
    }
}
