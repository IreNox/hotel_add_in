using System.Data;
using System.Data.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace System.Data.CubeSql.Native
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
            _conn.QueryJSON(this.CommandText, false);

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
            IntPtr db = _conn._db;
            IntPtr sql = _conn.QueryJSON(_sql);

            int tmp = 0;

            if (sql != IntPtr.Zero)
            {
                DataTable table = new DataTable();

                int rowCount = NativeMethods.cubesql_cursor_numrows(sql);
                int colCount = NativeMethods.cubesql_cursor_numcolumns(sql);

                Dictionary<int, CubeSqlType> _colTypes = new Dictionary<int,CubeSqlType>();

                for (int col = 1; col <= colCount; col++)
                {
                    CubeSqlType type = NativeMethods.cubesql_cursor_columntype(sql, col);

                    IntPtr p = NativeMethods.cubesql_cursor_field(sql, 0, col, out tmp);

                    string name = Marshal.PtrToStringAnsi(p);

                    table.Columns.Add(
                        new DataColumn(
                            name,
                            NativeMethods.GetTypeObject(type)
                        )
                    );

                    _colTypes.Add(col, type);
                }

                IntPtr pointer = Marshal.AllocHGlobal(1024);

                for (int r = 1; r <= rowCount; r++)
                {
                    DataRow row = table.NewRow();

                    for (int c = 1; c <= colCount; c++)
                    {
                        object obj = null;

                        try
                        {
                            switch (_colTypes[c])
                            {
                                case CubeSqlType.Blob:
                                    obj = null;
                                    break;
                                case CubeSqlType.Boolean:
                                    int b = NativeMethods.cubesql_cursor_int(sql, r, c, 0);

                                    obj = (b == 0 ? false : true);
                                    break;
                                case CubeSqlType.Date:
                                    IntPtr p1 = NativeMethods.cubesql_cursor_cstring_static(
                                        sql,
                                        r,
                                        c,
                                        pointer,
                                        1024
                                    );

                                    obj = DateTime.Parse(
                                        Marshal.PtrToStringAnsi(p1)
                                    );

                                    //Marshal.FreeHGlobal(p1);
                                    break;
                                case CubeSqlType.Integer:
                                    obj = NativeMethods.cubesql_cursor_int(sql, r, c, 0);
                                    break;
                                case CubeSqlType.None:
                                case CubeSqlType.Text:
                                    IntPtr p2 = NativeMethods.cubesql_cursor_cstring_static(
                                        sql,
                                        r,
                                        c,
                                        pointer,
                                        1024
                                    );

                                    string text;
                                    if (p2 == IntPtr.Zero)
                                    {
                                        text = Marshal.PtrToStringAnsi(pointer);
                                    }
                                    else
                                    {
                                        text = Marshal.PtrToStringAnsi(p2);
                                    }

                                    if (text != null)
                                    {
                                        byte[] b2 = System.Text.Encoding.GetEncoding(1047).GetBytes(text);

                                        b2 = System.Text.Encoding.Convert(
                                            System.Text.Encoding.GetEncoding(1047),
                                            System.Text.Encoding.UTF8,
                                            b2
                                        );

                                        obj = System.Text.Encoding.UTF8.GetString(b2);
                                    }
                                    else
                                    {
                                        obj = null;
                                    }

                                    //Marshal.FreeHGlobal(p2);
                                    break;
                                default:
                                    obj = null;
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }

                        row[c - 1] = obj;
                    }

                    table.Rows.Add(row);
                }

                Marshal.FreeHGlobal(pointer);
                NativeMethods.cubesql_cursor_free(sql);

                return new DataTableReader(table);
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