# AspNetCore.Docusaurus

## Docusaurus Nedir?
Docusaurus yazılımcıların alt yapı ve tasarım gibi ayrıntılara takılmadan dökümantasyon web sayfalarını kolaylaştırmak için tasarlanmış bir araçtır.
Aslında projenin yaptığı işlem sizin projenizi docusaurus için uygun markdown formatı haline getirmek. İsterseniz bu markdown dosyalarını kendi isteğinize göre kişiselleştirebilirsiniz.
Docusaurus bizim için varsayılan stiller, biçimler ve basit bir navigation ile bir dökümantasyon için ihtiyacımız olan her şeyi sunuyor.

## Docusaurus Projesinin Çıkış Amacını Kendileri Nasıl Özetlemişler ?
* To put the focus on writing good documentation instead of worrying about the infrastructure of a website.
* To provide features that many of our open source websites need like blog support, search and versioning.
* To make it easy to push updates, new features, and bug fixes to everyone all at once.
* And, finally, to provide a consistent look and feel across all of our open source projects.

## Docusaurus Projesini Kendi Web API Projeme Nasıl Entegre Edebilirim ?
1. Docusaurus paketlerini yükleyin ve boş bir docusaurus projesi oluşturun. 
```
npx docusaurus-init
```
2. Web API Projesine Docusaurus paketini yükleyin.
```
PM > Install-Package AspNetCore.Docusaurus.Core -Version 1.0.0
dotnet add package AspNetCore.Docusaurus.Core --version 1.0.0
<PackageReference Include="AspNetCore.Docusaurus.Core" Version="1.0.0" />
```
3. Projenin startup.cs içerisine gelin ve ConfigureServices altında gerekli tanımlamaları yapın.
```csharp
   services.AddDocusaurus(new DocusaurusOptions
            {
                DocumentTitle = "Docusaurus .Net Core API",
                DocumentPath = @"C:\Users\Faruk\Desktop\test",
                MainPage = "doc1",
                ProjectAssembly = Assembly.GetExecutingAssembly(),
                XmlFilePath = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml"
            });
```

4. Projenin startup.cs içerisine gelin ve Configure altında gerekli tanımlamaları yapın.
```csharp
 app.UseDocusaurus();
```

## Örnek Proje
[Örnek projeyi görüntülemek için tıklayınız.](https://github.com/RichWarrior/AspNetCore.Docusaurus/tree/main/sample/AspNetCore.Docusaurus.Sample)

![Alt text](/images/1.PNG?raw=true)
![Alt text](/images/2.PNG?raw=true)
![Alt text](/images/3.PNG?raw=true)

