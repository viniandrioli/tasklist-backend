using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Supero.DataBase.Persister.Model;
using Npgsql;

namespace Supero.DataBase.Persister.Common
{
    public class SuperoDbContext : DbContext
    {
        public SuperoDbContext()
          : base(nameOrConnectionString: "SuperoDbContext-Slave")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Database.CommandTimeout = 120;
        }

        public SuperoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString: nameOrConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Database.CommandTimeout = 120;
        }

        public DbSet<TaskList> TaskList { get; set; }

        public static List<T> ExecuteProc<T>(string procname, params NpgsqlParameter[] param)
        {
            List<T> list = null;
            string paranames = string.Empty;
            foreach (NpgsqlParameter p in param)
            {
                if (paranames != string.Empty)
                    paranames += ", ";
                paranames = paranames + "@" + p.ParameterName;
            }

            using (var context = new SuperoDbContext())
            {
                list = context.Database.SqlQuery<T>("select * from " + procname + "(" + paranames + ")", param).ToList<T>();
            }
            return list;
        }

        public static List<T> ExecView<T>(string viewname)
        {
            List<T> list = null;

            using (var context = new SuperoDbContext())
            {
                list = context.Database.SqlQuery<T>("select * from " + viewname).ToList<T>();
            }
            return list;
        }

    }
}
