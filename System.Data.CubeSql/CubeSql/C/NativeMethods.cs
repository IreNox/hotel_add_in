using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Data.CubeSql.Native
{
    #region Enums
    public enum CubeSqlBool
    {
        False = 0,
        True = 1
    }

    public enum CubeSqlError
    {
        NoError = 0,
        Error = -1,
        MemoryError = -2,
        ParameterError = -3,
        ProtocolError = -4,
        ZLibError = -5
    }

    public enum CubeSqlEncryption
    {
        None = 0,
        AES128 = 2,
        AES192 = 3,
        AES256 = 4
    }

    public enum CubeSqlType
    {
        None = 0,
        Integer = 1,
        Float = 2,
        Text = 3,
        Blob = 4,
        Boolean = 5,
        Date = 6,
        Time = 7,
        Timestamp = 8,
        Currency = 9
    }
    #endregion

    public static class NativeMethods
    {
        #region Vars
        public const string DllName = "cubesql.dll";

        public const int DefaultPort = 4430;
        public const int DefaultTimeout = 12;
        #endregion

        #region Member - Main
        [DllImport(DllName)]
        public static extern int cubesql_connect(out IntPtr db, string host, int port, string username, string password, int timeout, CubeSqlEncryption encryption);

        [DllImport(DllName)]
        public static extern void cubesql_disconnect(out IntPtr db, CubeSqlBool gracefully);

        [DllImport(DllName)]
        public static extern  int cubesql_execute (IntPtr db, string sql);

        [DllImport(DllName)]
        public static extern IntPtr cubesql_select (IntPtr db, string sql, CubeSqlBool server_side);

        [DllImport(DllName)]
        public static extern int cubesql_commit (IntPtr db);

        [DllImport(DllName)]
        public static extern int cubesql_rollback (IntPtr db);

        //[DllImport(DllName)]
        //public static extern int cubesql_bind (IntPtr db, string sql, char **colvalue, int *colsize, int *coltype, int ncols);

        [DllImport(DllName)]
        public static extern int cubesql_ping (IntPtr db);

        [DllImport(DllName)]
        public static extern int cubesql_errcode (IntPtr db);

        [DllImport(DllName)]
        public static extern string cubesql_errmsg (IntPtr db);
        #endregion

        #region Member - Cursor
        [DllImport(DllName)]
        public static extern int cubesql_cursor_numrows (IntPtr sql);
                             
        [DllImport(DllName)] 
        public static extern int cubesql_cursor_numcolumns (IntPtr sql);

        [DllImport(DllName)]
        public static extern int cubesql_cursor_currentrow(IntPtr c);

        [DllImport(DllName)]
        public static extern int cubesql_cursor_seek(IntPtr c, int index);

        [DllImport(DllName)]
        public static extern int cubesql_cursor_iseof(IntPtr c);

        [DllImport(DllName)]
        public static extern CubeSqlType cubesql_cursor_columntype(IntPtr c, int index);

        [DllImport(DllName)]
        public static extern IntPtr cubesql_cursor_field(IntPtr c, int row, int column, out int len);

        [DllImport(DllName)]
        public static extern long cubesql_cursor_rowid(IntPtr c, int row);

        [DllImport(DllName)]
        public static extern long cubesql_cursor_int64(IntPtr c, int row, int column, long default_value);

        [DllImport(DllName)]
        public static extern int cubesql_cursor_int(IntPtr c, int row, int column, int default_value);

        [DllImport(DllName)]
        public static extern double cubesql_cursor_double(IntPtr c, int row, int column, double default_value);

        [DllImport(DllName)]
        public static extern IntPtr cubesql_cursor_cstring(IntPtr c, int row, int column);

        [DllImport(DllName)]
        public static extern IntPtr cubesql_cursor_cstring_static(IntPtr c, int row, int column, IntPtr static_buffer, int bufferlen);

        [DllImport(DllName)]
        public static extern void cubesql_cursor_free(IntPtr c);
        #endregion

        #region Member - Extensions
        public static Type GetTypeObject(CubeSqlType source)
        {
            switch (source)
            { 
                case CubeSqlType.Blob:
                    return typeof(byte[]);
                case CubeSqlType.Boolean:
                    return typeof(bool);
                case CubeSqlType.Currency:
                    return typeof(double);
                case CubeSqlType.Date:
                    return typeof(DateTime);
                case CubeSqlType.Float:
                    return typeof(float);
                case CubeSqlType.Integer:
                    return typeof(int);
                case CubeSqlType.Text:
                    return typeof(string);
                case CubeSqlType.Time:
                    return typeof(TimeSpan);
                case CubeSqlType.Timestamp:
                    return typeof(DateTime);
            }

            return typeof(string);
        }
        #endregion
    }
}
