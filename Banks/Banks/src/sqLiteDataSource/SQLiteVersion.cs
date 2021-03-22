using Banks.model.entity.@base;

namespace Banks.dataSource
{
    public class SQLiteVersion : IVersion
    {
        private int value;

        public SQLiteVersion(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }
    }
}