using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// PrivilegeView:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PrivilegeViewEntity
	{
      	private int _userid;
		/// <summary>
		/// UserID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }
        
		private string _modulename;
		/// <summary>
		/// ModuleName
        /// </summary>
        public string ModuleName
        {
            get{ return _modulename; }
            set{ _modulename = value; }
        }
        
		private string _buttonname;
		/// <summary>
		/// ButtonName
        /// </summary>
        public string ButtonName
        {
            get{ return _buttonname; }
            set{ _buttonname = value; }
        }
        
		   
	}
}