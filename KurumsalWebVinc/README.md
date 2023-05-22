# KurumsalWebVinc
ck editor https://www.youtube.com/watch?v=BeeYSs9I_WM
https://hakanguzel.com/net-core-mvc-ckeditor-entegrasyonu-ve-sunucuya-resim-yukleme-ozelligi/
https://stackoverflow.com/questions/63977698/how-upload-image-in-ckeditor-5-with-asp-net-core-razor-pages
    
    puplis ayarlarý
    delete exist false
    Configuration: release
    target fw: net6.0
    runtime:portable

    InvalidOperationException: Templates can be used only with field access, property access, single-dimension array index, or single-parameter custom indexer expressions.
hatasý çözümü : 
bu kodu @Html.DisplayFor(modelItem => item.Fiyat.ToString("N0")) >>>> @item.Fiyat.ToString("N0") bunla deðiþ,

****** NullReferenceException: Object reference not set to an instance of an object. 
diyorssa sayfada refarasn edilmemiþ servis olabilir %90

403 - Forbidden: Access is denied.
https://uzmanim.net/soru/asp-net-mvc-403-forbidden-access-is-denied-hatasi/7035
<system.webServer>
    <modules runAllManagedModulesForAllRequests="true"></modules>
    <handlers>
      <remove name="UrlRoutingHandler"/>
    </handlers>
  </system.webServer>
