using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart.FileIO;
using Migrate.Application.Model;
using Migrate.Domain.Helper.Access;
using Migrate.Domain.Model;
using System.IO;

namespace Migrate.Application
{
    public class ExportService : MigrateService
    {
        public ExportService(MigrateProfile profile)
        {
            Profile = profile;
        }

        private Writer writer { get; set; }

        protected override void BeforeExecute()
        {
            base.BeforeExecute();

            string file = Path.GetFileName(Profile.TargetFile);
            string dir = System.Environment.GetEnvironmentVariable("TEMP");
            writer = new Writer(file, dir);

            PartialWriter pw = writer.CreatePartial("profile", "导出表的信息");
            pw.Append("ImpTables", Profile.ImpTables);
            pw.Append("taskSumCount", taskSumCount);
            pw.Commit();
        }

        public override void ExecTableSchema()
        {
            PartialWriter pw = writer.CreatePartial("tableSchema", "表结构的详细信息");
            foreach (var tableProfile in Profile.ImpTables)
            {
                try
                {
                    Table tableDetail = Domain.Helper.Tables.GetTableDetails(Profile.SourceConnString, tableProfile.TableName);

                    pw.Append(tableDetail.Name, tableDetail);

                    MigrateLog[tableProfile.TableName].TableStruct = MigrateState.Finished;

                    UpdateMessage($"{tableProfile.TableName}表结构导出完成");
                }
                catch (Exception ex)
                {
                    UpdateMessage($"{tableProfile.TableName}表结构导出失败:\n{ex.Message}");
                }
                finally
                {
                    IncreaseFinishedTask();
                }
            }
            pw.Commit();
        }

        public override void ExecStorage()
        {
            PartialWriter pw = writer.CreatePartial("storage", "数据");
            int page_index = 0;

            IEnumerable<TableProfile> tableIncludeStorage = Profile.ImpTables.Where(item => item.IncludeStorage);
            foreach (var tableProfile in tableIncludeStorage)
            {
                try
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

                        pw.Append($"{page_index++}", dataSet);
                    }

                    MigrateLog[tableProfile.TableName].Storage = MigrateState.Finished;
                    UpdateMessage($"{tableProfile.TableName}数据导出完成");

                }
                catch (Exception ex)
                {
                    UpdateMessage($"{tableProfile.TableName}数据导出失败:{ex.Message}");
                }
                finally
                {
                    IncreaseFinishedTask();
                }
            }

            pw.Commit();
        }

        public override void ExecConstraints()
        {
            PartialWriter pw = writer.CreatePartial("constraint", "约束结构");

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
                    pw.Append(c.Name, con);

                    UpdateMessage($"{c.Name}约束导出成功");
                }
                catch (Exception ex)
                {
                    UpdateMessage($"{c.Name}约束导出失败:{ex.Message}");
                }
                finally
                {
                    IncreaseFinishedTask();
                }
            }
            pw.Commit();
        }

        protected override void AfterExecute()
        {
            string file = Path.GetFileName(Profile.TargetFile);
            string dir = System.Environment.GetEnvironmentVariable("TEMP");
            writer.Commit();

            if (File.Exists(Profile.TargetFile))
            {
                File.Delete(Profile.TargetFile);
            }
            File.Move(Path.Combine(dir, file), Profile.TargetFile);
        }
    }
}
