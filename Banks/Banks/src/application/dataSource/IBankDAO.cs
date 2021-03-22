using Banks.application.infra;
using Banks.model.bank;

namespace Banks.application.dataSource
{
    public interface IBankDAO
    {
        public IBankState GetEmptyState();
        ErrorMessage Save(Bank bank);
    }
}