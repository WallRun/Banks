using System;
using System.Collections.Generic;
using System.Text;
using Banks.dataSource.metaData;

namespace Banks.dataSource
{
    public class SQLiteQueryTextFactory
    {
        public static string InsertQueryText(CatalogMap entityMap)
        {
            string tableName = entityMap.getName();

            string strSpaceAndOpenBracket = " (";
            string strCommaAndSpace = ", ";
            //string strQuestionMark = "?";
            string strAtMark = "@";
            string strSpace = " ";

            StringBuilder sqlBuilder = new StringBuilder("INSERT INTO");
            sqlBuilder.Append(strSpace);
            sqlBuilder.Append(tableName);
            sqlBuilder.Append(strSpaceAndOpenBracket);

            bool firstColumn = true;
            string columnName = "";

            /*
            List<ColumnMap> primaryKeys = entityMap.getPrimaryKeys();
            foreach (ColumnMap primaryKey in primaryKeys)
            {
                if (firstColumn == false)
                {
                    sqlBuilder.Append(strCommaAndSpace);
                }
                else
                {
                    firstColumn = false;
                }

                columnName = primaryKey.getName();

                sqlBuilder.Append(columnName);
            }
            */

            List<ColumnMap> columns = entityMap.getColumns();
            foreach (ColumnMap column in columns)
            {
                if (firstColumn == false)
                {
                    sqlBuilder.Append(strCommaAndSpace);
                }
                else
                {
                    firstColumn = false;
                }

                columnName = column.getName();

                sqlBuilder.Append(columnName);
            }

            sqlBuilder.Append(") VALUES (");

            firstColumn = true;

            /*foreach (ColumnMap primaryKey in primaryKeys)
            {
                if (firstColumn == false)
                {
                    sqlBuilder.Append(strCommaAndSpace);
                }
                else
                {
                    firstColumn = false;
                }

                sqlBuilder.Append(strAtMark);
                sqlBuilder.Append(primaryKey.getName());
            }*/

            foreach (ColumnMap column in columns)
            {
                if (firstColumn == false)
                {
                    sqlBuilder.Append(strCommaAndSpace);
                }
                else
                {
                    firstColumn = false;
                }

                sqlBuilder.Append(strAtMark);
                sqlBuilder.Append(column.getName());
            }

            sqlBuilder.Append(")");

            string sqlText = sqlBuilder.ToString();
            return sqlText;
        }
    }
}