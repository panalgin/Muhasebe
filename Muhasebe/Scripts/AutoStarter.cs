using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Muhasebe.Scripts
{
    /// <summary>
    /// Enables or disables the autostart (with the OS) of the application.
    /// </summary>
    public static class AutoStarter
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string VALUE_NAME = "Daflan Mikro Kaynak Yönetimi";
        private static string APP_LOCATION = "\"" + Assembly.GetExecutingAssembly().Location + "\" /auto";

        /// <summary>
        /// Set the autostart value for the assembly.
        /// </summary>
        public static void SetAutoStart()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.SetValue(VALUE_NAME, APP_LOCATION);
        }

        /// <summary>
        /// Returns whether auto start is enabled.
        /// </summary>
        public static bool IsAutoStartEnabled
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
                if (key == null)
                    return false;

                string value = (string)key.GetValue(VALUE_NAME);
                if (value == null)
                    return false;
                return (value == APP_LOCATION);
            }
        }

        /// <summary>
        /// Unsets the autostart value for the assembly.
        /// </summary>
        public static void UnSetAutoStart()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.DeleteValue(VALUE_NAME);
        }
    }
}
