using System;
using System.Collections.Generic;

namespace Banks.dataSource.metaData
{
    public class DataMap 
    {
        private readonly string name;
        protected readonly List<ColumnMap> columns = new();
        protected readonly List<ParentEntity> parentEntities = new();


        protected DataMap(string name) {
            this.name = name;
        }


        public string getName() {
            return name;
        }

        public List<ColumnMap> getColumns() {
            return columns;
        }

        public List<ParentEntity> getParentEntities() {
            return parentEntities;
        }


        protected static ColumnMap createColumn(string name, string sqlType) {
            return new ColumnMap(name, sqlType);
        }


        internal void addColumn(string name, string sqlType) {
            ColumnMap column = new ColumnMap(name, sqlType);

            columns.Add(column);
        }

        internal void addColumn(string alias, EntityMap entityMap) {
            List<ColumnMap> primaryKeys = entityMap.getPrimaryKeys();
            foreach (ColumnMap primaryKey in primaryKeys) {
                string columnName = String.Concat(alias, primaryKey.getName());
                addColumn(columnName, primaryKey.getSqlType());
            }

            ParentEntity parentEntity = new ParentEntity(alias, entityMap);
            parentEntities.Add(parentEntity);
        }
    }
}