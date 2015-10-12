using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_Score:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_ScoreEntity
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
        
		private int _menberid;
		/// <summary>
		/// 会员ID
        /// </summary>
        public int MenberID
        {
            get{ return _menberid; }
            set{ _menberid = value; }
        }
        
		private int _scores;
		/// <summary>
		/// 积分数
        /// </summary>
        public int Scores
        {
            get{ return _scores; }
            set{ _scores = value; }
        }
        
		private string _title;
		/// <summary>
		/// 积分说明
        /// </summary>
        public string Title
        {
            get{ return _title; }
            set{ _title = value; }
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