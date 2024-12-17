# Kitap Otomasyon Sistemi - MVC Web Uygulaması

Bu proje, bir **Kitap Otomasyon Sistemi**'nin geliştirilmesi için oluşturulmuş bir **MVC Web Uygulaması**'dır. Sistem, kullanıcıların kitaplar eklemesine, kitap detaylarını görüntülemesine, kullanıcı yönetimi yapmasına ve rol tabanlı erişim sağlanmasına olanak tanır.

## Teknolojiler ve Araçlar

- **.NET 8**: Uygulama, **.NET 8** sürümü ile geliştirilmiştir.
- **MVC (Model-View-Controller)**: Uygulama, MVC mimarisi kullanılarak yapılandırılmıştır.
- **Katmanlı Mimari**: Kodun daha temiz, sürdürülebilir ve test edilebilir olması için katmanlı mimari yaklaşımı benimsenmiştir.
- **Repository Pattern**: Veritabanı işlemlerinin soyutlanması ve yönetilmesi için **Repository Pattern** kullanılmıştır.
- **UnitOfWork Pattern**: Birim işlemleri yönetmek ve veritabanı işlemlerinin tutarlılığını sağlamak için **UnitOfWork Pattern** uygulanmıştır.
- **Rol Bazlı Yetkilendirme**: Kullanıcıların farklı rollere sahip olduğu ve her rolün belirli işlemlere erişebildiği bir rol bazlı yetkilendirme sistemi mevcuttur.
- **Identity**: **ASP.NET Identity** kullanılarak güvenli kullanıcı doğrulama ve yetkilendirme işlemleri yapılmıştır.

## Özellikler

- **Kitap Yönetimi**: Kitaplar eklenebilir, düzenlenebilir ve silinebilir. Kitapların detayları görüntülenebilir.
- **Kullanıcı Yönetimi**: Kullanıcılar sisteme giriş yapabilir, rol atanabilir ve yönetilebilir.
- **Rol Bazlı Yetkilendirme**: Kullanıcıların sadece kendi rollerine uygun işlemleri gerçekleştirmeleri sağlanır.
- **Gelişmiş Kimlik Doğrulama**: Kullanıcılar, kullanıcı ve şifre ile giriş yapabilir. Ayrıca, sistemde belirli işlemler için ek yetkiler (admin, kullanıcı vb.) atanabilir.
- **UnitOfWork ve Repository Patterns**: Veritabanı işlemleri düzgün bir şekilde yönetilir, işlem birliği sağlanır ve kodun sürdürülebilirliği artırılır.

### Gereksinimler

- .NET 8 SDK ve runtime
- SQL Server (ya da tercih ettiğiniz herhangi bir veritabanı)

## Başlangıç

Bu Uygulamanın Kullanımı:

### Kullanıcı Kayıt Sayfası

Aşağıda, kullanıcı kayıt sayfasının görseli yer almaktadır:

![RegisterView](https://github.com/user-attachments/assets/d343b910-1d9c-4a5c-a7a7-161e8c84c29e)

Kayıt işlemi sırasında kullanıcı doğrulama işlemi de yapılır. İşte kullanıcı doğrulama ekranı:

![RegisterValidationView](https://github.com/user-attachments/assets/04ba2f06-99e2-4b6a-a6ce-752d56458578)

### Giriş Sayfası

Kullanıcı giriş sayfasının tasarımı: Kayıtlı kullanıcı giriş yaptığında rolüne göre uygun sayaflara yönlendirir.

![LoginViewValidation](https://github.com/user-attachments/assets/ec6f31d6-7a87-4930-b51c-3c3c2f694555)


### Admin Ana Sayfası

![AdminHomePage](https://github.com/user-attachments/assets/bef6c4ce-6d70-4bc2-ab13-c9f9ff89017c)

### Rol Oluşturma Sayfası
Bu sayfada admin kullanıcı rollerini oluşturur.

![RoleCreate](https://github.com/user-attachments/assets/7cf0a07a-7073-493e-9526-45531c31db74)

### Admin Kitaplar Sayfası
Bu sayfada admin kullanıcısı kitapları görüntüleyebilir, düzenleyebilir ve silbilir.
Not: Kitap düzenleme ve silme işlemleri henüz eklenmemiştir.

![AdminBook](https://github.com/user-attachments/assets/cedaa56e-ae99-40c0-860b-47408a796190)

### Admin Kullanıcılar Sayfası
Bu sayfada admin kullanıcılara rol atama, rol güncelleme ve kullanıcı silme işlevlerini gerçekleştirir.

![User](https://github.com/user-attachments/assets/c8a4c7f2-5945-46e9-b176-81056e380fa4)

### Kullanıcı Rol Güncelleme Sayfası
Admin, Kullanıcının bir rolü varsa rol güncelle butonu aracılığyla bu sayfa açılır ve kullanıcıya yeni bir rol atanır

![RoleUpdate](https://github.com/user-attachments/assets/40ee32d6-0973-4c38-bd85-cec3d8d5d77f)

### Kullanıcı Rol Atama Sayfası
Admin, kullanıcının mevcut rolü yoksa Rol ekle butonu aracılığyla bu sayfa gelir ve kullanıcıya rol atama işlmeini gerçekleştirir.

![UserAssingeRole](https://github.com/user-attachments/assets/6307b6f8-e316-421a-815c-d5d6767f3b69)

### Kullanıcı Kitap Sayfası
Kullanıcı giriş yaptıktan sonra karşına çıkan kitap bilgilerini görür ve Detaylar butonu araclığıyla kitapın detaylarını gösteren sayfaya yönlendirilir.

![UserBook](https://github.com/user-attachments/assets/4e8a769f-c17a-4f16-84cc-b70c07eaf356)

### Kitap Detay Sayfası
Kullanıcı kitabın detaylarını gördüğü sayfadır.

![BookDetails](https://github.com/user-attachments/assets/52f234fb-a6c6-4c63-8f6a-d3001539b84c)

### Kulanıcı ProfiL Sayfası
Kullanıcı nav-bar'ın sağ tarafında bulunan profil icon'lu butona tılayarak kendi bilgilerini görür ve güncellemsine olanak tanır.

![UserInfo](https://github.com/user-attachments/assets/b6057752-d358-43ce-8dd2-641ab460178e)

### Hata Sayfası
herhangi bir hata olduğunda yönlendirilen sayfa

![ErrorView](https://github.com/user-attachments/assets/75be070d-1578-44b5-b29c-be0f6fcdc7b9)

### Notlar

1. Eğer sistemde tanımlı rol mevcut değilse projenin Views/UserRole ksöründe bulunan CreateRole.cshtml çalıştırılarak eklenebilir.
2. Eğer sistemde kullanıcıya tanımlı rol mevcut değilse Views/UserRole CreateRoleToUser.cshtml çalıştırılarak eklenebilir.
3. Admin nav-bar'ında bulunan kitap ekleme sekmesi henüz mevcut değildir.
