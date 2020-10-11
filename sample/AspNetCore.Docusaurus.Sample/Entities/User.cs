using System.Collections.Generic;
using System.ComponentModel;

namespace AspNetCore.Docusaurus.Sample.Entities
{
    public class User
    {
        [Description("Kullanıcıların Adını Tutar.")]
        public string Name { get; set; }
        [Description("Kullanıcıların Soyadlarını Tutar.")]
        public string Surname { get; set; }
        [Description("Kullanıcı Cihazının Bilgisini Tutar.")]
        public UserDevice UserDevice { get; set; }
    }
}
