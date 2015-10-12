using System; 

namespace MideFrameWork.Data.Entity
{	
	/// <summary>
	/// WebSiteManagement:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WebSiteManagementEntity
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
        
		private string _websitename;
		/// <summary>
		/// WebSiteName
        /// </summary>
        public string WebSiteName
        {
            get{ return _websitename; }
            set{ _websitename = value; }
        }
        
		private string _metakeywords;
		/// <summary>
		/// MetaKeywords
        /// </summary>
        public string MetaKeywords
        {
            get{ return _metakeywords; }
            set{ _metakeywords = value; }
        }
        
		private string _metadescriptions;
		/// <summary>
		/// MetaDescriptions
        /// </summary>
        public string MetaDescriptions
        {
            get{ return _metadescriptions; }
            set{ _metadescriptions = value; }
        }
        
		private string _advpopupscript;
		/// <summary>
		/// AdvPopupScript
        /// </summary>
        public string AdvPopupScript
        {
            get{ return _advpopupscript; }
            set{ _advpopupscript = value; }
        }
        
		private int _ownerid;
		/// <summary>
		/// OwnerID
        /// </summary>
        public int OwnerID
        {
            get{ return _ownerid; }
            set{ _ownerid = value; }
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
        
		private DateTime _updatedate;
		/// <summary>
		/// UpdateDate
        /// </summary>
        public DateTime UpdateDate
        {
            get{ return _updatedate; }
            set{ _updatedate = value; }
        }
        
		   
	}
}