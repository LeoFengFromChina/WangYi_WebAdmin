using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MideFrameWork.Data.Entity;
using MideFrameWork.Data.Interface;
using System.Web;
using System.Configuration;
using System.Collections;
namespace MideFrameWork.Authorization
{
    public class Authorization
    {
        public Authorization() { }
        //缓存30分钟
        static int cacheTime = Int32.Parse(ConfigurationManager.AppSettings["CacheTime"].Trim());

        private string CacheUser
        {
            get;
            set;
        }
        private string CacheMenu
        {
            get;
            set;
        }
        /// <summary>
        /// 验证并缓存用户权限
        /// </summary>
        /// <param name="currentUsers"></param>
        public int Validate(UsersEntity currentUsers)
        {
            string cacheKey = currentUsers.ChildAccount + "@" + currentUsers.ParentAccount;
            CacheUser = "User_" + currentUsers.ChildAccount + "@" + currentUsers.ParentAccount;
            CacheMenu = "Menu_" + currentUsers.ChildAccount + "@" + currentUsers.ParentAccount;
            //换成用户
            if (HttpRuntime.Cache[CacheUser] == null)
                HttpRuntime.Cache.Insert(CacheUser, currentUsers, null, DateTime.MaxValue, TimeSpan.FromMinutes(cacheTime));
            else
            {
                HttpRuntime.Cache[CacheUser] = currentUsers;
            }
            //缓存权限菜单
            string menuWhere = "GroupID >=" + currentUsers.GroupID + " AND Status=" + 0 + " order by DisplayIndex ASC";
            IList<MenuEntity> menuList = DataProvider.GetInstance().GetMenuList(menuWhere);
            if (HttpRuntime.Cache[CacheMenu] == null)
                HttpRuntime.Cache.Insert(CacheMenu, menuList, null, DateTime.MaxValue, TimeSpan.FromMinutes(cacheTime));
            else
            {
                HttpRuntime.Cache[CacheMenu] = menuList;
            }
            return cacheTime;
        }
        /// <summary>
        /// 获取权限菜单
        /// </summary>
        /// <returns></returns>
        public IList<MenuEntity> GetAuthorizeMenus()
        {
            if (HttpRuntime.Cache[CacheMenu] == null)
                return null;
            return HttpRuntime.Cache[CacheMenu] as IList<MenuEntity>;
        }
        /// <summary>
        /// 获取权限用户
        /// </summary>
        /// <returns></returns>
        public UsersEntity GetAuthorizeUsers()
        {
            if (HttpRuntime.Cache[CacheUser] == null)
                return null;
            return HttpRuntime.Cache[CacheUser] as UsersEntity;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        public void Logout()
        {
            if (HttpRuntime.Cache[CacheUser] != null)
                HttpRuntime.Cache.Remove(CacheUser);

            if (HttpRuntime.Cache[CacheMenu] != null)
                HttpRuntime.Cache.Remove(CacheMenu);
        }

        public List<UsersEntity> OnlineUserList()
        {
            List<UsersEntity> onlineLis = new List<UsersEntity>();
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();

            while (CacheEnum.MoveNext())
            {
                if (CacheEnum.Key.ToString().StartsWith("User_"))
                {
                    onlineLis.Add(HttpRuntime.Cache[CacheEnum.Key.ToString()] as UsersEntity);
                }
            }
            return onlineLis;
        }

    }
}
