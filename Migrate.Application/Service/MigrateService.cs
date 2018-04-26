using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrate.Application.Model;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Model;

namespace Migrate.Application
{
    /// <summary>
    /// 迁移服务
    /// </summary>
    public abstract class MigrateService
    {
        /// <summary>
        /// 迁移的配置信息
        /// </summary>
        protected MigrateProfile Profile { get; set; }

        /// <summary>
        /// 迁移记录
        /// </summary>
        protected Dictionary<string, TableMigrateLog> MigrateLog { get; private set; }

        /// <summary>
        /// 更新进度
        /// </summary>
        public Action<float> UpdateProcessAction { get; set; }

        /// <summary>
        /// 更新消息
        /// </summary>
        public Action<string> UpdateMessageAction { get; set; }

        /// <summary>
        /// 数据迁移完成
        /// </summary>
        public event MigrateFinishedHandler MigrateFinished;

        /// <summary>
        /// 任务总数
        /// </summary>
        protected int taskSumCount = 0;

        /// <summary>
        /// 完成的任务数量
        /// </summary>
        private int finishedTaskCount = 0;

        /// <summary>
        /// 执行数据迁移
        /// </summary>
        public void Start()
        {
            BeforeExecute();
            ExecTableSchema();
            ExecStorage();
            ExecConstraints();
            AfterExecute();
            MigrateFinished?.Invoke(MigrateLog);
        }

        protected virtual void BeforeExecute()
        {
            InitMigrateLog();
            ComputeTaskSumCount();
        }


        protected virtual void AfterExecute() { }

        protected void InitMigrateLog()
        {
            MigrateLog = new Dictionary<string, TableMigrateLog>();
            foreach (var table in Profile.ImpTables)
            {
                TableMigrateLog log = new TableMigrateLog();
                if (!table.IncludeStorage) log.Storage = MigrateState.Ignore;
                if (!table.IncludeConstraint) log.Constraint = MigrateState.Ignore;

                MigrateLog.Add(table.TableName, log);
            }
        }

        protected void ComputeTaskSumCount()
        {
            taskSumCount += Profile.ImpTables.Count;
            taskSumCount += Profile.ImpTables.Where(item => item.IncludeStorage).Count();

            IEnumerable<string> tableIncludeConstraint = Profile.ImpTables.Where(item => item.IncludeConstraint).Select(item => item.TableName);
            IEnumerable<Constraint> consts = Domain.Helper.Constraints.GetOwnerConstraints(Profile.SourceConnString)
                .Where(item => tableIncludeConstraint.Contains(item.TableName));
            taskSumCount += consts.Count();
        }

        /// <summary>
        /// 建立数据库的表结构
        /// </summary>
        public abstract void ExecTableSchema();

        /// <summary>
        /// 传输存储数据
        /// </summary>
        public abstract void ExecStorage();

        /// <summary>
        /// 建立约束
        /// </summary>
        public abstract void ExecConstraints();

        /// <summary>
        /// 更新消息
        /// </summary>
        /// <param name="msg"></param>
        protected void UpdateMessage(string msg)
        {
            UpdateMessageAction?.Invoke(msg);
        }

        /// <summary>
        /// 递增完成的任务数量
        /// </summary>
        protected void IncreaseFinishedTask()
        {
            finishedTaskCount++;
            UpdateProcessAction?.Invoke((float)finishedTaskCount / (float)taskSumCount);
        }
    }

    public delegate void MigrateFinishedHandler(Dictionary<string, TableMigrateLog> migrateLog);
}
