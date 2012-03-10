using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HotelAddInApp
{
    public static class Settings
    {
        #region Vars
        private static IFormatter _formatter = new BinaryFormatter();
        #endregion

        #region Private Member
        private static string _getFilename(string key, string computerName)
        {
            return Path.Combine(
                SettingsPath,
                String.Format(
                    @"{0}{1}.cms",
                    (computerName == null ? "" : computerName + @"\"),
                    key
                )
            );
        }
        #endregion

        #region Private Member - Read/Write
        private static void _writeSetting(string path, object value)
        {
            string dir = Path.GetDirectoryName(path);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            FileStream stream = null;
            try
            {
                stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                stream.SetLength(0);

                _formatter.Serialize(stream, value);
            }
            catch
            {
            }
            finally
            {
                if (stream != null) stream.Dispose();
            }
        }

        private static T _readSetting<T>(string filename)
        {
            filename = filename.ToLower().Replace('/', '.');

            if (File.Exists(filename))
            {
                try
                {
                    object obj = null;

                    FileStream stream = null;
                    try
                    {
                        stream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                        obj = _formatter.Deserialize(stream);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (stream != null) stream.Dispose();
                    }

                    if (obj != null)
                    {
                        return (T)obj;
                    }
                }
                catch
                {
                    //Can't convert Setting.
                }
            }

            return default(T);
        }
        #endregion

        #region Member - Settings
        public static bool ExistsSetting(string key)
        {
            return File.Exists(
                _getFilename(key, null)
            );
        }

        public static T GetSetting<T>(string key)
        {
            return _readSetting<T>(
                _getFilename(key, null)
            );
        }

        public static void SetSetting(string key, object value)
        {
            key = key.ToLower();

            _writeSetting(
                _getFilename(key, null),
                value
            );
        }
        #endregion

        #region Member - ComputerSettings
        public static bool ExistsComputerSetting(string key)
        {
            return File.Exists(
                _getFilename(key, Environment.MachineName)
            );
        }

        public static T GetComputerSetting<T>(string key)
        {
            return _readSetting<T>(
                _getFilename(key, Environment.MachineName)
            );
        }

        public static void SetComputerSetting(string key, object value)
        {
            key = key.ToLower();

            _writeSetting(
                _getFilename(key, Environment.MachineName),
                value
            );
        }
        #endregion

        #region Fields
        public static string SettingsPath
        {
            get { return HotelAddIn.Settings.PathData + @"\Data\Settings\"; }
        }
        #endregion
    }
}
