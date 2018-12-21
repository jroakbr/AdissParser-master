using Prism.Unity;
using System.Windows;
using Microsoft.Practices.Unity;

namespace Gldd.AdissParser
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindowView>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterType<IAdissCsvFileParser, AdissCsvFileParser>();
            Container.RegisterType<IOutputDataGenerator, OutputDataGenerator>();
            Container.RegisterType<IOutputDataCsvFileWriter, OutputDataCsvFileWriter>();
            Container.RegisterType<IHydroMdbService, HydroMdbService>();
            Container.RegisterType<IDrgFileParser, DrgFileParser>();
            Container.RegisterType<ICharlestonDeepening2Service, CharlestonDeepening2Service>();
            Container.RegisterType<IDredgeRecordExtractor, DredgeRecordExtractor>();
        }
    }
}