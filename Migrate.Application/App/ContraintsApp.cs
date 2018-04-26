using Migrate.Domain.Helper;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migrate.Application.App
{
    /// <summary>
    /// 约束应用类
    /// </summary>
    public class ContraintsApp
    {
        /// <summary>
        /// 启用(Constraint cons)
        /// </summary>
        /// <param name="connString"></param>
        public void Enable(ConnectString connString, string table, string constraint)
        {
            Constraints.EnableConstraint(connString, table, constraint);
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="connString"></param>
        public void EnaEnable(ConnectString connString, string table, string constraint)
        {
            Constraints.DisableConstraint(connString, table, constraint);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="connString"></param>
        public void Drop(ConnectString connString, string table, string constraint)
        {
            Constraints.DropConstraint(connString, table, constraint);
        }

        /// <summary>
        /// 获取当前表空间下的所有约束信息
        /// </summary>
        /// <param name="connString"></param>
        /// <returns></returns>
        public IEnumerable<Constraint> GetOwnerConstraints(ConnectString connString)
        {
            return Constraints.GetOwnerConstraints(connString);
        }
    }
}
