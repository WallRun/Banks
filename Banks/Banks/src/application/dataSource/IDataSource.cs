namespace Banks.application.dataSource
{
    public interface IDataSource
    {
        public IUnitOfWork GetUnitOfWork();
        public IBankDAO GetBankDAO();
        
    }
}