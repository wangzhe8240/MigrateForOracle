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
    public class D2DService : MigrateService
    {
        public D2DService(MigrateProfile profile)
        {
            Profile = profile;
        }

        /// <summary>
        /// 建立数据库的表结构
        /// </summary>
        public override void ExecTableSchema()
        {
            foreach (var tableProfile in Profile.ImpTables)
            {
                try
                {
                    Table tableDetail = Domain.Helper.Tables.GetTableDetails(Profile.SourceConnString, tableProfile.TableName);

                    if (!string.IsNullOrEmpty(Profile.DestTablespace))
                    {
                        tableDetail.TablespaceName = Profile.DestTablespace;
                    }

                    Domain.Helper.Tables.CreateTable(Profile.DestConnString, tableDetail);
                    MigrateLog[tableProfile.TableName].TableStruct = MigrateState.Finished;

                    UpdateMessage($"{tableProfile.TableName}表结构创建完成");
                }
                catch (Exception ex)
                {
                    UpdateMessage($"{tableProfile.TableName}表结构创建失败:\n{ex.Message}");
                }
                finally
                {
                    IncreaseFinishedTask();
                }
            }
        }

        /// <summary>
        /// 传输存储数据
        /// </summary>
        public override void ExecStorage()
        {
            IEnumerable<TableProfile> tableIncludeStorage = Profile.ImpTables.Where(item => item.IncludeStorage);
            foreach (var tableProfile in tableIncludeStorage)
            {
                try
                {
                    if (MigrateLog[tableProfile.TableName].TableStruct != MigrateState.Finished)
                    {
                        UpdateMessage($"{tableProfile.TableName}的表结构创建失败，数据传输取消");
                    }
                    else
                    {
                        Table tableDetail = Domain.Helper.Tables.GetTableDetails(Profile.SourceConnString, tableProfile.TableName);
                        MDataSet dataSet = new MDataSet(tableDetail.Name, tableDetail.Columns.Select(item => item.Name).ToArray());

                        int total = Domain.Helper.Stores.Count(Profile.SourceConnString, tableProfile.TableName);

                        int page = 0, pageSize = 100;

                        while (true)
                        {
                            page++;
                            int start = (page - 1) * pageSize + 1;
                            if (start > total) break;

                            System.Data.IDataReader dr = Domain.Helper.Stores.ReadPage(Profile.SourceConnString, tableProfile.TableName, start, pageSize);
                            dataSet.SetDataSource(dr);
                            Domain.Helper.Stores.Write(Profile.DestConnString, dataSet);
                        }

                        MigrateLog[tableProfile.TableName].Storage = MigrateState.Finished;
                        UpdateMessage($"{tableProfile.TableName}数据传输完成");
                    }

                }
                catch (Exception ex)
                {
                    UpdateMessage($"{tableProfile.TableName}数据传输失败:{ex.Message}");
                }
                finally
                {
                    IncreaseFinishedTask();
                }
            }
        }

        /// <summary>
        /// 建立约束
        /// </summary>
        public override void ExecConstraints()
        {
            // 需要创建约束的表
            IEnumerable<string> tableIncludeConstraint = Profile.ImpTables.Where(item => item.IncludeConstraint).Select(item => item.TableName);

            IEnumerable<Constraint> consts = Domain.Helper.Constraints.GetOwnerConstraints(Profile.SourceConnString)
                .Where(item => tableIncludeConstraint.Contains(item.TableName));

            // 规定约束建立的顺序
            List<Constraint> list = new List<Constraint>();
            list.AddRange(consts.Where(item => item.Type == "P"));
            list.AddRange(consts.Where(item => item.Type == "U"));
            list.AddRange(consts.Where(item => item.Type == "R"));

            foreach (var c in list)
            {
                try
                {
                    Constraint con = Domain.Helper.Constraints.GetConstraintDetail(Profile.SourceConnString, c.Name);
                    if (!string.IsNullOrEmpty(Profile.DestTablespace))
                    {
                        con.Tablespace = Profile.DestTablespace;
                    }
                    Domain.Helper.Constraints.CreateConstraints(Profile.DestConnString, con);
                    UpdateMessage($"{c.Name}约束创建成功");
                }
                catch (Exception ex)
                {
                    UpdateMessage($"{c.Name}约束创建失败:{ex.Message}");
                }
                finally
                {
                    IncreaseFinishedTask();
                }
            }
        }
    }
}
