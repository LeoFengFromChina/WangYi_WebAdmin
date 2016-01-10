using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_Vender:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_VenderEntity
	{
      	private int _id;
		/// <summary>
		/// ID
        /// </summary>
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }
        
		private string _vendername;
		/// <summary>
		/// 商家名称
        /// </summary>
        public string VenderName
        {
            get{ return _vendername; }
            set{ _vendername = value; }
        }
        
		private int _vendertype;
		/// <summary>
		/// 商家类别
        /// </summary>
        public int VenderType
        {
            get{ return _vendertype; }
            set{ _vendertype = value; }
        }
        
		private string _logo;
		/// <summary>
		/// 图片
        /// </summary>
        public string Logo
        {
            get{ return _logo; }
            set{ _logo = value; }
        }
        
		private string _address;
		/// <summary>
		/// 地址
        /// </summary>
        public string Address
        {
            get{ return _address; }
            set{ _address = value; }
        }
        
		private string _comlevel;
		/// <summary>
		/// 合作等级
        /// </summary>
        public string ComLevel
        {
            get{ return _comlevel; }
            set{ _comlevel = value; }
        }
        
		private string _phone;
		/// <summary>
		/// 联系电话
        /// </summary>
        public string Phone
        {
            get{ return _phone; }
            set{ _phone = value; }
        }
        
		private string _memo;
		/// <summary>
		/// 备注
        /// </summary>
        public string Memo
        {
            get{ return _memo; }
            set{ _memo = value; }
        }
        
		private DateTime _createdate;
		/// <summary>
		/// CreateDate
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }
        
		   
	}
}