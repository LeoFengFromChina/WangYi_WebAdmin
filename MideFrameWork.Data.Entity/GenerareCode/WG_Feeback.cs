using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_Feeback:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_FeebackEntity
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
        
		private int _promoterid;
		/// <summary>
		/// 反馈人ID
        /// </summary>
        public int PromoterID
        {
            get{ return _promoterid; }
            set{ _promoterid = value; }
        }
        
		private string _detail;
		/// <summary>
		/// 反馈明显
        /// </summary>
        public string Detail
        {
            get{ return _detail; }
            set{ _detail = value; }
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
		/// 创建日期
        /// </summary>
        public DateTime CreateDate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }
        
		   
	}
}