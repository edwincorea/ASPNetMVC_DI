
using System;
using System.Data.Entity;

namespace MVCDI.Models
{
    public class UnitOfWorkManager
    {
        private bool isDisposed;
        private readonly DomainDbContext context;

        public UnitOfWorkManager(IDomainDbContext context)
        {
            Database.SetInitializer<DomainDbContext>(null);
            this.context = context as DomainDbContext;
        }

        public IUnitOfWork NewUnitOfWork()
        {
            return new UnitOfWork(this.context);
        }

        public void Dispose()
        {
            if (this.isDisposed == false)
            {
                this.context.Dispose();
                this.isDisposed = true;
            }
        }
    }
}