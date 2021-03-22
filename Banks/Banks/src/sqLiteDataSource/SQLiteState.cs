using Banks.model.entity.@base;

namespace Banks.dataSource
{
    public abstract class SQLiteState : IState
    {
        private readonly SQLiteVersion version;
        private string name;

        protected SQLiteState()
        {
            version = new(1);
            name = "";
        }

        public IVersion CloneVersion()
        {
            int currentValue = version.GetValue();
            return new SQLiteVersion(currentValue);
        }

        public SQLiteVersion GetVersion()
        {
            return version;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        
        public string GetName()
        {
            return name;
        }
    }
}