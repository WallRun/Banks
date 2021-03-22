namespace Banks.dataSource.metaData
{
    public class MetaDataFactory
    {
        public static CatalogMap CreateBankDataMap()
        {
            CatalogMap bankMap = new("Banks");
            bankMap.addColumn("Name", "NVARCHAR(64)");
            
            
            return bankMap;
        }
    }
}