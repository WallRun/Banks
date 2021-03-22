using Banks.application.dataSource;
using Banks.application.infra;
using Banks.model.bank;

namespace Banks.dataSource.sqLiteBankDataSource
{
    public class SQLiteBankDAO : IBankDAO
    {
        private readonly SQLiteBankDataMapper dataMapper;

        public SQLiteBankDAO(SQLiteBankDataMapper dataMapper)
        {
            this.dataMapper = dataMapper;
        }
        
        public IBankState GetEmptyState()
        {
            return dataMapper.GetEmptyState();
        }

        public ErrorMessage Save(Bank bank)
        {
            return dataMapper.Save(bank);
        }
    }
}