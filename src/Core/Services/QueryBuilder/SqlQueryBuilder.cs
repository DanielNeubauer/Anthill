using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anthill.Engine.Services.QueryBuilder
{
    public class SqlQueryBuilder : ISelectQueryBuilder, IInsertStatementBuilder, IUpdateStatementBuilder, ISelect, IFrom, IWhere, IInsertInto, IValues, IUpdate, ISet
    {
        public SqlQueryBuilder()
        {

        }

        private string _table = "";
        private List<string> _values = new List<string>();
        private List<string> _wheres = new List<string>();
        private List<string> _columns = new List<string>();
        private List<string> _orderBy = new List<string>();

        private bool isInsert = false;
        private bool isUpdate = false;
        private bool isSelect = false;

        private IEnumerable<string> CorrectValues(object[] values)
        {
            return values.Select((input, output) => CorrectValue(input));
        }

        private string CorrectValue(object value)
        {
            if (value.GetType() == typeof(string))
            {
                return $"'{value}'";
            }
            if (value.GetType() == typeof(bool))
            {
                return value.ToString().ToLowerInvariant();
            }
            return value.ToString();
        }

        #region Select
        public ISelect Select(params string[] parameters)
        {
            isSelect = true;
            _columns.AddRange(parameters);
            return this;
        }

        public IFrom From(string tableName)
        {
            _table = tableName;
            return this;
        }

        public IWhere Where(params string[] whereClauses)
        {
            _wheres.AddRange(whereClauses);
            return this;
        }

        public IOrderBy OrderBy(params string[] fields)
        {
            _orderBy.AddRange(fields);
            return this;
        }

        #endregion

        #region Insert
        public IInsertInto InsertInto(string tableName)
        {
            isInsert = true;
            _table = tableName;
            return this;
        }

        public IValues Values(params Tuple<string, object>[] clauses)
        {
            foreach (var clause in clauses)
            {
                _columns.Add(clause.Item1);
                _values.Add(CorrectValue(clause.Item2));
            }
            return this;
        }

        public IValues Values(params object[] values)
        {
            var correctValues = CorrectValues(values);
            _values.AddRange(correctValues);
            return this;
        }

        public IValues Value(object value)
        {
            _values.Add(CorrectValue(value));
            return this;
        }

        public IValues Value(string column, object value)
        {
            _values.Add(CorrectValue(value));
            _columns.Add(column);
            return this;
        }
        #endregion
               
        #region Update

        public IUpdate Update(string tableName)
        {
            isUpdate = true;
            _table = tableName;
            return this;
        }

        public ISet Set(params Tuple<string, object>[] clauses)
        {
            foreach(var clause in clauses)
            {
                _columns.Add(clause.Item1);
                _values.Add(CorrectValue(clause.Item2));
            }
            return this;
        }

        public ISet Set(string column, object value)
        {
            _columns.Add(column);
            _values.Add(CorrectValue(value));
            return this;
        }
        #endregion

        public SqlQueryBuilder Clear()
        {
            _values.Clear();
            _wheres.Clear();
            _columns.Clear();
            _orderBy.Clear();
            isInsert = false;
            isUpdate = false;
            isSelect = false;
            return this;
        }

        public string ToQuery()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (isInsert)
            {
                stringBuilder.Append($"INSERT INTO {_table}");
                if (_columns.Count > 0)
                {
                    stringBuilder.AppendFormat(" ({0})", string.Join(", ", _columns));
                }
                stringBuilder.Append(" VALUES ");
                stringBuilder.AppendFormat("({0})", string.Join(", ", _values));
            }
            if (isUpdate && _columns.Count > 0 && _values.Count > 0)
            {
                stringBuilder.Append($"UPDATE {_table} ");
                stringBuilder.Append("SET ");
                var sets = new List<string>();
                for(int i = 0; i< _columns.Count; i++)
                {
                    sets.Add($"{_columns[i]}={_values[i]}");
                }
                stringBuilder.Append(string.Join(", ", sets));
            }
            if (isSelect)
            {
                stringBuilder.Append("SELECT ");
                if (_columns.Count == 0)
                {
                    stringBuilder.Append("*");
                }
                else
                {
                    stringBuilder.Append(string.Join(", ", _columns));
                }
                stringBuilder.Append($" FROM {_table}");
            }
            if(_wheres.Count > 0)
            {
                stringBuilder.Append(" WHERE ");
                stringBuilder.Append(string.Join(" AND ", _wheres));
            }
            if(_orderBy.Count > 0)
            {
                stringBuilder.Append(" ORDER BY ");
                stringBuilder.Append(string.Join(", ", _orderBy));
            }
            return stringBuilder.ToString();
        }
    }
}
