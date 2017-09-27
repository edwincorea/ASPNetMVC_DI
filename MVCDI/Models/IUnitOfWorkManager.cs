using System;

namespace MVCDI.Models
{
    public interface IUnitOfWorkManager : IDisposable
    {
        IUnitOfWork NewUnitOfWork();
    }
}