using System;
using System.Collections.Generic;

namespace Banks.dataSource.metaData
{
    public class CatalogMap : EntityMap
    {
        private readonly List<DataMap> tabularParts = new();


        internal CatalogMap(string name) :
            base(name, createColumn("Id", "INTEGER")) {
            
        }


        public List<DataMap> getTabularParts() {
            return tabularParts;
        }


        protected void addTabularPart(DataMap dataMap) {
            addToDataMap(getName(), dataMap);
            tabularParts.Add(dataMap);
        }
    }
}