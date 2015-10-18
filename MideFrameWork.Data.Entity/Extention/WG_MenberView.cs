using System;
using System.Collections.Generic;

namespace MideFrameWork.Data.Entity
{
    /// <summary>
    /// WG_Menber:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WG_MenberEntityView
    {
        public WG_MenberEntity Menber { get; set; }
        public IList<Base_PrivilegeEntity> Privilege { get; set; }
    }
}