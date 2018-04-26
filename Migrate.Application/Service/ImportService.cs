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
    public class ImportService : MigrateService
    {
        public ImportService(MigrateProfile profile)
        {
            Profile = profile;
        }

        private Reader reader { get; set; }

        protected override void BeforeExecute()
        {
            string dir = System.Environment.GetEnvironmentVariable("TEMP");
            reader = new Reader(Profile.TargetFile, dir);

            using (PartialReader pr = reader.ReadPartial(reader.Header["profile"]))
            {
                Profile.ImpTables = pr.Read<IList<TableProfile>>(pr.Header["ImpTables"]);
                taskSumCount = (int)pr.Read(pr.Header["taskSumCount"]);
            }

            InitMigrateLog();
        }

        public override void ExecTableSchema()
        {
            using (PartialReader pr = reader.ReadPartial(reader.Header["tableSchema"]))
            {
                foreach (var entry in pr.Header)
                {
                    try
                    {
                        Table tableDetail = pr.Read<Table>(entry);
                        Domain.Helper.Tables.CreateTable(Profile.DestConnString, tableDetail);
                        MigrateLog[tableDetail.Name].TableStruct = MigrateState.Finished;

                        UpdateMessage($"{tableDetail.Name}表结构导入完成");
                    }
                    catch (Exception ex)
                    {
                        UpdateMessage(ex.Message);
                    }
                    finally
                    {
                        IncreaseFinishedTask();
                    }
                }
            }
        }

        public override void ExecStorage()
        {
            
            using (PartialReader pr = reader.ReadPartial(reader.Header["storage"]))
            {
                taskSumCount += pr.Header.Count;
                foreach (var entry in pr.Header)
                {
                    try
                    {
                        MDataSet dataSet = pr.Read<MDataSet>(entry);
                        Domain.Helper.Stores.Write(Profile.DestConnString, dataSet);
                        MigrateLog[dataSet.Table].Storage = MigrateState.Finished;

                        UpdateMessage($"{dataSet.Table}数据导入完成");
                    }
                    catch (Exception ex)
                    {
                        UpdateMessage(ex.Message);
                    }
                    finally
                    {
                        IncreaseFinishedTask();
                    }
                }
            }
        }

        public override void ExecConstraints()
        {
            using (PartialReader pr = reader.ReadPartial(reader.Header["constraint"]))
            {
                foreach (var entry in pr.Header)
                {
                    try
                    {
                        Constraint con = pr.Read<Constraint>(entry);
                        Domain.Helper.Constraints.CreateConstraints(Profile.DestConnString, con);
                        MigrateLog[con.TableName].Constraint = MigrateState.Finished;

                        UpdateMessage($"{con.TableName}约束导入成功");
                    }
                    catch (Exception ex)
                    {
                        UpdateMessage(ex.Message);
                    }
                    finally
                    {
                        IncreaseFinishedTask();
                    }
                }
            }
        }
    }
}
