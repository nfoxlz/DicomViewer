using System.ComponentModel;

namespace DicomViewer
{
    [DisplayName("Dicom信息")]
    internal sealed class DicomInfo
    {
        [DisplayName("患者ID")]
        [Description("患者的唯一编号。")]
        public string? PatientID { get; set; }

        [DisplayName("患者姓名")]
        public string? PatientName { get; set; }

        [DisplayName("患者性别")]
        public string? PatientSex { get; set; }

        [DisplayName("患者生日")]
        public DateTime? PatientBirthDate { get; set; }
    }
}
