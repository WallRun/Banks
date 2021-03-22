namespace Banks.dataSource.metaData
{
    public class ParentEntity
    {
        private readonly string alias;
        private readonly EntityMap entityMap;


        internal ParentEntity(string alias, EntityMap entityMap) {
            this.alias = alias;
            this.entityMap = entityMap;
        }


        public string getAlias() {
            return alias;
        }

        public EntityMap getEntityMap() {
            return entityMap;
        }
    }
}