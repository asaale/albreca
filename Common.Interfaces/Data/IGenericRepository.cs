using Albreca.Common.Interfaces.Marker;

namespace Albreca.Common.Interfaces.Data
{
    public interface IGenericRepository<T> : IRepository<T> where T : class
    {
    }
}