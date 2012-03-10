using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace System.Data.CubeSql.Native
{
    public class CubeSqlConnection : DbConnection
    {
        #region Vars
        private string _connStr;

        private string _host;
        private int _port;
        private string _username;
        private string _password;
        private string _database;

        internal IntPtr _db;

        private Encoding _encode = Encoding.Default;

        private ConnectionState _state = ConnectionState.Closed;
        #endregion

        #region Init
        public CubeSqlConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        #endregion

        #region Private Member - Crypt
        private string _createRandpool()
        {
            string s = "";
            Random r = new Random();

            for (int i = 0; i <= 10; i++)
            {
                s += (char)r.Next(33, 126);
            }

            return s;
        }

        private byte[] _sha1(byte[] bytes)
        {
            SHA1 sha = SHA1.Create();

            return sha.ComputeHash(bytes);
        }

        private string _sha1(string str)
        {
            return BitConverter.ToString(
                _sha1(_encode.GetBytes(str))
            ).Replace("-", "").ToLower();
        }

        private byte[] _sha1(string str, bool t)
        {
            return _sha1(
                _encode.GetBytes(str)
            );
        }
        #endregion

        #region Member
        protected override DbCommand CreateDbCommand()
        {
            return new CubeSqlCommand(this);
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Member - Query
        internal IntPtr QueryJSON(string sql, bool select = true)
        {
            if (this.State != ConnectionState.Open)
            {
                this.Open();
            }

            if (this.State == ConnectionState.Open)
            {
                sql = sql.Replace("\r\n", " ");
                sql = sql.Replace("\t", " ");
                sql = sql.Replace("\\", "");

#if DEBUG
                File.WriteAllText("C:\\test.sql", sql);
#endif
                if (select)
                {
                    return NativeMethods.cubesql_select(
                        _db,
                        sql,
                        CubeSqlBool.False
                    );
                }
                else
                {
                    int err = NativeMethods.cubesql_execute(
                        _db,
                        sql
                    );

                    if (err != 0)
                    {
                        throw new Exception("cubesql_execute: error");
                    }

                    return IntPtr.Zero;
                }

                this.Close();

                return IntPtr.Zero;
            }

            return IntPtr.Zero;
        }
        #endregion

        #region Member - Open/Close
        public override void Open()
        {
            if (this.State == ConnectionState.Open)
            {
                throw new Exception("Connection already open");
            }

            _state = ConnectionState.Connecting;

            int err = NativeMethods.cubesql_connect(
                out _db,
                _host,
                _port,
                _username,
                _password,
                NativeMethods.DefaultTimeout,
                CubeSqlEncryption.None
            );

            if (err == 0)
            {
                err = NativeMethods.cubesql_execute(
                    _db,
                    String.Format("USE DATABASE '{0}';", _database)
                );
            }

            if (err == 0)
            {
                _state = ConnectionState.Open;
            }
        }

        public override void Close()
        {
            NativeMethods.cubesql_disconnect(out _db, CubeSqlBool.True);

            _state = ConnectionState.Closed;
        }
        #endregion

        #region Properties
        public override string ConnectionString
        {
            get { return _connStr; }
            set
            {
                _connStr = value;

                string[] parts = value.Split(';');

                foreach (string part in parts)
                {
                    string[] alloc = part.Split('=');

                    switch (alloc[0].ToLower())
                    {
                        case "host":
                            _host = alloc[1];
                            break;
                        case "port":
                            _port = Int32.Parse(alloc[1]);
                            break;
                        case "username":
                            _username = alloc[1];
                            break;
                        case "password":
                            _password = alloc[1];
                            break;
                        case "database":
                            _database = alloc[1];
                            break;
                    }
                }
            }
        }

        public override ConnectionState State
        {
            get { return _state; }
        }

        public override string DataSource
        {
            get { return _host; }
        }

        public override string Database
        {
            get { throw new NotImplementedException(); }
        }

        public override string ServerVersion
        {
            get { throw new NotImplementedException(); }
        }
        #endregion   
    }
}