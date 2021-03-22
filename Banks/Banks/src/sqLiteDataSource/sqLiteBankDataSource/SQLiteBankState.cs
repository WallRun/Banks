using Banks.model.bank;
using Banks.model.geo;

namespace Banks.dataSource.sqLiteBankDataSource
{
    public class SQLiteBankState : SQLiteState, IBankState
    {
        public Address GetAddress()
        {
            throw new System.NotImplementedException();
        }
    }
}