namespace Banks.dataSource.metaData
{
    public class ColumnMap
    {
        private readonly string name;
        private readonly string sqlType;


        internal ColumnMap(string name, string sqlType) {
            this.name = name;
            this.sqlType = sqlType;
        }


        public string getName() {
            return name;
        }

        public string getSqlType() {
            return sqlType;
        }
    }
}