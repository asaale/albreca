using System.Data.Entity;
using System.Transactions;
using Albreca.Common.Interfaces.Data;
using Albreca.Data.DataModel;

namespace Albreca.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly AlbrecaContainer _db;

        public UnitOfWork()
        {
            _db = new AlbrecaContainer();
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public DbContext Db { get { return _db; } }
    }
}