using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace MVCDI.Models
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DomainDbContext context;
        private readonly IDbTransaction transaction;
        private readonly ObjectContext objectContext;

        public UnitOfWork(IDomainDbContext context)
        {
            this.context = context as DomainDbContext ?? new DomainDbContext();

            this.objectContext = ((IObjectContextAdapter)this.context).ObjectContext;

            if (this.objectContext.Connection.State != ConnectionState.Open)
            {
                this.objectContext.Connection.Open();
                this.transaction = objectContext.Connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            try
            {
                this.context.SaveChanges();
                this.transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
        }

        private void Rollback()
        {
            this.transaction.Rollback();

            foreach (var entry in this.context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Dispose()
        {
            if (this.objectContext.Connection.State == ConnectionState.Open)
            {
                this.objectContext.Connection.Close();
            }
        }
    }
}