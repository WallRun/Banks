using Banks.application.infra;
using Banks.model.bank;

namespace Banks.application.service
{
    public interface IBankService
    {
        Bank Create();
        ErrorMessage Save(Bank bank);
        
    }
}