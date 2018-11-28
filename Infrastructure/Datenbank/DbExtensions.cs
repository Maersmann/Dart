using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;



namespace infrastructure.Datenbank
{
    public static class DbExtensions
    {

        private class IdResult
        {
            public int Id { get; set; }
        }

        public static BindingList<T> ToBindingList<T>
            (this IQueryable<T> source) where T : class
        {
            return (new ObservableCollection<T>(source)).ToBindingList();
        }


        public static int NextValueFor(this DbModel dbContext, string genName)
        {
            string sql = String.Format("SELECT NEXT VALUE FOR {0} AS Id FROM RDB$DATABASE", genName);
            return dbContext.Database.SqlQuery<IdResult>(sql).First().Id;
        }

        public static void DetachAll<T>(this DbModel dbContext, DbSet<T> dbSet) where T : class {         
            foreach (var obj in dbSet.Local.ToList())
            {
                dbContext.Entry(obj).State = EntityState.Detached;
            }
        }


        public static void Refresh(this DbModel dbContext, RefreshMode mode, IEnumerable collection)
        {
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            objectContext.Refresh(mode, collection);
        }


        public static void Refresh(this DbModel dbContext, RefreshMode mode, object entity)
        {
            var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
            objectContext.Refresh(mode, entity);
        }
    }
}
