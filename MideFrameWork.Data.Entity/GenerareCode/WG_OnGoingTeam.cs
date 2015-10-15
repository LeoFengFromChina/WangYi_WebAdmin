using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WG_OnGoingTeam:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WG_OnGoingTeamEntity
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
        
		private int _teamid;
		/// <summary>
		/// 团队ID
        /// </summary>
        public int TeamID
        {
            get{ return _teamid; }
            set{ _teamid = value; }
        }
        
		private int _menberid;
		/// <summary>
		/// 用户ID
        /// </summary>
        public int MenberID
        {
            get{ return _menberid; }
            set{ _menberid = value; }
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