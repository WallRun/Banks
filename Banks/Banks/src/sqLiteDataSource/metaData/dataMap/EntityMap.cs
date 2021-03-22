using System;
using System.Collections.Generic;

namespace Banks.dataSource.metaData
{
    public class EntityMap : DataMap
    {
        private readonly List<ColumnMap> primaryKeys = new();


        protected EntityMap(string name, ColumnMap primaryKey) : base(name) {
            
            primaryKeys.Add(primaryKey);
        }


        public List<ColumnMap> getPrimaryKeys() {
            return primaryKeys;
        }

        protected void addPrimaryKey(String name, String sqlType) {
            ColumnMap column = new ColumnMap(name, sqlType);

            primaryKeys.Add(column);;
        }

        protected void addPrimaryKey(String alias, EntityMap entityMap) {
            List<ColumnMap> primaryKeys = entityMap.getPrimaryKeys();
            foreach (ColumnMap primaryKey in primaryKeys) {
                String columnName = String.Concat(alias, primaryKey.getName());
                addPrimaryKey(columnName, primaryKey.getSqlType());
            }

            ParentEntity parentEntity = new ParentEntity(alias, entityMap);
            parentEntities.Add(parentEntity);
        }


        protected void addToDataMap(String alias, DataMap dataMap) {
            dataMap.addColumn(alias, this);
        }
    }
}