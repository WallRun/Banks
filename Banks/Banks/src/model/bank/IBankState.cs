using Banks.model.entity.@base;
using Banks.model.geo;

namespace Banks.model.bank
{
    public interface IBankState : IState
    {
        Address GetAddress();
    }
}