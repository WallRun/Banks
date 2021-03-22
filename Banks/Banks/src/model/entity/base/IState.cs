namespace Banks.model.entity.@base
{
    public interface IState
    {
        public string GetName();
        public IVersion CloneVersion();
    }
}