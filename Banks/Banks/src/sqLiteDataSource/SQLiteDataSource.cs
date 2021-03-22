using Banks.application.dataSource;
using Banks.application.infra;
using System.Data.SQLite;
using System.IO;
using Banks.dataSource.sqLiteBankDataSource;

namespace Banks.dataSource
{
    public class SQLiteDataSource : IDataSource
    {

        private SQLiteUnitOfWork unitOfWork;
        private SQLiteDataMapperFactory dataMapperFactory;


        public IUnitOfWork GetUnitOfWork()
        {
            return unitOfWork;
        }

        public IBankDAO GetBankDAO()
        {
            SQLiteBankDataMapper bankDataMapper = dataMapperFactory.CreateBankDataMapper();
            return new SQLiteBankDAO(bankDataMapper);
        }

        public ErrorMessage Connect()
        {
            ErrorMessage errorMessage = new();
            if (!File.Exists("./database.sqlite3"))
            {
                errorMessage.AddError("Відсутній файл бази даних.");
                return errorMessage;
            }
            
            SQLiteConnection conn = new SQLiteConnection("Data Source=database.sqlite3");

            try
            {
                conn.Open();
            }
            catch (SQLiteException e)
            {
                errorMessage.AddError("Помилка підключення до бази даних.");
                return errorMessage;
            }

            unitOfWork = new(conn);
            dataMapperFactory = new(unitOfWork);
            

            return errorMessage;
        }
        
    }
}