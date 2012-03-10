using System.Data;
using System.Data.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Data.CubeSql.JSON
{
    public class CubeSqlCommand : DbCommand
    {
        #region Vars
        private string _sql;

        private int _timeout;
        private CommandType _type;
        private CubeSqlConnection _conn;
        #endregion

        #region Init
        public CubeSqlCommand()
        { 
        }

        public CubeSqlCommand(CubeSqlConnection conn)
        {
            _conn = conn;
        }
        #endregion

        #region Member
        public override int ExecuteNonQuery()
        {
            _conn.QueryJSON(
                "EXECUTE",
                this.CommandText
            );

            // TOBO: richtige zahl
            return 1;
        }

        public override object ExecuteScalar()
        {
            throw new System.NotImplementedException();
        }

        public override void Prepare()
        {
            throw new System.NotImplementedException();
        }

        public override void Cancel()
        {
        }
        #endregion

        #region Member - Protected
        protected override DbParameter CreateDbParameter()
        {
            throw new System.NotImplementedException();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            string json = _conn.QueryJSON("SELECT", _sql);

            if (_conn.CheckJson(json, false))
            {
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                foreach (Dictionary<string, object> row in (ArrayList)JSON.Instance.Parse(json))
                {
                    rows.Add(row);
                }

                if (rows.Count != 0)
                {
                    DataTable table = new DataTable();

                    foreach (var kvp in rows[0])
                    {
                        table.Columns.Add(
                            new DataColumn(
                                kvp.Key,
                                kvp.Value.GetType()
                            )
                        );
                    }

                    foreach (var dict in rows)
                    {
                        DataRow row = table.NewRow();

                        foreach (var kvp in dict)
                        {
                            row[kvp.Key] = kvp.Value;
                        }

                        table.Rows.Add(row);
                    }

                    return new DataTableReader(table);
                }
            }

            throw new Exception("Query failed.");
        }
        #endregion

        #region Properties
        public override string CommandText
        {
            get { return _sql; }
            set { _sql = value; }
        }

        public override int CommandTimeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public override CommandType CommandType
        {
            get { return _type; }
            set { _type = value; }
        }

        new public CubeSqlConnection Connection
        {
            get { return _conn; }
            set { _conn = value; }
        }

        protected override DbConnection DbConnection
        {
            get { return _conn; }
            set
            {
                if (!(value is CubeSqlConnection))
                {
                    throw new Exception("Connection Type not supported");
                }

                this.Connection = (CubeSqlConnection)value;
            }
        }

        protected override DbParameterCollection DbParameterCollection
        {
            get { throw new System.NotImplementedException(); }
        }

        protected override DbTransaction DbTransaction
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override bool DesignTimeVisible
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public override UpdateRowSource UpdatedRowSource
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }
        #endregion
    }
}