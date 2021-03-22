namespace Banks.model.entity.@base
{
    public abstract class Entity<T> where T : IState
    {
        private T state;
        private IVersion version;

        protected Entity(T state)
        {
            this.state = state;
            version = state.CloneVersion();
        }
    }
}