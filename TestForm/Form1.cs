using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jpath = @"\newRegion.json";
            List<Region> pls = GetJsonToObject<List<Region>>(jpath);
            if (pls != null && pls.Count > 0)
            {
                foreach (Region region in pls)
                {
                    WG_RegionEntity re = new WG_RegionEntity();
                    re.Name = region.name;
                    re.ParentID = 0;
                    re.CreateDate = DateTime.Now;
                    re.UpdateDate = DateTime.Now;
                    re.Meno = "全国";

                    int id = DataProvider.GetInstance().AddWG_Region(re);

                    if (region.city != null && region.city.Count > 0)
                    {
                        AddChild(id, region);
                    }
                }

                MessageBox.Show("OK");
            }

        }

        private int AddChild(int parentID, Region re)
        {
            foreach (Region region in re.city)
            {
                WG_RegionEntity reobject = new WG_RegionEntity();
                reobject.Name = region.name;
                reobject.ParentID = parentID;
                reobject.CreateDate = DateTime.Now;
                reobject.UpdateDate = DateTime.Now;
                reobject.Meno = region.name;

                int id = DataProvider.GetInstance().AddWG_Region(reobject);
                System.Threading.Thread.Sleep(50);
                if (region.city != null && region.city.Count > 0)
                {
                    AddChild(id, region);
                }
            }
            return 0;
        }


        public T GetJsonToObject<T>(string filePath)
        {
            string jpath = @filePath;
            string s = ReadText(jpath);
            T pls = JsonDeserialize<T>(s);
            return pls;
        }

        public string ReadText(string path)
        {
            string result = string.Empty;
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + path, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                result += line.ToString();
            }
            sr.Close();
            return result;
        }

        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }

    public class Region
    {
        public string name { get; set; }

        public List<Region> city { get; set; }

    }
}