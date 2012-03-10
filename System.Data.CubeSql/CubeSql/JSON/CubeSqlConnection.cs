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

namespace System.Data.CubeSql.JSON
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

        private IPEndPoint _endPoint;

        private Socket _sock;
        private Encoding _encode = Encoding.Default;

        private ConnectionState _state = ConnectionState.Closed;
        #endregion

        #region Init
        public CubeSqlConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        #endregion

        #region Private Member - Send
        private string _sendRequest(Dictionary<string, string> data)
        {
            string json = JSON.Instance.ToJSON(data, false);

            if (!_sock.Connected)
            {
                json = _createError(9999, "Connection closed.");
            }
            else
            {
                _sock.Send(
                    _encode.GetBytes(json)
                );
            }

            if (!_sock.Connected)
            {
                json = _createError(9999, "Connection closed.");
            }
            else
            {
                int count = 0;
                byte[] buffer = new byte[2048];
                MemoryStream stream = new MemoryStream();

                while (true)
                {
                    count = _sock.Receive(buffer);

                    stream.Write(buffer, 0, count);

                    if (count < buffer.Length) break;
                }

                json = _encode.GetString(
                    stream.ToArray()
                );
                stream.Dispose();
            }

            this.CheckJson(json, true);

            return json;
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

        #region Private Member - Error
        private string _createError(int code, string msg)
        {
            return String.Format(
                "{\"errorCode\": {0}, \"errorMsg\": \"{1}\"}",
                code,
                msg
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

        #region Member - Error
        public bool CheckJson(string json, bool msgbox)
        {
            if (json.Substring(2, 9) == "errorCode")
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)JSON.Instance.Parse(json);

                if (dict.ContainsKey("errorCode") && (string)dict["errorCode"] != "0")
                {
                    if (_sock.Connected) _sock.Close();

                    if (msgbox)
                    {
                        MessageBox.Show("CubeSQL error. Message: " + dict["errorMsg"]);
                    }

                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Member - Query
        internal string QueryJSON(string command, string sql)
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

                var res = _sendRequest(
                    new Dictionary<string, string>() { 
                        { "command", command },
                        { "sql", sql }
                    }
                );

                this.Close();

                return res;
            }

            return _createError(9998, "Query faild");
        }
        #endregion

        #region Member - Open/Close
        public override void Open()
        {
            if (this.State == ConnectionState.Open)
            {
                throw new Exception("Connection already open");
            }

            string randpool = _createRandpool();

            _state = ConnectionState.Connecting;

            _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _sock.Connect(_endPoint);
            string res = _sendRequest(
                new Dictionary<string, string>() {
                    { "command", "CONNECT" },
                    { "username", _sha1(randpool + _username) },
                    { "password", _sha1(randpool + Convert.ToBase64String(_sha1(_sha1(_password, true)))) },
                    { "randpool", randpool },
                }
            );

            if (this.CheckJson(res, false))
            {
                res = _sendRequest(
                    new Dictionary<string, string>() { 
                        { "command", "EXECUTE" },
                        { "sql", String.Format("USE DATABASE '{0}';", _database) }
                    }
                );
            }

            if (this.CheckJson(res, false))
            {
                _state = ConnectionState.Open;
            }
        }

        public override void Close()
        {
            if (!_sock.Connected) return;

            _sendRequest(
                new Dictionary<string,string>() {
                    { "command", "DISCONNECT" }
                }
            );
            _sock.Close();
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

                _endPoint = new IPEndPoint(
                    Dns.GetHostAddresses(_host)[0],
                    _port
                );
            }
        }

        public override ConnectionState State
        {
            get
            {
                if (_state == ConnectionState.Open && !_sock.Connected)
                {
                    _state = ConnectionState.Closed;
                }

                return _state;
            }
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