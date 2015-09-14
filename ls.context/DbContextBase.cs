using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ls.context
{
    public abstract class DbContextBase<TDbContext> : DbContext, IUnitOfWork where TDbContext : DbContext, IUnitOfWork, new()
    {
        #region 构造函数

        protected DbContextBase()
            : base(GetConnectionStringName())
        { }

        private static string GetConnectionStringName()
        {
            return ConfigurationManager.ConnectionStrings["default"].ToString();
        }


        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除一对多的级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //注册实体配置信息
            IEntityMapper[] entityMappers = DbContextManager.Instance.GetEntityMappers(typeof(TDbContext)).ToArray();
            foreach (IEntityMapper mapper in entityMappers)
            {
                mapper.RegistTo(modelBuilder.Configurations);
            }
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return Database.SqlQuery<TElement>(sql, parameters);
        }

        public System.Collections.IEnumerable SqlQuery(Type elementType, string sql, params object[] parameters)
        {
            return Database.SqlQuery(elementType, sql, parameters);
        }
    }
}
