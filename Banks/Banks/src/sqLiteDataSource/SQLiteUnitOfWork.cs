using System.Data.SQLite;
using Banks.application.dataSource;
using Banks.application.infra;

namespace Banks.dataSource
{
    public class SQLiteUnitOfWork : IUnitOfWork
    {
        private readonly SQLiteConnection connection;
        private SQLiteTransaction transaction;

        public SQLiteUnitOfWork(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        public SQLiteConnection GetConnection()
        {
            return connection;
        }


        public bool TransactionIsOpen()
        {
            return transaction != null;
        }

        public void BeginTransaction()
        {
            if (transaction == null)
            {
                transaction = connection.BeginTransaction(); 
            }
            
        }

        public ErrorMessage Commit()
        {
            ErrorMessage errorMessage = new();
            try
            {
                transaction.Commit();
            }
            catch (SQLiteException e)
            {
                errorMessage.AddError("Не вдалося виконати транзакцію.");
            }

            if (errorMessage.HasError())
            {
                Rollback();
            }
            else
            {
                transaction = null;
            }

            return errorMessage;
        }

        public void Rollback()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
        }
    }
}