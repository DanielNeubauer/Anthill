using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Engine.Services.QueryBuilder
{
    public class SqlStructureBuilder : IToQuery, IColumn, ICreateStatementBuilder, ICreate, IPrimaryKey, IDropStatementBuilder, IDrop
    {
        public SqlStructureBuilder()
        {

        }

        private bool _isCreateTable;

        private string _tableName = "";
        private List<Tuple<string, string, int>> _columns = new List<Tuple<string, string, int>>();
        private List<string> _primaryKeys = new List<string>();
        private bool _isDropTable;

        public IDrop DropTable(string tableName)
        {
            _isDropTable = true;
            _tableName = tableName;
            return this;
        }

        public ICreate CreateTable(string tableName)
        {
            _isCreateTable = true;
            _tableName = tableName;
            return this;
        }

        public IColumn Column(string columnName, string type, int length = 0)
        {
            _columns.Add(new Tuple<string, string, int>(columnName, type, length));
            return this;
        }

        public IPrimaryKey PrimaryKey(params string[] columnNames)
        {
            _primaryKeys.AddRange(columnNames);
            return this;
        }

        public SqlStructureBuilder Clear()
        {
            _tableName = "";
            _columns = new List<Tuple<string, string, int>>();
            _primaryKeys = new List<string>();
            _isCreateTable = false;
            _isDropTable = false;
            return this;
        }

        public string ToQuery()
        {
            var stringBuilder = new StringBuilder();
            if (_isDropTable)
            {
                stringBuilder.Append($"DROP TABLE {_tableName};");
            }
            if (_isCreateTable)
            {
                stringBuilder.Append($"CREATE TABLE {_tableName}(");
                if (_columns.Count > 0)
                {
                    stringBuilder
                        .Append(string.Join(",", _columns.Select((tuple) =>
                        {
                            var output = $"{tuple.Item1} {tuple.Item2}";
                            if (tuple.Item3 > 0)
                            {
                                output += $"({tuple.Item3})";
                            }
                            return output;
                        })));
                }

                if (_primaryKeys.Count > 0)
                {
                    stringBuilder.AppendFormat(", PRIMARY KEY ({0})", string.Join(", ", _primaryKeys));
                }
                stringBuilder.Append(");");
            }
            return stringBuilder.ToString();
        }
    }
}
