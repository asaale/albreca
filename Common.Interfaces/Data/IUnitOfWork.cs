using System.Data.Entity;
using Albreca.Common.Interfaces.Marker;

namespace Albreca.Common.Interfaces.Data
{
    public interface IUnitOfWork : IService
    {
        void Commit();
        void StartTransaction();
        DbContext Db { get; }
    }
}