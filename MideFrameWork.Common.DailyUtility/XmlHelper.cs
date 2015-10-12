using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace MideSms.Common.DailyUtility
{
    public class XmlHelper
    {

        string XmlText = string.Empty;
        XmlDocument xmlDoc = new XmlDocument();
        public XmlHelper(string xmlText)
        {
            xmlDoc.LoadXml(xmlText);
        }
        public void LoadXml(string xmlText)
        {
            xmlDoc.LoadXml(xmlText);
        }


    }
}
