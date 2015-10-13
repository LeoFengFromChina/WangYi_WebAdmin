using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_OnGoingGifts:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_OnGoingGiftsEntity
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
        
		private string _code;
		/// <summary>
		/// 兑换码
        /// </summary>
        public string Code
        {
            get{ return _code; }
            set{ _code = value; }
        }
        
		private int _menberid;
		/// <summary>
		/// 会员ID
        /// </summary>
        public int MenberID
        {
            get{ return _menberid; }
            set{ _menberid = value; }
        }
        
		private int _giftid;
		/// <summary>
		/// 礼物ID
        /// </summary>
        public int GiftID
        {
            get{ return _giftid; }
            set{ _giftid = value; }
        }
        
		private int _status;
		/// <summary>
		/// 状态
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
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