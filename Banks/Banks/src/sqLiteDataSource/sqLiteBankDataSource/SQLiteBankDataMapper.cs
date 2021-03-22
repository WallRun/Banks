using System;
using System.Data.SQLite;
using Banks.application.infra;
using Banks.dataSource.metaData;
using Banks.model.bank;

namespace Banks.dataSource.sqLiteBankDataSource
{
    public class SQLiteBankDataMapper
    {
        private readonly SQLiteUnitOfWork unifOfWork;
        private readonly CatalogMap bankMap;
        private string insertQueryText;

        public SQLiteBankDataMapper(SQLiteUnitOfWork unifOfWork, CatalogMap bankMap)
        {
            this.unifOfWork = unifOfWork;
            this.bankMap = bankMap;
        }

        public SQLiteBankState GetEmptyState()
        {
            return new();
        }


        public ErrorMessage Save(Bank bank)
        {
            if (insertQueryText == null)
            {
                insertQueryText = SQLiteQueryTextFactory.InsertQueryText(bankMap);
            }
            
            SQLiteConnection connection = unifOfWork.GetConnection();
            SQLiteCommand sqLiteCommand = new(connection);
            sqLiteCommand.CommandText = insertQueryText;
            //sqLiteCommand.Parameters.Add(new SQLiteParameter("@Id", 2));
            sqLiteCommand.Parameters.Add(new SQLiteParameter("@Name", bank.GetName()));
            Console.WriteLine(sqLiteCommand.ExecuteNonQuery());

            return new ErrorMessage();

        }
    }
}