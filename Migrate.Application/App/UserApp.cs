using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Helper;
using Migrate.Domain.Model;

namespace Migrate.Application.App
{
    /// <summary>
    /// 用户授权应用类
    /// </summary>
    public class UserApp
    {
        public void Create(ConnectString connString,User user)
        {
            Users.CreateUser(connString, user);
        }

        public void Drop(ConnectString connString,string userName)
        {
            Users.DropUser(connString, userName);
        }

        public void Grant(ConnectString connString, string userName,string[] roles)
        {
            try
            {
                Users.Grant(connString, userName, roles);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<User> GetAllUser(ConnectString connstring)
        {
            try
            {
                return Users.GetAllUser(connstring);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
