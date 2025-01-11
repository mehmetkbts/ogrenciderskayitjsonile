## Öğrenci ve Ders Yönetim Sistemi 📚
Bu uygulama, bir okul yönetim sistemini simüle eder ve öğrenci, öğretim görevlisi ve dersleri yönetmenizi sağlar. Kullanıcılar, öğrenci ve öğretim görevlisi tanımlayabilir, dersler oluşturabilir ve öğrencilerin derslere kayıt işlemlerini yapabilirler. Veriler JSON formatında kaydedilir ve her seferinde dosyadan yüklenir.

## Özellikler 🌟
1️⃣Öğrenci Tanımlama: Öğrenci adı, soyadı ve ID'si ile öğrenci kaydı yapılabilir.
2️⃣Öğretim Görevlisi Tanımlama: Öğretim görevlisi adı, soyadı ve ID'si ile öğretim görevlisi kaydı yapılabilir.
3️⃣Ders Tanımlama: Ders adı, kredisi ve öğretim görevlisi belirlenerek yeni dersler oluşturulabilir.
4️⃣Ders Detaylarını Görüntüleme: Oluşturulan derslerin detayları (ad, kredi, öğretim görevlisi, öğrenciler) gösterilebilir.
5️⃣Öğrenci Kaydı Yapma: Öğrenciler, mevcut derslere kayıt olabilirler.
6️⃣JSON Veritabanı: Öğrenciler, öğretim görevlileri ve dersler JSON dosyalarına kaydedilir ve her uygulama çalıştırıldığında bu dosyalardan yüklenir.

## Kullanıcı Arayüzü
Program, kullanıcıya bir menü sunarak çeşitli işlemleri yapmasını sağlar. Menü seçenekleri şu şekildedir:

1️⃣Öğrenci Tanımla: Yeni bir öğrenci ekler.
2️⃣Öğretim Görevlisi Tanımla: Yeni bir öğretim görevlisi ekler.
3️⃣Ders Tanımla: Yeni bir ders ekler.
4️⃣Dersin Detaylarını Göster: Mevcut derslerin detaylarını görüntüler.
5️⃣Öğrenci Kaydı Yap: Öğrencilerin derslere kayıt olmasını sağlar.
6️⃣Çıkış: Programdan çıkış yapar.

## Kullanım 📋
Başlatma
Proje Dosyasını İndirin:

1️⃣Projeyi bilgisayarınıza indirin veya bir IDE (örneğin Visual Studio) ile açın.

2️⃣Tools(Araçlar) > NuGet Package Manager > Package Manager Console yolunu izleyerek açın.

3️⃣Bu kodu açılan konsola girin:Install-Package Newtonsoft.Json

📌JSON kütüphanelerimiz yüklendi internette daha farklı yükleme yöntemleri vardır araştırıp bulabilirsiniz.


## Çalıştırma 🚀
Uygulamayı Başlatın: Uygulamayı çalıştırdığınızda, ana menü ekranda belirecektir.
Menüyü Kullanarak İşlemleri Yapın:
Menüdeki sayısal seçeneklere göre işlemleri gerçekleştirebilirsiniz. Örneğin, 1 tuşuna basarak öğrenci ekleyebilir, 3 tuşuna basarak ders ekleyebilirsiniz.
JSON Dosyaları: Veriler students.json, instructors.json ve courses.json dosyalarına kaydedilecektir. Bu dosyalar uygulama her başlatıldığında otomatik olarak yüklenir.

## JSON Dosya Yapısı 📂
Veriler JSON formatında şu şekilde saklanacaktır:

students.json:

json
[
  {
    "Name": "Ahmet",
    "Surname": "Yılmaz",
    "Id": 1001,
    "EnrolledCourses": [
      {
        "Name": "Matematik 101",
        "Credits": 3
      }
    ]
  }
]

instructors.json:

json
[
  {
    "Name": "Dr. Hasan",
    "Surname": "Yıldız",
    "Id": 2001,
    "Courses": [
      {
        "Name": "Matematik 101",
        "Credits": 3
      }
    ]
  }
]

courses.json:

json
[
  {
    "Name": "Matematik 101",
    "Credits": 3,
    "Instructor": {
      "Name": "Dr. Hasan",
      "Surname": "Yıldız"
    },
    "EnrolledStudents": [
      {
        "Name": "Ahmet",
        "Surname": "Yılmaz"
      }
    ]
  }
]

Kodun json kullanılmamış halini profilimden bulabilrisiniz orda kodu detaylıca anlattım😊

## Geliştirme ve Katkı Yapma 🤝
Bu projeyi geliştirerek yeni özellikler ekleyebilirsiniz! Aşağıdaki özellikler eklenebilir:

1️⃣Dersin Kapanması: Dersin tamamlanma durumu ve kapanma tarihi eklenebilir.
2️⃣Notlandırma Sistemi: Öğrenciler için sınav notları ve genel başarı durumu eklenebilir.
3️⃣Yönetici Rolü: Yönetici kullanıcıları için daha fazla yetki eklenebilir.

Projeye katkı sağlamak için pull request gönderebilirsiniz😊

## Lisans 📄
https://github.com/mehmetkbts
