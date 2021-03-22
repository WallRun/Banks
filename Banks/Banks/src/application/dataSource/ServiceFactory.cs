using Banks.application.service;

namespace Banks.application.dataSource
{
    public class ServiceFactory
    {
        private static readonly ServiceFactory soleInstance = new();
        private IDataSource dataSource;
        
        private ServiceFactory()
        {
            
        }
        
        private static ServiceFactory GetInstance()
        {
            return soleInstance;
        }

        public static void Initialize(IDataSource dataSource)
        {
            GetInstance().dataSource = dataSource;
        }

        public static BankService CreateBankService()
        {
            IUnitOfWork unitOfWork = GetInstance().dataSource.GetUnitOfWork();
            IBankDAO bankDao = GetInstance().dataSource.GetBankDAO();
            return new BankService(unitOfWork, bankDao);
        }
    }
}