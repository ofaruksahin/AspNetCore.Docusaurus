using AspNetCore.Docusaurus.Core.Attributes;

namespace AspNetCore.Docusaurus.Sample.Entities
{
    [DocusaurusDescription("Kullanıcılar Bilgisini Tutar.")]
    public class User
    {
        [DocusaurusDescription("Kullanıcıların Adını Tutar.")]
        public string Name { get; set; }
        [DocusaurusDescription("Kullanıcıların Soyadlarını Tutar.")]
        public string Surname { get; set; }
    }
}
