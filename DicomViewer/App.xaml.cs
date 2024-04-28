using FellowOakDicom;
using FellowOakDicom.Imaging;
using System.Windows;

namespace DicomViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e) => new DicomSetupBuilder().RegisterServices(service => service.AddFellowOakDicom().AddImageManager<WPFImageManager>()).Build();
    }

}
