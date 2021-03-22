using Banks.dataSource.metaData;
using Banks.dataSource.sqLiteBankDataSource;

namespace Banks.dataSource
{
    public class SQLiteDataMapperFactory
    {
        private readonly SQLiteUnitOfWork unitOfWork;
        private SQLiteBankDataMapper bankMapper;

        public SQLiteDataMapperFactory(SQLiteUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public SQLiteBankDataMapper CreateBankDataMapper()
        {
            if (bankMapper == null)
            {
                CatalogMap bankCatalogMap = MetaDataFactory.CreateBankDataMap();
                bankMapper = new(unitOfWork, bankCatalogMap);
            }

            return bankMapper;
        }
    }
}