using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Layouts;
using ArcGIS.Desktop.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProTestCrash
{
    internal class Module1 : Module
    {
        private static Module1 _this = null;

        public static string ModuleName = "TestProCrash";

        private Module1()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                // how could we limit these to only our addin? They catch issue cross addin
                var ex = (Exception)e.ExceptionObject;
                Log("*** Sample Pro Crash! ***", "UnhandledException" + ex.Message);

            };
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                // how could we limit these to only our addin? They catch issue cross addin
                Log("*** Sample Pro Crash! ***", "UnobservedTaskException" + e.Exception.Message);
            };

        }

        internal static void Log(string message, [CallerMemberName] string caller = "")
        {
            Console.WriteLine("{0}: {1}", caller, message); 
            MessageBox.Show($"{message}: {caller}");
        }

        /// <summary>
        /// Retrieve the singleton instance to this module here
        /// </summary>
        public static Module1 Current => _this ?? (_this = (Module1)FrameworkApplication.FindModule("ProTestCrash_Module"));

        #region Overrides
        /// <summary>
        /// Called by Framework when ArcGIS Pro is closing
        /// </summary>
        /// <returns>False to prevent Pro from closing, otherwise True</returns>
        protected override bool CanUnload()
        {
            //TODO - add your business logic
            //return false to ~cancel~ Application close
            return true;
        }

        #endregion Overrides

    }
}
