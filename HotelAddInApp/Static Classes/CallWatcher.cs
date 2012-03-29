using System;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelAddInApp
{
#if PHONE
    internal static class CallWatcher
    {
        #region Vars
        private static bool _stop;

        private static Thread _thread;
        private static SerialPort _port;

        private static List<FieldInfo> _pbx;
        #endregion

        #region Init
        static CallWatcher()
        {
            _port = new SerialPort();

            _port.ReadTimeout = 500;
            Refresh();
        }
        #endregion

        #region Private Member
        private static void _workLine(string line)
        {
            Call call = _createObject(line);

            var calls = Call.ReadAll();

            calls.Add(call);

            Call.SaveAll(calls); 
            
            GastwareInterface.BookCall(call);

            Program.Form.Invoke(
                new Action(Program.Form.RefreshCallList)
            );
            StatusInfo.WriteLine("Telefonat: {0} -> {1}", call.ExtensionLine, call.CallNumber);
        }
        #endregion

        #region Private Member - Run
        private static void _runThread()
        {
            try
            {
                while (!_stop)
                {
                    string line = "";

                    try
                    {
                        line = _port.ReadLine();

                        _workLine(line);
                    }
                    catch (TimeoutException)
                    {
                        _thread.Join(500);
                    }
                    catch (Exception ex)
                    {
                        StatusInfo.WriteLine("Telefonüberwachnung: Fehler: {0} - Zeile: {1}", ex.Message, line);
                    }
                }
            }
            finally
            {
                _thread = null;
                _port.Close();

                StatusInfo.SetCallWatcher();
            }
        }
        #endregion

        #region Private Member - Load
        private static List<FieldInfo> _loadConfigFile(string filename)
        {
            List<FieldInfo> fields = null;

            if (File.Exists(filename))
            {
                fields = new List<FieldInfo>();

                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                foreach (XmlNode node in doc.LastChild)
                {
                    if (node.NodeType == XmlNodeType.Comment || node.Name != "field") continue;

                    if (node.Attributes["key"] != null && node.Attributes["start"] != null)
                    {
                        FieldInfo info = new FieldInfo(
                            node.Attributes["key"].Value,
                            Int32.Parse(node.Attributes["start"].Value)
                        );

                        if (node.Attributes["length"] != null)
                        {
                            info.Length = Int32.Parse(node.Attributes["length"].Value);
                        }
                        else if (node.Attributes["endstring"] != null)
                        {
                            info.EndString = node.Attributes["endstring"].Value;
                        }
                        else
                        {
                            throw new Exception();
                        }

                        fields.Add(info);
                    }
                }
            }

            return fields;
        }
        #endregion

        #region Private Member - CreateObject
        private static Call _createObject(string content)
        {
            Call call = new Call();

            string date = "dd.MM.yyyy hh:mm:ss";
            string duration = "hh:mm:ss";

            foreach (FieldInfo info in _pbx)
            {
                string value = info.GetValue(content).Trim();

                switch (info.Key)
                {
                    case "date":
                        call.DateTime = DateTime.Parse(value);
                        break;
                    case "date_now":
                        call.DateTime = DateTime.Now;
                        break;
                    case "date_day":
                        date = date.Replace("dd", value);
                        break;
                    case "date_month":
                        date = date.Replace("MM", value);
                        break;
                    case "date_year":
                        date = date.Replace("yyyy", value);
                        break;
                    case "time_hour":
                        date = date.Replace("hh", value);
                        break;
                    case "time_minute":
                        date = date.Replace("mm", value);
                        break;
                    case "time_secound":
                        date = date.Replace("ss", value);
                        break;
                    case "duration":
                        call.Duration = TimeSpan.Parse(value);
                        break;
                    case "duration_hour":
                        duration = duration.Replace("hh", value);
                        break;
                    case "duration_minute":
                        duration = duration.Replace("mm", value);
                        break;
                    case "duration_secound":
                        duration = duration.Replace("ss", value);
                        break;
                    case "units":
                        call.Units = Int32.Parse(value);
                        break;
                    case "line":
                        call.ExtensionLine = value;
                        break;
                    case "number":
                        if (Settings.GetSetting<bool>("call.censorship"))
                        {
                            if (value.Length > 3)
                            {
                                call.CallNumber = value.Substring(0, value.Length - 3) + "XXX";
                            }
                            else
                            {
                                call.CallNumber = "XXX";
                            }
                        }
                        else
                        {
                            call.CallNumber = value;
                        }
                        break;
                    case "linedescription":
                        call.LineDescription = value;
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show(info.Key + ": " + value);
                        break;
                }
            }

            if (call.DateTime == DateTime.MinValue) call.DateTime = DateTime.Parse(date);
            if (call.Duration == TimeSpan.MinValue) call.Duration = TimeSpan.Parse(duration);

            return call;
        }
        #endregion

        #region Fields
        public static SerialPort Port
        {
            get { return _port; }
        }

        public static bool Running
        {
            get { return (_thread != null); }
        }
        #endregion

        #region Member - Refresh
        public static void Refresh()
        {
            bool run = Running && !_stop;

            if (run)
            {
                StopWatch();
            }

            try
            {
                _pbx = _loadConfigFile(
                    Settings.GetSetting<string>("call.pbx")
                );

                _port.PortName = Settings.GetSetting<string>("call.com.port");
                _port.BaudRate = Settings.GetSetting<int>("call.com.baudrate");
                _port.Parity = Settings.GetSetting<Parity>("call.com.parity");
                _port.DataBits = Settings.GetSetting<int>("call.com.databits");
                _port.StopBits = Settings.GetSetting<StopBits>("call.com.stopbits");
                _port.Handshake = Settings.GetSetting<Handshake>("call.com.handshake");

                if (run)
                {
                    StartWatch();
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Telefonüberwachungs-Einstellungen fehlerhaft. Bitte überprüfen Sie die Einstellungen.", "Telefonüberwachung", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Member - Start/Stop
        public static void StartWatch()
        {
            if (!Running)
            {
                _stop = false;
                _thread = new Thread(_runThread);

                try
                {
                    _port.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        Program.Form,
                        "Telefonüberwachnung konnte nicht gestartet werden. Fehler: " + ex.Message,
                        "Telefonüberwachnung",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                _thread.Start();

                StatusInfo.SetCallWatcher();
            }
        }

        public static void StopWatch()
        {
            if (Running)
            {
                _stop = true;

                DateTime start = DateTime.Now;
                while (Running)
                {
                    Thread.CurrentThread.Join(50);

                    if ((DateTime.Now - start).Seconds > 5)
                    {
                        _thread.Abort();
                        Thread.CurrentThread.Join(2000);
                        _port.Close();
                        break;
                    }
                }
            }
        }
        #endregion

        #region Class - FieldInfo
        private class FieldInfo
        {
            #region Vars
            private string _key;

            private int _start;

            private int _length;
            private string _end;
            #endregion

            #region Init
            public FieldInfo(string key, int start)
            {
                _key = key;
                _start = start - 1;
            }

            public FieldInfo(string key, int start, int length)
                : this(key, start)
            {
                _length = length;
            }

            public FieldInfo(string key, int start, string end)
                : this(key, start)
            {
                _end = end;
            }
            #endregion

            #region Fields
            public string Key
            {
                get { return _key; }
                set { _key = value; }
            }

            public int Start
            {
                get { return _start; }
                set { _start = value; }
            }


            public int Length
            {
                get { return _length; }
                set { _length = value; }
            }

            public string EndString
            {
                get { return _end; }
                set { _end = value; }
            }
            #endregion

            #region Member
            public string GetValue(string row)
            {
                if (_end == null)
                {
                    return row.Substring(_start, _length);
                }
                else
                {
                    int length = row.IndexOf(_end, _start) - _start;

                    return row.Substring(_start, length);
                }
            }
            #endregion
        }
        #endregion
    }
#endif
}
