using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_Gifts:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_GiftsEntity
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
        
		private string _title;
		/// <summary>
		/// 礼物名称
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
        }
        
		private string _photourl;
		/// <summary>
		/// 图片地址
        /// </summary>
        public string PhotoUrl
        {
            get{ return _photourl; }
            set{ _photourl = value; }
        }
        
		private int _needscores;
		/// <summary>
		/// 所需积分
        /// </summary>
        public int NeedScores
        {
            get{ return _needscores; }
            set{ _needscores = value; }
        }
        
		private int _count;
		/// <summary>
		/// 礼物数量
        /// </summary>
        public int Count
        {
            get{ return _count; }
            set{ _count = value; }
        }
        
		private string _detail;
		/// <summary>
		/// 详细说明
        /// </summary>
        public string Detail
        {
            get{ return _detail; }
            set{ _detail = value; }
        }
        
		private int _regionid;
		/// <summary>
		/// 区域ID
        /// </summary>
        public int RegionID
        {
            get{ return _regionid; }
            set{ _regionid = value; }
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
        
		private DateTime _updatedate;
		/// <summary>
		/// 更新日期
        /// </summary>
        public DateTime UpdateDate
        {
            get{ return _updatedate; }
            set{ _updatedate = value; }
        }
        
		   
	}
}