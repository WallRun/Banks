using Banks.application.dataSource;
using Banks.application.infra;
using Banks.application.service.validator;
using Banks.model.bank;

namespace Banks.application.service
{
    public class BankService : IBankService
    {
        private IUnitOfWork unitOfWork;
        private readonly IBankDAO bankDao;
        

        public BankService(IUnitOfWork unitOfWork, IBankDAO bankDao)
        {
            this.unitOfWork = unitOfWork;
            this.bankDao = bankDao;
        }

        public Bank Create()
        {
            IBankState bankState = bankDao.GetEmptyState();
            return new Bank(bankState);
        }

        public ErrorMessage Save(Bank bank)
        {
            ErrorMessage errorMessage = BankValidator.Validate(bank);
            if (errorMessage.HasError())
            {
                return errorMessage;
            }

            if (unitOfWork.TransactionIsOpen())
            {
                errorMessage = bankDao.Save(bank);
            }
            else
            {
                unitOfWork.BeginTransaction();
                errorMessage = bankDao.Save(bank);

                if (!errorMessage.HasError())
                {
                    errorMessage = unitOfWork.Commit();
                    
                }
                else
                {
                    unitOfWork.Rollback();
                }
            }

            return errorMessage;
        }
    }
}