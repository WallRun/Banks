using Banks.application.infra;

namespace Banks.application.dataSource
{
    public interface IUnitOfWork
    {
        bool TransactionIsOpen();
        void BeginTransaction();
        ErrorMessage Commit();
        void Rollback();
    }
}