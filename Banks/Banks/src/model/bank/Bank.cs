using Banks.model.entity.@base;
using Banks.model.geo;

namespace Banks.model.bank
{
    public class Bank : Entity<IBankState>
    {
        private string name;
        private Address address;

        
        public Bank(IBankState state) : base(state)
        {
            name = state.GetName();
            //address = state.GetAddress();
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public Address GetAddress()
        {
            return address;
        }
    }
}