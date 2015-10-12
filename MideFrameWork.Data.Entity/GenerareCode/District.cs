using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// District:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DistrictEntity
	{
      	private int _id;
		/// <summary>
		/// ID(0为全国)
        /// </summary>
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }
        
		private int _parentid;
		/// <summary>
		/// 父ID
        /// </summary>
        public int ParentID
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }
        
		private string _districtname;
		/// <summary>
		/// 区域名
        /// </summary>
        public string DistrictName
        {
            get{ return _districtname; }
            set{ _districtname = value; }
        }
        
		private int _status;
		/// <summary>
		/// 状态(0为开启，1为停用)
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }
        
		   
	}
}