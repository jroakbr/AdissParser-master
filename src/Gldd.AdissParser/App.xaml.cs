using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Gldd.AdissParser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += (s, e) => LogAndNotify("Domain", e.ExceptionObject as Exception);
            App.Current.DispatcherUnhandledException += (s, e) => LogAndNotify("Dispatcher", e.Exception);
            TaskScheduler.UnobservedTaskException += (s, e) => LogAndNotify("Tasks", e.Exception);
#endif
        }

        private void LogAndNotify(object sender, Exception e)
        {
            Exception innerMostException = e.GetInnerMostException();

            string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            string productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

            string header = $@"
DateTime: {DateTime.Now.ToString("s")}
AssemblyVersion: {assemblyVersion}
FileVersion: {fileVersion}
ProductVersion: {productVersion}
Sender: {sender.ToString()}
HResult: {innerMostException.HResult}";

            string errorsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gldd", "AdissParser", "Errors");
            Directory.CreateDirectory(errorsFolder);

            string filePath = Path.Combine(errorsFolder, $"{DateTime.Now.ToString("yyyyMMddTHHmmss")}.txt");
            File.AppendAllText(filePath, header);
            File.AppendAllText(filePath, innerMostException.ToString());

            Func<string, int, string> limitTo = (str, length) =>
            {
                return (str == null || str.Length < length)
                  ? str
                  : str.Substring(0, length);
            };

            MessageBox.Show($@"Error due to ""{limitTo(innerMostException.Message, 500)}"". 

Please send the ""{Path.GetFileName(filePath)}"" to JanGo@gldd.com located in:

""{Path.GetDirectoryName(filePath)}""

We apologize for the inconvenience and will fix the cause of this error after receiving the report.

For urgent issues, please call Jan Go at 630-408-0817.", "An unhandled exception occured", MessageBoxButton.OK, MessageBoxImage.Error);
            Environment.Exit(1);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new Bootstrapper().Run();
        }
    }
}
