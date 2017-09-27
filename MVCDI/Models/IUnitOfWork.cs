using System;

namespace MVCDI.Models
{
    public partial interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}