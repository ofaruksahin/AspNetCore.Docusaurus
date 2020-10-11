using System.ComponentModel;

namespace AspNetCore.Docusaurus.Sample.Entities
{
    [Description("Kullanıcı Cihaz Bilgisini Tutar.")]
    public class UserDevice
    {
        public string DeviceName { get; set; }
    }
}
