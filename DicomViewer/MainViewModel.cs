using CommunityToolkit.Mvvm.Input;
using FellowOakDicom;
using FellowOakDicom.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace DicomViewer
{
    internal sealed partial class MainViewModel
    {
        [RelayCommand]
        private static void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != true)
                return;

            var dataset = DicomFile.Open(dialog.FileName).Dataset;

            var info = new DicomInfo();
            if (dataset.TryGetValues<string>(DicomTag.PatientID, out var patientID) && patientID.LongLength > 0L)
                info.PatientID = patientID[0];
            if (dataset.TryGetValues<string>(DicomTag.PatientName, out var patientName) && patientName.LongLength > 0L)
                info.PatientName = patientName[0];
            if (dataset.TryGetValues<string>(DicomTag.PatientSex, out var patientSex) && patientSex.LongLength > 0L)
                info.PatientSex = patientSex[0];
            if (dataset.TryGetValues<DateTime>(DicomTag.PatientBirthDate, out var patientBirthDate) && patientBirthDate.LongLength > 0L)
                info.PatientBirthDate = patientBirthDate[0];
            //dataset.TryGetValues<string>(DicomTag.PatientAge, out var patientAge);

            Global.MainDocumentPane!.Children.Add(new LayoutDocument()
            {
                Content = new Image { Source = new DicomImage(dataset).RenderImage().AsWriteableBitmap(), Tag = info },
                Title = Path.GetFileName(dialog.FileName),
            });
            Global.MainDocumentPane.SelectedContentIndex = Global.MainDocumentPane.Children.Count - 1;
        }
    }
}
