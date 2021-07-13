# Asp.Net Mvc5 Adsız Sözlük
## Mvc Proje Kampı (Murat Yücedağ)

 Bu proje **Asp.Net Mvc5** ile geliştirilmiştir. Projede **HTML5**, **CSS3**, **JS**, **Bootstrap**, **Enttity Framework** teknolojileri kullanılmıştır. Projede kullanılan eklentiler **DataTables**, **Google Chart**, **Full Calendar**, **Sweet Alert**, **Fluent Validation**, **Recaptcha** şeklindedir. Proje **Entity Framework Code First** yaklaşımı ile geliştirilmiştir. Veritabanı olarak **MsSql** kullanılmıştır. Proje **N-Tier Architecture** tabanlı bir Asp.Net Mvc Projesidir. Projede **SOLID** presnsiplerine olabildiğince uyulmuştur. Proje Murat Yücedağ'ın kursları ile birlikte yapılmıştır. Proje sonunda proje canlıya alınmıştır [http://bedirhanerk-001-site1.etempurl.com/]. Proje kurulumu ve detaylı bilgi aşağıda verilmiştir.
 
## N-Tier Architecture
 
 - BusinessProcess Layer
 - Data Layer
 - Entity Layer
 - Presentation Layer

## Proje içeriğinde 4 kısım bulunmaktadrır

- Admin Panel
- Yazar Panel
- Sözlük
- Vitrin 

## Admin Panel

![ezgif com-gif-maker (3)](https://user-images.githubusercontent.com/65186980/125351651-0206bf80-e369-11eb-8eee-5ebaa5ccd3c9.gif)

Admin Panelindeki sayfalar şu şekildedir

1. Kategoriler
2. Başlıklar
3. Yazılar
4. Yazarlar
5. Grafikler
6. Hakkımızda
7. İletişim & Mesajlar
8. Yetkilendirmeler
9. Galeri
10. Yeteneklerim
11. Login
12. Register

 Admin Panelinde tema olarak AdminLte kullanılmıştır. Admin bilgileri database'de **Hash**'lenerek tutulmaktadır.

1. Kategoriler

 Bu sayfada kategoriler listelenmektedir. Buradan yeni kategori ekleyebilir, güncelleyebilir veya pasif hale getirebilirsiniz. Ayrıca bu kategorinin altında bulunan başlıkları görüntülüyebilirsiniz. Kategori sayfasından **paging** kulanılmıştır.
 
 2. Başlıklar

 Başlıklar kısmı 3 bölümden oluşmaktadır. İlk kısım başlık listesi; bu kısımda sözlükteki başlıkları görebilir. Başlıkları yazan yazarları, başlığın kategorisini ve başlığın aktif, pasif durumunu görebilirsiniz. Buradan başlık için yazılmış yorumları görebilir, güncelleme, pasif-aktif yapma ve başlık ekleme işlemi yapılabilir. Başlıkların ikinci kısmında **Full Calendar** kullanılmıştır. Buradan başlıkların hangi tarihlerde yazıldıklarını görebilirsiniz. Ayrıca başlıkların raporlarını alabilirsiniz. Bu raporu Excel, Pdf, Csv olarak alabilirsiniz. Başlıklar kısmında da **paging** kullanılmıştır.
 
 3. Yazılar

 Yazılar kısmına girdiğimizde ilk olarak bütün yazılar listelenmektedir. Bu yazıların üzerinde arama yapabilirsiniz.

 4. Yazarlar

 Bu kısımda bütün yazarların bilgileri listelenmektedir. Yazarın yazdığı başlıkları görebilir, yeni yazar ekleyebilir ve var olan yazarı güncelleyebilirsiniz.
 
 5. Grafikler
 
 Grafik olarak **Google Grafikler** kullanımıştır. 3 adet grafik vardır. Bunlar Yazar-Başlık Grafiği (Pie Chart), Kategori-Başlık Grafiği (Line Chart) ve Başlık-İçerik Grafiği (Columnn Chart).
 
 6. Hakkımızda
 
 Buradan vitrin kısmında bulunan hakkımızda kısmını güncelleyebilir, var olanı pasif - aktif yapabilir veya yeniden ekleyebilirsiniz. Hakkımızda kısmında da **paging** kullanılmıştır.
 
 7. İletişim & Mesajlar
 
 İlk olarak iletişim kısmında vitrin kısmından yazılan yardım mesajları adminler tarafından görülmekte ve cevaplanabilmektedir. İletişim mesajlarını sadece yetkisi olan adminler taradından görülebilmektedir. İkinci olarak mesajlar kısmı **Gmail** benzeri bir mesajlaşma yapılabilmektedir. Buradan yeni mesaj yazabilir, gelen mesajları ve gönderilen mesajlar görülebilir, mesaj taslak olarak kaydedilebilir ve silinebilmektedir.
 
 8. Yetkilendirmeler

 Bu kısım sadece yetkisi olan adminler tarafından görülmektedir. Buradan admin yetkilerini ayarlayabilir. Adminleri pasif - aktif hale getirebilirsiniz.
 
 9. Galeri
 
 Bu kısım sözlük galerisi olarak kullanılmıştır. Yeni resim ekleyebilir ve silebilirsiniz.
 
 10. Yeteneklerim

 Yeteneklerim sadece ödev üzerine yapılmış bir bölümdür. Buradan admin yetenekleri ekleyebilir, silebir ve güncelleyebilirsiniz.
 
 11. Login

 Login kısmında klasik bir şekide kayıt olduktan sonra giriş yapabiliyoruz.
 
 12. Register

 Register bölümünde bilgilerimizi girerek kayıt olabiliyoruz. Ayrıca burada **Recaptcha** kullanılmıştır.
 
 ## Yazar Panel
 
 ![ezgif com-gif-maker (2)](https://user-images.githubusercontent.com/65186980/125351095-53627f00-e368-11eb-884c-92de79c524d9.gif)
 
 Yazar Paneli'ndeki sayfalar şu şekildedir
 
 1. Profilim
 2. Başlıklarım
 3. Tüm Başlıklar
 4. Yazılarım
 5. Mesajlar
 6. Login
 7. Register
 
 Yazar Panelinde tema olarak AdminLte kullanılmıştır. Yazar bilgileri database'de **Hash**'lenerek tutulmaktadır.
 
 1. Profilim

 Yazar profilinde kişisel bilgilerini ve şifresini değiştirebilmektedir.
 
 2. Başlılarım

 Burada yazar kendi başlılarını, başlılarına yapılmış yorumları görebilir. Başlıkarını güncelleyebilir, silebilir ve yeni başlık ekleyebilir.
 
 3. Tüm Başlıklar
 
 Tüm başlıklar kısmında sözlükteki aktif başlıları görebilir. Bu başlıklara yapılmış yorumları görebilir ve başlılara yorumlarını ekleyebilir. Tüm Başlıklar kısmında da **paging** kullanılmıştır.
 
 4. Yazılarım

 Yazılarım bölümünde kendi yorumlarını görebililir. Hangi başlığa ne zaman ne yorum yapmış takip edebilir.
 
 5. Mesajlar

 Burada aynı admin panelindeki gibi bir mesajlaşma kısmı bulunmaktadır. Buradan diğer yazarlara ve adminlere mesaj yazabilir ve alabilir. Mesajları silebilir ve taslaklara kayıt edebilir.
 
 6. Login

 Login kısmında klasik bir şekide kayıt olduktan sonra giriş yapabiliyoruz.

 7. Register 

 Register bölümünde bilgilerimizi girerek kayıt olabiliyoruz. Ayrıca burada **Recaptcha** kullanılmıştır.
 
 
 ## Sözlük
 
 ![1](https://user-images.githubusercontent.com/65186980/125352848-755d0100-e36a-11eb-8752-2c0432af1b1a.PNG)

 Sözlük kısmında aslında aynı diğer sözlüklerde olduğu gibi favori başlıkları görebilir, bu başlıklara kim, ne zaman yorum yapmış görebilirsiniz. Buradan yazar olarak sisteme kayıt olabilir ve giriş yapabilirsiniz.
 
 ## Vitrin
 
 ![ezgif com-gif-maker (4)](https://user-images.githubusercontent.com/65186980/125353464-45622d80-e36b-11eb-93b3-bfebdc2c7340.gif)
 
 Bu kısmın amacı ürünüzmüzü tanıtmak için yapılmış dinamik bir kısımdır. Burada sözlüğü nasıl yaptığımızı hangi teknolojileri kullandığımızı görebilirsiniz. Buradan iletişim mesajları atabilirsiniz. Sözük kısmında veya giriş yapma, kayıt olma kısmına gidebilirsiniz.
 
 ## Kurulum

 Bu bölümde nasıl kurulum yapabileceğinizi anlatıcam. İlk olarak projeyi clone alıyoruz. Ardından  Database'i kurmamız gerekiyor. Database için dosyların içinde bulunan script (MvcProjeKampıScript.sql) dosyasını kullanarak kurabilirsiniz veya Back Up (MvcKampDb.bak) alınmış yedeği kullanarak kurabilirsiniz.
 
 *Admin Panel, User Panel, Sözlük kısımları template AdminLte'den, Admin Login ve Register, Yazar Login ve Register, 404 Sayfası colorlib'den, Yetenekler ve Vitrin kısmı w3layouts'dan alınmıştır.*
 
 Herhangi bir öneri veya şikayetiniz için Mail: erkilicbedirhan@gmail.com
 
 **Proje linki** : http://bedirhanerk-001-site1.etempurl.com/
 
Proje Bitirme Sertfikası:

![BEDİRHAN ERKILIÇ](https://user-images.githubusercontent.com/65186980/125415860-76fd5fc5-9747-4f34-938c-eccb98e05be4.jpg)
