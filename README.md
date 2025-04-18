# Horian Şifre Yöneticisi

Horian Şifre Yöneticisi, kullanıcıların çeşitli platformlardaki şifrelerini güvenli bir şekilde saklamalarına ve yönetmelerine olanak sağlayan bir masaüstü uygulamasıdır. Bu uygulama, kullanıcılara program adı, e-posta, telefon numarası, tam ad, takma ad ve diğer bilgilerini depolama imkanı sunar. Ayrıca, kullanıcı verilerini güncelleyebilme ve silme işlevselliği de sağlar.

Bu proje **emchorian** tarafından yapılmış ve **Horian Studios** çatısında yayınlanmaktadır.

## Özellikler

- **Kullanıcı Verisi Yönetimi**: Kullanıcılar, şifre ve diğer bilgilerini güvenli bir şekilde hiçbir sunucuya bağlı kalmadan kendi bilgisayarında saklayabilir ve bu verileri düzenleyebilir.
- **Şifre Görünürlük Değişimi**: Şifrelerin güvenli bir şekilde gösterilmesini sağlayan bir şifre gizleme ve gösterme özelliği sunar.
- **Kullanıcı Güncelleme**: Mevcut kullanıcı verilerini düzenleyebilir ve dosyadaki bilgileri güncelleyebilirsiniz.
- **Kullanıcı Silme**: Kullanıcıyı veritabanından silmek için kullanıcı verileri dosyasından çıkartılır.
- **H Logo ile Ana Sayfaya Dönme**: Sol üst köşede bulunan "H" logosuna basarak ana sayfaya geri dönebilirsiniz.

## Kullanım

Horian Şifre Yöneticisi, şifrelerinizi güvenli bir şekilde saklamak ve yönetmek için kullanıcı dostu bir arayüz sunar. Uygulama açıldığında, kullanıcılar programlarına dair bilgileri ekleyebilir, güncelleyebilir veya silebilirler.

### Yeni Kullanıcı Ekleme

Ana ekrandan "Yeni Kullanıcı Ekle" seçeneğini kullanarak yeni bir kullanıcı bilgisi ekleyebilirsiniz. Program adı, e-posta, şifre, telefon numarası, tam ad, takma ad gibi bilgileri girmeniz gerekecektir.

### Kullanıcı Güncelleme

Mevcut bir kullanıcıyı güncellemek için, kullanıcı listesinden düzenlemek istediğiniz kullanıcıyı seçin. Bilgilerini değiştirdikten sonra "Kaydet" butonuna tıklayarak bilgileri güncelleyebilirsiniz.

### Kullanıcı Silme

Kullanıcıyı silmek için, ilgili kullanıcıyı seçip "Sil" butonuna tıklayarak kullanıcıyı sistemden kaldırabilirsiniz.

### Şifre Görünürlüğü

Şifre alanındaki göz ikonuna tıklayarak şifrenizi gösterebilir veya gizleyebilirsiniz. Bu işlem güvenliğinizi tehlikeye atmadan yapılabilir.

## Kurulum

### Gereksinimler

- **.NET Framework 4.7.2** veya daha yeni bir sürüm.
- **Visual Studio** veya benzeri bir C# geliştirme ortamı.

### Adımlar

1. **Proje İndirme**: Projeyi GitHub'dan veya yerel bilgisayarınızdan indirin.
2. **Visual Studio ile Açma**: İndirilen projeyi Visual Studio veya benzeri bir IDE ile açın.
3. **Bağımlılıkları Yükleme**: Projeyi açtıktan sonra gerekli bağımlılıkları yüklemek için Visual Studio'da "NuGet" paket yöneticisini kullanın.
4. **Uygulamayı Çalıştırma**: Proje yapılandırması tamamlandıktan sonra, `Horian_Şifre_Yöneticisi` projesini çalıştırarak uygulamayı başlatın.

## Konfigürasyon

Eğer uygulama üzerinde bazı özelleştirmeler yapmak isterseniz, aşağıdaki değişiklikleri yapabilirsiniz:

- **Kullanıcı Adı ve Şifreyi Değiştirme**: Giriş ekranındaki kullanıcı adı ve şifreyi değiştirmek için `giris_form.cs` dosyasındaki 84-85. satırları ile 117-118. satırlarını düzenlemeniz gerekmektedir.
  
- **Yüklenme ve Giriş Ekranını Atlamak**: Eğer programı açarken yüklenme ve giriş ekranlarını atlamak isterseniz, `program.cs` dosyasındaki 19. satırdaki `Application.Run(new yuklenme_form());` kodunu `Application.Run(new hesap_listesi_form());` olarak değiştirebilirsiniz.

- **Hesap Kaydederken Anasayfaya Gitmek**: Hesap kaydettikten sonra anasayfaya gitmek için, programın sol üst kısmında bulunan "H" logosuna basarak ana sayfaya dönebilirsiniz.

## Veri Güvenliği

- **Veri Saklama**: Kullanıcı verileri `users.txt` dosyasına düz metin (şifrelenmemiş) olarak kaydedilir. Bu dosya, uygulama dizininde yer alır ve gizli hale getirilmiştir. Dosya dışa aktarılmaz; tüm veriler yalnızca yerel makinede tutulur.
- **Şifre Gizliliği**: Şifre giriş alanlarında, şifreler başlangıçta gizlenmiş şekilde gösterilir. Göz ikonu ile geçici olarak görülebilir. Ancak arka planda şifreleme işlemi yapılmaz.

## Sorumluluk Reddi

- **Veri Güvenliği**: Kullanıcı verileri `users.txt` dosyasına kaydedilmektedir. Ancak, şifreler düz metin olarak kaydedilmektedir. Verilerinizi kaybetmemeniz için düzenli olarak yedek almanızı öneririz.
- **Sorumluluk Reddi**: Verilerinizin kaybolması veya kullanıcı hesabınızın silinmesi durumunda, bu proje ile ilgili herhangi bir sorumluluk kabul edilmez. Programın herhangi bir nedenle çökmesi veya veri kaybı yaşanması durumunda oluşacak zararlar için **Horian Studios** sorumluluk kabul etmemektedir.

## Performans İpuçları

- **Dosya Yönetimi**: `users.txt` dosyasının boyutu arttıkça, verilerin işlenmesi ve yüklenmesi süresi uzayabilir. Bu yüzden, büyük veri setlerinde uygulamanın performansı etkilenebilir. Kullanıcı bilgilerini düzenli olarak temizlemek ve gereksiz verileri silmek uygulamanın hızını artıracaktır.
- **Yedekleme ve Temizlik**: Veritabanınızı düzenli olarak yedeklemek ve eski verileri temizlemek, programın performansını iyileştirebilir.

## Veri Yedekleme

- **Verilerinizi Yedekleyin**: Kullanıcı verileri, `users.txt` dosyasında saklanmaktadır. Verilerinizin kaybolmasını önlemek için düzenli olarak bu dosyanın yedeğini almanız önemlidir. Ayrıca, kullanıcılar, uygulamayı kullanmadan önce veritabanını yedekleyerek veri kaybı riskini azaltabilirler.

## Lisans

Bu proje [MIT Lisansı](https://opensource.org/licenses/MIT) ile lisanslanmıştır. Daha fazla bilgi için [LICENSE](/emchorian/horian-password-manager/blob/main/LICENSE) dosyasına bakabilirsiniz.

## İletişim

Proje hakkında herhangi bir soru veya geri bildirim için [36.emchorian.470@gmail.com](mailto:36.emchorian.470@gmail.com) adresiyle iletişime geçebilirsiniz.
s
