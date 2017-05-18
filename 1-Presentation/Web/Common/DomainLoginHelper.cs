using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace Web.Common
{
    public class DomainLoginHelper
    {
        /// <summary>
        /// AD 认证账号和密码
        /// </summary>
        /// <param name="username">AD账号</param>
        /// <param name="pwd">AD密码</param>
        /// <returns></returns>
        public static bool IsAuthenticated(string username, string pwd)
        {

            string uid = username.ToLower().Trim();

            if (string.IsNullOrEmpty(uid))
            {
                return false;
            }

            string domainName = "163.COM";

            string domainAndUsername = domainName + @"\" + username;

            DirectoryEntry entry = new DirectoryEntry("LDAP://10.6.2.6/CN=Users;DC=163,DC=com", domainAndUsername, pwd);

            try
            {
                DirectorySearcher search = new DirectorySearcher(entry);

                SearchResult result = search.FindOne();

                if (null == result)

                    return false;

                else
                    return true;

            }
            catch
            {

                return false;
            }
        }


    }
}
