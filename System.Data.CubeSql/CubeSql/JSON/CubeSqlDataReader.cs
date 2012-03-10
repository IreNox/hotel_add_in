using System;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

namespace System.Data.CubeSql.JSON
{
    public class CubeSqlDataReader : DbDataReader
    {
        #region Vars
        private CubeSqlCommand _sql;

        private string _json;
        private List<Dictionary<string, object>> _rows;

        private DataTable _table;
        #endregion

        #region Init
        public CubeSqlDataReader(CubeSqlCommand sql)
        {
            _sql = sql;

            _json = sql.Connection.QueryJSON(
                "SELECT",
                sql.CommandText
            );

            _rows = new List<Dictionary<string, object>>();
            foreach (Dictionary<string, object> row in (ArrayList)JSON.Instance.Parse(_json))
            {
                _rows.Add(row);
            }

            if (_rows.Count != 0)
            {
                _table = new DataTable();

                foreach (var kvp in _rows[0])
                {
                    _table.Columns.Add(
                        new DataColumn(
                            kvp.Key,
                            kvp.Value.GetType()
                        )
                    );
                }

                foreach (var dict in _rows)
                {
                    DataRow row = _table.NewRow();

                    foreach (var kvp in dict)                    
                    {
                        row[kvp.Key] = kvp.Value;
                    }

                    _table.Rows.Add(row);
                }
            }
        }
        #endregion

        #region Member
        public override void Close()
        {
        }
        #endregion

        #region Member - Get
        public override object GetValue(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override bool GetBoolean(int ordinal)
        {
            return (bool)this.GetValue(ordinal);
        }

        public override byte GetByte(int ordinal)
        {
            return (byte)this.GetValue(ordinal);
        }

        public override char GetChar(int ordinal)
        {
            return (char)this.GetValue(ordinal);
        }

        public override DateTime GetDateTime(int ordinal)
        {
            return (DateTime)this.GetValue(ordinal);
        }

        public override decimal GetDecimal(int ordinal)
        {
            return (decimal)this.GetValue(ordinal);
        }

        public override double GetDouble(int ordinal)
        {
            return (double)this.GetValue(ordinal);
        }

        public override float GetFloat(int ordinal)
        {
            return (float)this.GetValue(ordinal);
        }

        public override Guid GetGuid(int ordinal)
        {
            return (Guid)this.GetValue(ordinal);
        }

        public override short GetInt16(int ordinal)
        {
            return (short)this.GetValue(ordinal);
        }

        public override int GetInt32(int ordinal)
        {
            return (int)this.GetValue(ordinal);
        }

        public override long GetInt64(int ordinal)
        {
            return (long)this.GetValue(ordinal);
        }

        public override string GetString(int ordinal)
        {
            return (string)this.GetValue(ordinal);
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Member - Cols
        public override string GetDataTypeName(int ordinal)
        {
            return (string)this.GetValue(ordinal);
        }
        
        public override Type GetFieldType(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override string GetName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public override bool IsDBNull(int ordinal)
        {
            throw new NotImplementedException();
        }
        #endregion


        public override System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public override int FieldCount
        {
            get { throw new NotImplementedException(); }
        }

        public override DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public override int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public override bool HasRows
        {
            get { throw new NotImplementedException(); }
        }

        public override bool IsClosed
        {
            get { return false; }
        }



        public override bool NextResult()
        {
            throw new NotImplementedException();
        }

        public override bool Read()
        {
            throw new NotImplementedException();
        }

        public override int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public override object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public override object this[int ordinal]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
